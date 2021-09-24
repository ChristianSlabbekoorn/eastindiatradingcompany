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

namespace EastIndia.Services
{
    public class RouteCalculator
    {
        private DbHelper dbHelper;

        public RouteCalculator()
        {
            dbHelper = new DbHelper();
        }

        public ExternalRouteDetails CalculateRoutes(Package package)
        {
            List<Location> locations = GetLocations(package);

            List<Edge> edges = GetEdges(locations);

            string from = dbHelper.Get<Location>(package.FromCity.Value).Name;
            string to = dbHelper.Get<Location>(package.ToCity.Value).Name;


            (string, string, double) shortestRoute = CalculateDistance((from, to), edges);

            PriceCalculator priceCalculator = new PriceCalculator();


            return new ExternalRouteDetails() 
            {
                Start = shortestRoute.Item1,
                Stop = shortestRoute.Item2,
                Duration = (shortestRoute.Item3 * 12).ToString(),
                Price = priceCalculator.CalculatePrice((int)shortestRoute.Item3, package).ToString()
        };
        }

        public (string, string, double) CalculateDistance((string, string) cities, List<Edge> edges)
        {
            PathFinderFactory pathFinderFactory = new PathFinderFactoryYanQi();

            Graph graph = CreateGraph(edges);

            PathFinder pathFinder = pathFinderFactory.CreatePathFinder(graph);

            Vertex from = CreateVertex(cities.Item1);
            Vertex to = CreateVertex(cities.Item2);

            IList<Path> shortestPathsFromOsakatoSendai = pathFinder.FindShortestPaths(from, to, 50);

            List<(string, string, double)> shortestPaths = new List<(string, string, double)>();

            foreach (Path shortestPath in shortestPathsFromOsakatoSendai)
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
    }
}