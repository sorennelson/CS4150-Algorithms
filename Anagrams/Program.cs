using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace PS1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nArray = new List<int>(){ 10, 20, 40, 80, 160, 320, 640, 1280, 2560, 5120, 10000};
            List<int> kArray = new List<int>() { 10, 20, 40, 80, 160, 320, 640, 1280 };
            int n = 2000;
            double repititions = 100.0;
            List<double> times = new List<double>();
            foreach (int k in kArray) {
                times.Add(runExperimentForN(n, k, repititions));
            }
            Console.WriteLine(times);
        }

        static double runExperimentForN(int n, int k, double repititions) {
            
            double time = 0;
            Stopwatch sw = new Stopwatch();

            for (int i = 0; i < repititions; i++)
            {
                HashSet<string> words = new HashSet<string>();
                for (int w = 0; w < n; w++)
                {
                    words.Add(createWord(k));
                }

                sw.Restart();
                run(n, k, words);
                sw.Stop();
                time += msecs(sw);
            }
            return time / repititions;
        }


        static string createWord(int length) {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Random random = new Random();
            string word = "";

            for (int i = 0; i < length; i++) {
                word += alphabet[random.Next(26)];
            }
            return word;
        }


        static int run(int n, int k, HashSet<string> words)
        {
            HashSet<string> sols = new HashSet<string>();
            HashSet<string> rej = new HashSet<string>();

            foreach (string word in words)
            {
                string sortedWord = sortWord(word);

                if (sols.Contains(sortedWord))
                {
                    sols.Remove(sortedWord);
                    rej.Add(sortedWord);

                }
                else if (!rej.Contains(sortedWord))
                {
                    sols.Add(sortedWord);
                }
            }
            return sols.Count;
        }

        static string sortWord(string word) {
            char[] charArr = word.ToCharArray();
            Array.Sort(charArr);
            return new string(charArr);
        }

        static double msecs(Stopwatch sw)
        {
            return (((double)sw.ElapsedTicks) / Stopwatch.Frequency) * 1000;
        }

    }
}
