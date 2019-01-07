using System;
using System.Collections;


namespace PS9
{
    class Program
    {

        static int[] distances;
        static int[] penalties;

        static void Main(string[] args)
        {
            String[] line = Console.ReadLine().Split();
            int n;
            int.TryParse(line[0], out n);
            distances = new int[n + 1];
            penalties = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                line = Console.ReadLine().Split();
                int dist;
                int.TryParse(line[0], out dist);
                distances[i] = dist;
            }

            computePenalties();

            Console.WriteLine(penalties[0]);
        }

        static void computePenalties()
        {
            for (int i = distances.Length - 1; i >= 0; i--)
            {
                penalties[i] = computePenalty(i);
            }
        }

        static int computePenalty(int i) 
        {
            if (i == distances.Length - 1)
            {
                return 0;
            }
            int min = int.MaxValue;
            for (int k = i + 1; k < distances.Length; k++) 
            {
                int penalty = penalties[k] + (int)Math.Pow(400 - (distances[k] - distances[i]), 2);
                if (min > penalty) 
                {
                    min = penalty;
                }
            }
            return min;
        }


    }
}
