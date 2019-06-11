using System;
using System.Collections.Generic;
using System.Text;
using BenchWarmer.Tests;

namespace Benchwarmer.Tests
{
    public class StringStringBuilder : BaseTest
    {
        private readonly int OneMillion = 1000000;
        private readonly string[] Alphabet =
        {
            "a", "b", "c", "d", "e", "f", "g",
            "h", "i", "j", "k", "l", "m", "n",
            "o", "p", "q", "r", "s", "t", "u",
            "v", "w", "x", "y", "z"
        };

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder); 
        public override void Run()
        {
            TestString();

            TestStringBuilder();

            BuildResult();
        }

        private void TestString()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);

            Watch.Restart();
            var str = "";
            for (var i = 0; i < OneMillion; i++)
            {
                var randomNumber = randomizer.Next(0, 26);
                str += Alphabet[randomNumber];
            }

            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "String", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestStringBuilder()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);

            Watch.Restart();
            var str = new StringBuilder();
            for (var i = 0; i < OneMillion; i++)
            {
                var randomNumber = randomizer.Next(0, 26);
                str.Append(Alphabet[randomNumber]);
            }

            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "String Builder", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(StringStringBuilder)} ] *********")
                .AppendLine($"  create string with one million character")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.ElapsedMiliseconds));
            }
        }
    }
}
