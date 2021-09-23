
namespace EastIndia.Controllers
{
    public class RouteController : Controller
    {

        public void CalculateRoute (Package package)
        {

        }

        public static List<Vertex> Dijkstra(Vertex[] vertices, int[][] graph, int source)
        {
            InitializeSingleSource(vertices, vertices[source]);
            List<Vertex> result = new List<Vertex>();
            //adding all vertex to priority queue
            PriorityQueue.PriorityQueue<Vertex> queue = new PriorityQueue.PriorityQueue<Vertex>(true);
            for (int i = 0; i < vertices.Length; i++)
                queue.Enqueue(vertices[i].D, vertices[i]);

            //treversing to all vertices
            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                result.Add(u);
                //again traversing to all vertices
                for (int v = 0; v < graph[Convert.ToInt32(u.Name)].Length; v++)
                {
                    if (graph[Convert.ToInt32(u.Name)][v] > 0)
                    {
                        Relax(u, vertices[v], graph[Convert.ToInt32(u.Name)][v]);
                        //updating priority value since distance is changed
                        queue.UpdatePriority(vertices[v], vertices[v].D);
                    }
                }
            }
            return result;
        }

        public static void InitializeSingleSource(Vertex[] vertices, Vertex s)
        {
            foreach (Vertex v in vertices)
            {
                v.D = int.MaxValue;
                v.Parent = null;
            }
            s.D = 0;
        }

        public static void Relax(Vertex u, Vertex v, int weight)
        {
            if (v.D > u.D + weight)
            {
                v.D = u.D + weight;
                v.Parent = u;
            }
        }

        public static void PrintPath(Vertex u, Vertex v, List<Vertex> vertices)
        {
            if (v != u)
            {
                PrintPath(u, v.Parent, vertices);
                Console.WriteLine("Vertax {0} weight: {1}", v.Name, v.D);
            }
            else
                Console.WriteLine("Vertax {0} weight: {1}", v.Name, v.D);
        }

        static void Main(string[] args)
        {
            int[][] adjacencyMatrix = new int[][] { new int[] { 0,0,0,3,12 },
                                    new int[] { 0,0,2,0,0 },
                                    new int[] { 0,0,0,-2,0 },
                                    new int[] { 0,5,3,0,0 },
                                    new int[] { 0,0,7,0,0 } };
            Vertex[] vertices = new Vertex[adjacencyMatrix.GetLength(0)];
            //Source vertex
            int source = 0;

            for (int i = 0; i < vertices.Length; i++)
                vertices[i] = new Vertex() { Name = i.ToString() };
            //calling dijkstra  algorithm
            List<Vertex> result = Dijkstra(vertices, adjacencyMatrix, source);
            //printing distance
            PrintPath(vertices[0], vertices[2], result);
            Console.ReadLine();
        }

    }

}