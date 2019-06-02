using System;
using System.Diagnostics;

namespace BenchWarmer.Tests
{
    public abstract class BaseTest
    {
        public Stopwatch Watch { get; } = new Stopwatch();

        public abstract void ShowResult();
        public abstract void Run();
        public abstract void BuildResult();
    }
}
