using System;

namespace Exam_Vlasenko
{
    internal class Dijkstra
    {
        public static (double[] distances, int[] predecessors) FindShortestPaths(double[,] graph, int start)
        {
            int n = graph.GetLength(0);
            double[] dist = new double[n];
            int[] prev = new int[n];
            bool[] visited = new bool[n];
            int unvisited = n;

            for (int i = 0; i < n; i++)
            {
                dist[i] = double.MaxValue;
                prev[i] = -1;
            }
            dist[start] = 0.0;

            while (unvisited > 0)
            {
                int current = FindNextNode(dist, visited);
                if (current == -1) break;

                visited[current] = true;
                unvisited--;

                UpdateDistances(graph, dist, prev, current);
            }

            return (dist, prev);
        }

        private static int FindNextNode(double[] dist, bool[] visited)
        {
            int current = -1;
            for (int i = 0; i < dist.Length; i++)
            {
                if (!visited[i] && (current == -1 || dist[i] < dist[current]))
                    current = i;
            }
            return current;
        }

        private static void UpdateDistances(double[,] graph, double[] dist, int[] prev, int current)
        {
            for (int i = 0; i < dist.Length; i++)
            {
                if (graph[current, i] > 0 && dist[i] > dist[current] + graph[current, i])
                {
                    dist[i] = dist[current] + graph[current, i];
                    prev[i] = current;
                }
            }
        }

        public static void PrintPath(int[] predecessors, int start, int end)
        {
            var path = new System.Collections.Generic.Stack<int>();
            int current = end;

            while (current != start && current != -1)
            {
                path.Push(current);
                current = predecessors[current];
            }

            if (current == -1)
            {
                Console.WriteLine("Путь не найден");
                return;
            }

            path.Push(start);
            Console.WriteLine("Оптимальный маршрут: " + string.Join(" -> ", path.Select(x => x + 1)));
        }
    }
}