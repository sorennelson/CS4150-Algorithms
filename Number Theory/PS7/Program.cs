using System;
using System.Collections.Generic;

namespace PS7
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                string[] split = line.Split(null);
                int a, b, x, y, N, p;
                System.Numerics.BigInteger keyp, q;
                switch (split[0])
                {
                    case "gcd":
                        int.TryParse(split[1], out a);
                        int.TryParse(split[2], out b);
                        Console.WriteLine(gcd((long)a, (long)b).ToString());
                        break;

                    case "exp":
                        int.TryParse(split[1], out x);
                        int.TryParse(split[2], out y);
                        int.TryParse(split[3], out N);
                        Console.WriteLine(exp(x, y, N).ToString());
                        break;

                    case "inverse":
                        int.TryParse(split[1], out a);
                        int.TryParse(split[2], out N);
                        System.Numerics.BigInteger inv = inverse(a, N);
                        Console.WriteLine(inv == 0 ? "none" : inv.ToString());
                        break;

                    case "isprime":
                        int.TryParse(split[1], out p);
                        Console.WriteLine(isprime(p));
                        break;

                    case "key":
                        System.Numerics.BigInteger.TryParse(split[1], out keyp);
                        System.Numerics.BigInteger.TryParse(split[2], out q);
                        System.Numerics.BigInteger[] k = key(keyp, q);
                        Console.WriteLine(k[0] + " " + k[1] + " " + k[2]);
                        break;
                }
            }

        }

        private static System.Numerics.BigInteger gcd(System.Numerics.BigInteger a, System.Numerics.BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a = mod(a, b);
                else
                    b = mod(b, a);
            }

            return a == 0 ? b : a;
        }

        private static System.Numerics.BigInteger exp(System.Numerics.BigInteger x, System.Numerics.BigInteger y, System.Numerics.BigInteger N)
        {
            if (y == 0)
            {
                return 1;
            }
            else
            {
                System.Numerics.BigInteger z = exp(x, y / 2, N);
                return mod(y, 2) == 0 ? mod(System.Numerics.BigInteger.Pow(z, 2), N) : mod(x * System.Numerics.BigInteger.Pow(z, 2), N);
            }

        }

        // returns a^-1 or 0 if it has no inverse
        private static System.Numerics.BigInteger inverse(System.Numerics.BigInteger a, System.Numerics.BigInteger N)
        {
            System.Numerics.BigInteger[] euclids = ee(a, N);
            return euclids[2] == 1 ? mod(euclids[0], (long)N) : 0;
        }

        private static System.Numerics.BigInteger[] ee(System.Numerics.BigInteger a, System.Numerics.BigInteger b)
        {
            if (b == 0)
            {
                return new System.Numerics.BigInteger[] { 1, 0, a };
            }
            System.Numerics.BigInteger[] r = ee(b, mod(a, b));
            return new System.Numerics.BigInteger[] { r[1], r[0] - (a / b) * r[1], r[2] };
        }

        //returns yes if if passes fermats, no otherwise
        private static string isprime(System.Numerics.BigInteger p)
        {
            bool fermat = fermatsTest(p);
            return fermat == true ? "yes" : "no";
        }

        private static bool fermatsTest(System.Numerics.BigInteger n)
        {
            System.Numerics.BigInteger power = exp(2, n - 1, n);
            if (power != 1) { return false; }

            power = exp(3, n - 1, n);
            if (power != 1) { return false; }

            power = exp(5, n - 1, n);
            if (power != 1) { return false; }

            return true;
        }

        private static System.Numerics.BigInteger[] key(System.Numerics.BigInteger p, System.Numerics.BigInteger q)
        {
            System.Numerics.BigInteger modulus = System.Numerics.BigInteger.Multiply(p, q);
            System.Numerics.BigInteger phi = System.Numerics.BigInteger.Multiply(p - 1, q - 1);
            System.Numerics.BigInteger e = 2;
            while (gcd(e, phi) != 1) { e++; }
            System.Numerics.BigInteger d = inverse(e, phi);
            return new System.Numerics.BigInteger[] { modulus, e, d };
        }

        private static long mod(long x, long m)
        {
            return (x % m + m) % m;
        }

        private static int mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        private static System.Numerics.BigInteger mod(System.Numerics.BigInteger x, int m)
        {
            return (x % m + m) % m;
        }

        private static System.Numerics.BigInteger mod(System.Numerics.BigInteger x, System.Numerics.BigInteger m)
        {
            return (x % m + m) % m;
        }
    }
}