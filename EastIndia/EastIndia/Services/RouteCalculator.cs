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
        public ExternalRouteDetails[] CalculateRoutes(Package package)
        {
            List<Location> locations = GetLocations(package);

            (List<(Vertex, Vertex)>, List<Edge>) verticesAndEdges = GetEdges(locations);

            CalculateDistance(verticesAndEdges);

            return null;
        }

        public void CalculateDistance((List<(Vertex, Vertex)>, List<Edge>) verticesAndEdges)
        {
            PathFinderFactory pathFinderFactory = new PathFinderFactoryYanQi();

            Graph graph = CreateGraph(verticesAndEdges.Item2);

            PathFinder pathFinder = pathFinderFactory.CreatePathFinder(graph);

            IList<Path> shortestPathsFromOsakatoSendai = pathFinder.FindShortestPaths(verticesAndEdges.Item1.First().Item1, verticesAndEdges.Item1.First().Item2, 5);

            List<(string, string)> shortestPaths = new List<(string, string)>();

            foreach (Path shortestPath in shortestPathsFromOsakatoSendai)
            {
                foreach (Edge edge in shortestPath.EdgesForPath)
                {
                    shortestPaths.Add((edge.StartVertex.VertexId, edge.EndVertex.VertexId));
                }
            }

            
        }

        public List<Location> GetLocations(Package package)
        {
            DbHelper dbHelper = new DbHelper();

            return dbHelper.GetAll<Location>(x => x.Name != null);
        }
        private (List<(Vertex, Vertex)>, List<Edge>) GetEdges(List<Location> locations)
        {
            DbHelper dbHelper = new DbHelper();
            List<(Vertex, Vertex)> vertices = new List<(Vertex, Vertex)>();
            List<LocationDistance> hops = new List<LocationDistance>();
            LocationDistance location = dbHelper.Get<LocationDistance>(Guid.NewGuid());

            foreach(Location startLoc in locations)
            {
                foreach (Location endLoc in locations) 
                {
                    if (startLoc != endLoc)
                    {
                        LocationDistance locationDistance = dbHelper.GetAll<LocationDistance>(x => x.StartLocationID == startLoc.ID && x.EndLocationID == endLoc.ID).FirstOrDefault();
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

            return (vertices, edges);
        }
    }

    public static class MyExtensionMethods
    {
        public static string GetPathAsPrettyPrintedStringForConsoleOutput(this Path path)
        {
            var sb = new StringBuilder();
            IList<Edge> edges = path.EdgesForPath;
            sb.Append(path.TotalWeightForPath.WeightValue + " ( ");
            for (int i = 0; i < edges.Count; i++)
            {
                if (i > 0) sb.Append(" + ");
                sb.Append(edges[i].GetEdgeAsPrettyPrintedStringForConsoleOutput());
            }
            sb.Append(")");
            return sb.ToString();
        }
        private static string GetEdgeAsPrettyPrintedStringForConsoleOutput(this Edge edge)
        {
            return edge.EdgeWeight.WeightValue + " [" + edge.StartVertex.VertexId + "--->" + edge.EndVertex.VertexId + "] ";
        }
    }
}