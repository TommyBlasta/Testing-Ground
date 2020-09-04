using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingGround.Classes;
using TestingGround.Functions;

namespace TestingGround
{
    class Program
    {
        static void Main(string[] args)
        {
            //var hsh = new Hashing();
            //string pass = "admn";
            //var salt = hsh.GenerateSalt();
            //Console.WriteLine("Creating salt: {0}\nCreating hash: {1}\nFor pass {2}", salt, hsh.Hash(pass, salt), pass);
            //var hash = hsh.Hash(pass,salt);
            //Console.WriteLine(Convert.ToString(4,2));
            //Console.WriteLine(Convert.ToString(1, 2));
            //var test = new PointsEquation();
            //var array = new int[][]
            //{
            //    new int[] {-19,-12 },
            //    new int[]{-13,-18},
            //    new int[] { -12, 18 },
            //    new int[]{-11,-8},
            //    new int[] {-8,2},
            //    new int[] {-7,12},
            //    new int[] {-5,16},
            //    new int[] {-3,9},
            //    new int[] {1,-7},
            //    new int[] {5,-4},
            //    new int[] {6,-20},
            //    new int[] {10,4},
            //    new int[] {16,4},
            //    new int[] {19,-9},
            //    new int[] {20,19}
            //};
            //Console.WriteLine(test.FindMaxValueOfEquation(array, 6));
            //Console.WriteLine(string.Join(",", test.FilterArray(new object[] { 1, 2, "a", "b" })));
            //Console.WriteLine(string.Join(",", test.FilterArray(new object[] { 1, "a", "b", 0, 15 })));
            //Console.WriteLine(string.Join(",", test.FilterArray(new object[] { 1, 2, "aasf", "1", "123", 123 })));
            var test = new Kata();
            var test2 = new EdaBitMethods();
            //Console.WriteLine(EdaBitMethods.IsIsogram("Algorism"));
            //Console.WriteLine(EdaBitMethods.IsIsogram("PasSword"));
            //Console.WriteLine(EdaBitMethods.IsIsogram("Consecutive"));
            //Console.WriteLine(Kata.High("man i need a taxi up to ubud"));
            //Console.WriteLine(Kata.High("what time are we climbing up to the volcano"));
            //Console.WriteLine(Kata.High("take me to semynak"));
            //Console.WriteLine(Kata.IpsBetween("20.0.0.10", "20.0.1.0"));
            //Console.WriteLine(Kata.IpsBetween("10.0.0.0", "10.0.1.0"));
            //Console.WriteLine(Kata.IpsBetween("10.0.0.0", "10.0.0.50"));
            Kata.Determinant(new int[][] { new[] { 1, 2, 3 }, new[] { 4, 5, 6 }, new[] { 7, 8, 9 } });
            Console.ReadKey();
        }
    }
}
