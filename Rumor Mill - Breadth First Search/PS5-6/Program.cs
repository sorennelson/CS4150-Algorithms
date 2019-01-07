using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PS5_6
{

    class Program
    {
        static void Main(string[] args)
        {

            List<Vertex> vertices = new List<Vertex>();

            int n;
            string[] numberOfStudents = Console.ReadLine().Split(null);
            int.TryParse(numberOfStudents[0], out n);

            for (int i = 0; i < n; i++) {
                string[] line = Console.ReadLine().Split(null);
                string name = line[0];

                vertices.Add(new Vertex(name));
            }

            int f;
            string[] numberOfFriendPairs = Console.ReadLine().Split(null);
            int.TryParse(numberOfFriendPairs[0], out f);

            for (int i = 0; i < f; i++)
            {
                string[] line = Console.ReadLine().Split(null);

                Vertex left = vertices.Find((x) => x.name == line[0]);
                Vertex right = vertices.Find((x) => x.name == line[1]);

                left.connectedVertices.Add(right);
                right.connectedVertices.Add(left);
            }

            int r;
            string[] numberOfReports = Console.ReadLine().Split(null);
            int.TryParse(numberOfReports[0], out r);
            string[] lines = new string[r];

            for (int i = 0; i < r; i++)
            {
                string[] line = Console.ReadLine().Split(null);
                string name = line[0];

                Vertex vertex = vertices.Find((x) => x.name == name);
                bfs(ref vertices, vertex);

                String rumorMill = "";

                foreach (Vertex v in vertices)
                {
                    rumorMill += v.name + " ";
                }
                lines[i] = rumorMill;
            }

            foreach (String s in lines)
            {
                Console.WriteLine(s);
            }
        }



        static void bfs(ref List<Vertex> vertices, Vertex vertex)
        {   
            Dictionary<Vertex, Vertex> prev = new Dictionary<Vertex, Vertex>();
            Dictionary<Vertex, int> dist = new Dictionary<Vertex, int>();
            List<List<Vertex>> distLists = new List<List<Vertex>>();

            foreach (Vertex v in vertices)
            {
                prev.Add(v, null);
                dist.Add(v, int.MaxValue);
            }

            dist[vertex] = 0;
            distLists.Add(new List<Vertex> { vertex });
             

            Queue<Vertex> queue = new Queue<Vertex>();
            queue.Enqueue(vertex);

            while (queue.Count != 0)
            {
                Vertex u = queue.Dequeue();

                foreach (Vertex v in u.connectedVertices)
                {
                    int distance = dist[u] + 1;
                    int prevDist = dist[v];

                    if (prevDist > distance)
                    {
                        dist[v] = distance;
                        prev[v] = u;

                        if (distLists.Count > distance) {
                            distLists[distance].Add(v);
                        } else {
                            distLists.Add(new List<Vertex> { v });
                        }

                        if (prevDist != int.MaxValue)
                        {
                            distLists[prevDist].Remove(v);
                        }

                        queue.Enqueue(v);

                    }
                }
            }

            distLists.Add(new List<Vertex>());
            foreach (KeyValuePair<Vertex, int> distance in dist) {

                if (distance.Value == int.MaxValue) {
                    distLists[distLists.Count - 1].Add(distance.Key);
                }
            }


            vertices = sortDistances(ref distLists);
        }

        static List<Vertex> sortDistances(ref List<List<Vertex>> distLists) {
            List<Vertex> vertices = new List<Vertex>();

            for (int i = 0; i < distLists.Count; i++)
            {
                List<Vertex> list = distLists[i];
                list.Sort();
                vertices.AddRange(list);
            }

            return vertices;
        }



        class Vertex : IComparable
        {

            public string name;
            public List<Vertex> connectedVertices;

            public Vertex(string name)
            {
                this.name = name;
                this.connectedVertices = new List<Vertex>();
            }

            public int CompareTo(object obj) {
                Vertex right = (Vertex)obj;
                return name.CompareTo(right.name);
            }

        }
    }
}
