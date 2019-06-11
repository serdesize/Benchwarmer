using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchWarmer.Tests;

namespace Benchwarmer.Tests
{
    public class ForForEach : BaseTest
    {
        private readonly int OneMillion = 1000000;

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder);
        public override void Run()
        {
            TestForeach();
            TestFor();

            BuildResult();
        }

        private void TestForeach()
        {
            var oneMillionInts = Enumerable.Range(0, OneMillion);
            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new int [OneMillion];
                foreach (var j in oneMillionInts)
                {
                    list[i] = j;
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Foreach", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestFor()
        {
            var tmp = new int[OneMillion];
            for (var k = 0; k < OneMillion; k++)
            {
                tmp[k] = k;
            }

            Watch.Restart();
            for (var i = 0; i < 10; i++)
            {
                var list = new int[OneMillion];
                for (var j = 0; j < OneMillion; j++)
                {
                    list[i] = tmp[j];
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "For", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(ForForEach)} ] *********")
                .AppendLine($"  iterate over 1 million objects")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.ElapsedMiliseconds));
            }
        }

    }
}
