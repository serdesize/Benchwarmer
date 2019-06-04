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
            Console.WriteLine("3: For Foreach");
            Console.WriteLine("Q: quit");
            Console.WriteLine();

            var loop = true;
            while (loop)
            {
                BaseTest test = null;
                Console.Write("Select tests: ");
                var c = Console.ReadLine();
                switch (c.ToLower())
                {
                    case "1":
                        test = new StructAndClass();
                        break;
                    case "2":
                        test = new Exceptions();
                        break;
                    case "3":
                        test = new ForForEach();
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
