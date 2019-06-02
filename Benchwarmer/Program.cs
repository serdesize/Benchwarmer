using System;

namespace BenchWarmer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tests------------");
            Console.WriteLine("1: Struct & Class");


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
