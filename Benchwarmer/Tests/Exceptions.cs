using System;
using System.Collections.Generic;
using System.Text;
using BenchWarmer.Tests;

namespace Benchwarmer.Tests
{
    public class Exceptions : BaseTest
    {
        private readonly int OneMillion = 1000000;

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder);

        public override void Run()
        {
            
            TestNoException();
            TestNoExceptionWithinTryCatch();
            TestThrowingException();
            TestThrowingException2();

            BuildResult();
        }

        private void TestNoException()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);
            var randomNumber = randomizer.Next(0, OneMillion);

            Watch.Restart();
            var list = new int[OneMillion];
            for (var i = 0; i < OneMillion; i++)
            {
                if (i == randomNumber)
                {
                    int.TryParse($"{i}", out int digit);
                    list[i] = digit;
                }
                else
                {
                    list[i] = i;
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "No Exception", ElapsedMiliseconds = Watch.ElapsedMilliseconds });
        }

        private void TestNoExceptionWithinTryCatch()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);
            var randomNumber = randomizer.Next(0, OneMillion);

            Watch.Restart();
            var list = new int[OneMillion];
            for (var i = 0; i < OneMillion; i++)
            {
                try
                {
                    if (i == randomNumber)
                    {
                        int.TryParse($"{i}", out int digit);
                        list[i] = digit;
                    }
                    else
                    {
                        list[i] = i;
                    }
                }
                catch (FormatException)
                {

                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "No Exception 2", ElapsedMiliseconds = Watch.ElapsedMilliseconds });
        }

        private void TestThrowingException()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);
            var randomNumber = randomizer.Next(0, OneMillion);

            Watch.Restart();
            var list = new int[OneMillion];
            for (var i = 0; i < OneMillion; i++)
            {
                try
                {
                    if (i == randomNumber)
                    {
                        var digit = int.Parse("*");
                        // this will throw
                    }
                    else
                    {
                        list[i] = i;
                    }
                }
                catch (FormatException)
                {
                    list[i] = 0;
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Throw Exception", ElapsedMiliseconds = Watch.ElapsedMilliseconds });
        }

        private void TestThrowingException2()
        {
            var randomizer = new Random(DateTime.Now.Millisecond);
            var randomNumber = randomizer.Next(0, OneMillion);

            Watch.Restart();
            var list = new int[OneMillion];
            for (var i = 0; i < OneMillion; i++)
            {
                try
                {
                    if (i % randomNumber == 8)
                    {
                        var digit = int.Parse("*");
                        // this will throw
                    }
                    else
                    {
                        list[i] = i;
                    }
                }
                catch (FormatException)
                {
                    list[i] = 0;
                }
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Throw Exception 2", ElapsedMiliseconds = Watch.ElapsedMilliseconds });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(Exceptions)} ] *********")
                .AppendLine($"  fill list of int, convert them to string ")
                .AppendLine($"  and parse them with integer static function")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -20} {1, 7}ms", res.Name, res.ElapsedMiliseconds));
            }
        }
    }
}
