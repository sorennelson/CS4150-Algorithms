using System;
using System.Collections.Generic;

namespace PS8
{
    class Program
    {
        static Dictionary<int, int>[] count;
        static SortedSet<int>[] users;
        static int[] realQueue;

        static void Main(string[] args)
        {
            string[] line = System.Console.ReadLine().Split(null);
            int t, n;
            int.TryParse(line[0], out n);
            int.TryParse(line[1], out t);

            count = new Dictionary<int, int>[t];
            for (int i = 0; i < t; i++) { count[i] = new Dictionary<int, int>(); }

            users = new SortedSet<int>[t];
            for (int i = 0; i < t; i++) { users[i] = new SortedSet<int>(); }

            for (int i = 1; i <= n; i++) 
            {
                line = System.Console.ReadLine().Split(null);
                int cash, time;
                int.TryParse(line[0], out cash);
                int.TryParse(line[1], out time);
                users[time].Add(cash);
                DictionaryAdd(time, cash);
            }

            realQueue = new int[t];

            for (int i = t - 1; i >= 0; i--) 
            {
                int largestUser = 0;
                int largestTime = -1;
  
                for (int j = t - 1; j >= i; j--)
                {
                    if (users[j].Count > 0 && users[j].Max > largestUser)
                    {
                        ResetLargest(ref largestUser, ref largestTime, j);
                    }
                }
                realQueue[i] = largestUser;
            }

            int sum = 0;
            foreach (int m in realQueue) { sum += m; }

            System.Console.WriteLine(sum);
        }

        static int SetLargest(int i)
        {
            int largestUser = users[i].Max;
            realQueue[i] = largestUser;
            count[i][largestUser]--;
            if (count[i][largestUser] == 0)
            {
                users[i].Remove(largestUser);
            }
            return largestUser;
        }

        static void ResetLargest(ref int largestUser, ref int largestTime, int j)
        {
            if (largestTime > -1 && count[largestTime].ContainsKey(largestUser))
            {
                if (count[largestTime][largestUser] == 0)
                {
                    users[largestTime].Add(largestUser);
                }
                count[largestTime][largestUser]++;
            }

            largestUser = users[j].Max;
            largestTime = j;
            count[j][largestUser]--;
            if (count[j][largestUser] == 0)
            {
                users[j].Remove(largestUser);
            }
        }

        static void DictionaryAdd(int time, int cash) 
        {
            if (count[time].ContainsKey(cash)) 
            {
                count[time][cash]++;
            } 
            else 
            {
                count[time].Add(cash, 1);
            }
        }
    }
}