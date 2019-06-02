using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BenchWarmer
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
            var average = 10;
            long sum = 0;
            for (var i = 0; i < 10; i++)
            {
                Watch.Restart();
                var list = new AStruct[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AStruct(i);
                }
                Watch.Stop();
                sum += Watch.ElapsedTicks;
            }

            _results.Add(new BenchWarmerResult { Name = "Struct" , Ticks = Watch.ElapsedTicks / average });
        }

        private void TestClass()
        {
            var average = 10;
            long sum = 0;
            for (var i = 0; i < 10; i++)
            {
                Watch.Restart();
                var list = new AClass[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AClass(i);
                }
                Watch.Stop();
                sum += Watch.ElapsedTicks;
            }

            _results.Add(new BenchWarmerResult { Name = "Class", Ticks = Watch.ElapsedTicks / average });
        }

        private void TestFinalizedClass()
        {
            var average = 10;
            long sum = 0;
            for (var i = 0; i < 10; i++)
            {
                Watch.Restart();
                var list = new AClassFinalized[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AClassFinalized(i);
                }
                Watch.Stop();
                sum += Watch.ElapsedTicks;
            }

            _results.Add(new BenchWarmerResult { Name = "Finalized Class", Ticks = Watch.ElapsedTicks / average });
        }

        private void TestBoxingStruct()
        {
            var average = 10;
            long sum = 0;
            for (var i = 0; i < 10; i++)
            {
                Watch.Restart();
                var list = new AComplexStruct[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = new AComplexStruct(i);
                }
                Watch.Stop();
                sum += Watch.ElapsedTicks;
            }

            _results.Add(new BenchWarmerResult { Name = "Boxed Struct", Ticks = Watch.ElapsedTicks / average });
        }

        private void BuildResult()
        {
            _stringBuilder
                .AppendLine($"********* [ {nameof(StructAndClass)} ] *********")
                .AppendLine($"  fill list ( struct, class )")
                .AppendLine($"  > 1 million objs")
                .AppendLine($"  > 10 times")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.Ticks / TimeSpan.TicksPerMillisecond));
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
