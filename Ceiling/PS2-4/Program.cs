using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace PS2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int[]> sols = new List<int[]>();

            string[] firstLine = Console.ReadLine().Split(null);
            int n, k;
            int.TryParse(firstLine[0], out n);
            int.TryParse(firstLine[1], out k);

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine().Split(null);

                int[] structureTree = new int[(int)Math.Pow(2, k)];
                Node[] tree = new Node[(int)Math.Pow(2, k)];
                CreateTree(line, k, ref structureTree, ref tree);

                CheckIfContains(structureTree, ref sols, k);
            }

            Console.WriteLine(sols.Count);
        }

        static void CheckIfContains(int[] tree, ref List<int[]> sols, int k) {
            for (int i = 0; i < sols.Count; i++)
            {
                if (IsEqual(sols[i], tree, k)) { return; }
            }
            sols.Add(tree);
        }

        static bool IsEqual(int[] ls, int[] rs, int k) {
            for (int i = 0; i < ls.Length; i++)
            {
                if (ls[i] != rs[i]) {
                    return false;
                }
            }
            return true;
        }

           
        static void CreateTree(string[] nodes, int k, ref int[] structureTree, ref Node[] tree) 
        {
            int rootVal;
            int.TryParse(nodes[0], out rootVal);
            Node root = new Node(rootVal, 0);
            tree[0] = root;
            structureTree[0] = 1; 
            Node parent = root;

            for (int i = 1; i < k; i++) 
            {
                int nodeVal;
                int.TryParse(nodes[i], out nodeVal);
                Node node = new Node(nodeVal);

                while (true) {
                    int pos = node.value > parent.value ? parent.pos * 2 + 2 : parent.pos * 2 + 1;

                    if (tree[pos] == null) 
                    {
                        structureTree[pos] = 1;
                        node.pos = pos;
                        tree[pos] = node;
                        parent = root;
                        break;

                    }
                    else 
                    {
                        parent = tree[pos];
                    }
                }
            }
        }


        class Node
        {

            public int pos;
            public int value;

            public Node(int value)
            {
                this.value = value;
                this.pos = -1;
            }

            public Node(int value, int pos) {
                this.value = value;
                this.pos = pos;
            }

        }
    }
}
