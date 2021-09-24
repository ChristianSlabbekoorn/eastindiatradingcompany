using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Programmerare.ShortestPaths.Core.Api;
using Programmerare.ShortestPaths.Adapter.Bsmock;
using Programmerare.ShortestPaths.Adapter.YanQi;
using static Programmerare.ShortestPaths.Core.Impl.VertexImpl;
using static Programmerare.ShortestPaths.Core.Impl.WeightImpl;
using static Programmerare.ShortestPaths.Core.Impl.EdgeImpl;
using static Programmerare.ShortestPaths.Core.Impl.GraphImpl;
using EastIndia.Helpers;
using EastIndia.Models;
using EastIndia.Models.Dtos;
using RouteHop = EastIndia.Models.Dtos.RouteHop;
using Package = EastIndia.Models.Dtos.Package;
using EastIndia.Integrations;

namespace EastIndia.Services
{
    public class RouteCalculator
    {
        private DbHelper dbHelper;
        private IntegrationService externalIntegration;

        public RouteCalculator()
        {
            dbHelper = new DbHelper();
            externalIntegration = new IntegrationService();
        }

        public ExternalRouteDetails CalculateRoutes(Package package)
        {
            List<Location> locations = GetLocations(package);

            List<Edge> edges = GetEdges(locations);

            var from = dbHelper.Get<Location>(package.FromCity.Value);
            var to = dbHelper.Get<Location>(package.ToCity.Value);

            (string, string, double) shortestRoute;

            try
            {
                shortestRoute = CalculateDistance((from.Name, to.Name), edges);

                PriceCalculator priceCalculator = new PriceCalculator();

                return new ExternalRouteDetails()
                {
                    Start = shortestRoute.Item1,
                    Stop = shortestRoute.Item2,
                    Duration = FormatTime((shortestRoute.Item3 * 12).ToString()),
                    Price = priceCalculator.CalculatePrice((int)shortestRoute.Item3, package).ToString()
                };
            }
            catch (Exception e)
            {
                List<ExternalRouteDetails> routes = externalIntegration.GetAllRoutes(MapPackage(package), Vendor.TelstarLogistics);

                List<double> prices = new List<double>();
                List<double> distance = new List<double>();

                prices.AddRange(routes.Select(x => double.Parse(x.Price)));
                distance.AddRange(routes.Select(x => double.Parse(x.Duration)));

                return new ExternalRouteDetails()
                {
                    Start = from.Name,
                    Stop = to.Name,
                    Price = prices.Sum().ToString(),
                    Duration = distance.Sum().ToString()
                };
            } 
        }


        private string FormatTime(string duration)
        {
            var durationAsDouble = double.Parse(duration);
            var timeSpan = TimeSpan.FromHours(durationAsDouble);
            double hh = timeSpan.TotalHours;
            var mm = timeSpan.Minutes;

            return hh == 0 ? $"{mm}m" : $"{hh}h {mm}m";
        }
        public (string, string, double) CalculateDistance((string, string) cities, List<Edge> edges)
        {
            PathFinderFactory pathFinderFactory = new PathFinderFactoryYanQi();

            Graph graph = CreateGraph(edges);

            PathFinder pathFinder = pathFinderFactory.CreatePathFinder(graph);

            Vertex from = CreateVertex(cities.Item1);
            Vertex to = CreateVertex(cities.Item2);

            IList<Path> shortestPathsAlgorithm = pathFinder.FindShortestPaths(from, to, 50);

            List<(string, string, double)> shortestPaths = new List<(string, string, double)>();

            foreach (Path shortestPath in shortestPathsAlgorithm)
            {
                foreach (Edge edge in shortestPath.EdgesForPath)
                {
                    shortestPaths.Add((edge.StartVertex.VertexId, edge.EndVertex.VertexId, edge.EdgeWeight.WeightValue));
                }
            }

            List<(string, string, double)> shortestChain = new List<(string, string, double)>();

            foreach ((string, string, double) pathWithWeight in shortestPaths)
            {
                shortestChain.Add(pathWithWeight);
                if (pathWithWeight.Item2 == cities.Item2) break;
            }

            List<double> hops = new List<double>();
            foreach ((string, string, double) hop in shortestChain)
            {
                hops.Add(hop.Item3);
            }

            return (cities.Item1, cities.Item2, hops.Sum());
        }

        public List<Location> GetLocations(Package package)
        {
            return dbHelper.GetAll<Location>(x => x.Name != null);
        }

        private List<Edge> GetEdges(List<Location> locations)
        {
            List<(Vertex, Vertex)> vertices = new List<(Vertex, Vertex)>();
            List<LocationDistance> hops = new List<LocationDistance>();
            LocationDistance location = dbHelper.Get<LocationDistance>(Guid.NewGuid());

            foreach(Location startLoc in locations)
            {
                foreach (Location endLoc in locations) 
                {
                    if (startLoc != endLoc)
                    {
                        LocationDistance locationDistance = dbHelper.GetAll<LocationDistance>(x => x.StartLocationID == startLoc.ID && x.EndLocationID == endLoc.ID && x.ConnectionType == (int)ConnectionType.Sea).FirstOrDefault();
                        if (locationDistance != null) 
                        {
                            hops.Add(locationDistance);
                            Vertex from = CreateVertex(startLoc.Name);
                            Vertex to = CreateVertex(endLoc.Name);
                            vertices.Add((from, to));
                        }
                    }
                }
            }

            List<Edge> edges = new List<Edge>();

            foreach (LocationDistance hop in hops)
            {
                edges.Add(CreateEdge(CreateVertex(hop.StartLocation.Name), CreateVertex(hop.EndLocation.Name), CreateWeight(Convert.ToDouble(hop.Segments))));
            }

            return edges;
        }

        private ExternalPackage MapPackage(Package package)
        {
            return new ExternalPackage()
            {
                Date = package.Date,
                Depth = 0,
                Height = 0,
                Width = 0,
                Weight = package.Weight,
                IsAnimals = package.IsAnimals,
                IsCautious = package.IsCautious,
                IsRecorded = package.IsRecorded,
                IsRefrigerated = package.IsRefrigerated,
                IsWeapons = package.IsWeapons
            };
        }
    }
}