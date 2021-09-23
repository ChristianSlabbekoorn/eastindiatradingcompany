using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Programmerare.ShortestPaths.Core.Api;
using Programmerare.ShortestPaths.Adapter.Bsmock;
using Programmerare.ShortestPaths.Adapter.YanQi;
using static Programmerare.ShortestPaths.Core.Impl.VertexImpl;	// CreateVertex
using static Programmerare.ShortestPaths.Core.Impl.WeightImpl;	// CreateWeight
using static Programmerare.ShortestPaths.Core.Impl.EdgeImpl;	// CreateEdge
using static Programmerare.ShortestPaths.Core.Impl.GraphImpl;   // CreateGraph
using System.Text;

namespace EastIndia.Services
{
    public class RouteCalculator
    {
        public void CalculateDistance()
        {
            PathFinderFactory pathFinderFactory = new PathFinderFactoryYanQi();

            Vertex Tokyo = CreateVertex("Tokyo");
            Vertex Osaka = CreateVertex("Osaka");
            Vertex Kyoto = CreateVertex("Kyoto");
            Vertex Sendai = CreateVertex("Sendai");

            Edge TokyoOsaka = CreateEdge(Tokyo, Osaka, CreateWeight(7));
            Edge TokyoKyoto = CreateEdge(Tokyo, Kyoto, CreateWeight(6));
            Edge TokyoSendai = CreateEdge(Tokyo, Sendai, CreateWeight(4));
            Edge OsakaKyoto = CreateEdge(Osaka, Kyoto, CreateWeight(3));
            Edge OsakaSendai = CreateEdge(Osaka, Sendai, CreateWeight(9));
            Edge KyotoSendai = CreateEdge(Kyoto, Sendai, CreateWeight(8));

            Edge OsakaTokyo = CreateEdge(Osaka, Tokyo, CreateWeight(7));
            Edge KyotoTokyo = CreateEdge(Kyoto, Tokyo, CreateWeight(6));
            Edge SendaiTokyo = CreateEdge(Sendai, Tokyo, CreateWeight(4));
            Edge KyotoOsaka = CreateEdge(Kyoto, Osaka, CreateWeight(3));
            Edge SendaiOsaka = CreateEdge(Sendai, Osaka, CreateWeight(9));
            Edge SendaiKyoto = CreateEdge(Sendai, Kyoto, CreateWeight(8));

            IList<Edge> edges = new List<Edge>()
            {
                TokyoOsaka, 
                TokyoKyoto,
                TokyoSendai,
                OsakaKyoto,
                OsakaSendai,
                KyotoSendai,
                OsakaTokyo,
                KyotoTokyo,
                SendaiTokyo,
                KyotoOsaka,
                SendaiOsaka,
                SendaiKyoto
            };

            Graph graph = CreateGraph(edges);

            PathFinder pathFinder = pathFinderFactory.CreatePathFinder(graph);

            IList<Path> shortestPathsFromOsakatoSendai = pathFinder.FindShortestPaths(Osaka, Sendai, 100);

            List<(string, string)> shortestPaths = new List<(string, string)>();

            foreach (Path shortestPath in shortestPathsFromOsakatoSendai)
            {
                foreach (Edge edge in shortestPath.EdgesForPath)
                {
                    shortestPaths.Add((edge.StartVertex.VertexId, edge.EndVertex.VertexId));
                }
            }
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