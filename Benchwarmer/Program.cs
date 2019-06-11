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
            Console.WriteLine("4: String");
            Console.WriteLine("5: Unsafe ptr");
            Console.WriteLine("6: Generics");
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
                    case "4":
                        test = new StringStringBuilder();
                        break;
                    case "5":
                        test = new RawPointers();
                        break;
                    case "6":
                        test = new GenericsConcrete();
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
