using System;
using System.Collections.Generic;
using System.Text;

namespace BenchWarmer.Tests
{
    public class StructAndClass : BaseTest
    {
        private readonly int OneMillion = 1000000;

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder);
        public override void Run()
        {
            TestStruct();

            TestClass();

            TestFinalizedClass();

            TestBoxingStruct();

            BuildResult();
        }

        private void TestStruct()
        {
            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new AStruct[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AStruct(i);
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Struct" , ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestClass()
        {
            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new AClass[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AClass(i);
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Class", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestFinalizedClass()
        {
            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new AClassFinalized[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AClassFinalized(i);
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Finalized Class", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestBoxingStruct()
        {
            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new AComplexStruct[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AComplexStruct(i);
                }
            }
            Watch.Stop();
             
            _results.Add(new BenchWarmerResult { Name = "Boxed Struct", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(StructAndClass)} ] *********")
                .AppendLine($"  fill list ( struct, class )")
                .AppendLine($"  > 1 million objs")
                .AppendLine($"  > average of 10 times")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.ElapsedMiliseconds));
            }
        }

        class AClass
        {
            public int X { get; set; }

            public AClass(int x)
            {
                X = x;
            }
        }

        class AClassFinalized
        {
            public int X { get; set; }

            public AClassFinalized(int x)
            {
                X = x;
            }

            ~AClassFinalized()
            {
                // do nothing
            }
        }

        struct AStruct
        {
            public int X { get; set; }

            public AStruct(int x)
            {
                X = x;
            }
        }

        struct AComplexStruct
        {
            public object X { get; set; }

            public AComplexStruct(object x)
            {
                X = x;
            }
        }
    }
}
