using System;
using System.Collections.Generic;
using System.Text;
using BenchWarmer.Tests;

namespace Benchwarmer.Tests
{
    public class GenericsConcrete : BaseTest
    {
        private readonly int OneMillion = 1000000;

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder);
        public override void Run()
        {
            TestConcreteClass();
            TestGenericClass();            

            BuildResult();
        }

        private void TestConcreteClass()
        {
            var list = new List<ConcreteClass>();

            Watch.Restart();
            for (var i = 0; i < OneMillion; i++)
            {
                list.Add(new ConcreteClass(i));
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Concrete Class", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10  });
        }

        private void TestGenericClass()
        {
            var list = new List<GenericClass<int>>();

            Watch.Restart();
            for (var i = 0; i < OneMillion; i++)
            {
                list.Add(new GenericClass<int>(i));
            }
            Watch.Stop();

            _results.Add(new BenchWarmerResult { Name = "Generic Class", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(GenericsConcrete)} ] *********")
                .AppendLine($"  fill list ( struct, class )")
                .AppendLine($"  > 1 million objs")
                .AppendLine($"  > average of 10 times")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.ElapsedMiliseconds));
            }
        }
    }

    class ConcreteClass
    {
        public int PropI { get; set; }
        public ConcreteClass(int i)
        {
            PropI = i;
        }
    }

    class GenericClass<T>
    {
        public T PropT { get; set; }
        public GenericClass(T t)
        {
            PropT = t;
        }
    }

    struct MyStruct
    {
        public int PropS { get; set; }
        public MyStruct(int s)
        {
            PropS = s;
        }
    }

    struct GenericStruct<T>
    {
        public T PropV { get; set; }
        public GenericStruct(T v)
        {
            PropV = v;
        }
    }
}
