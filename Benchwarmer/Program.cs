using System;
using Benchwarmer.Tests;
using BenchWarmer.Tests;

namespace BenchWarmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tests------------");
            Console.WriteLine("1: Struct & Class");
            Console.WriteLine("2: Exceptions");
            Console.WriteLine("Q: quit");                


            var loop = true;
            while (loop)
            {
                Console.WriteLine();
                Console.Write("Select tests: ");
                BaseTest test = null;
                var c = Console.ReadLine();
                switch (c.ToLower())
                {
                    case "1":
                        test = new StructAndClass();
                        break;
                    case "2":
                        test = new Exceptions();
                        break;
                    case "q":
                        loop = false;
                        break;
                }

                test?.Run();
                test?.ShowResult();
            }
        }
    }
}
