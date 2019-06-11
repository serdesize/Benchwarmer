using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using BenchWarmer.Tests;

namespace Benchwarmer.Tests
{
    public class RawPointers : BaseTest
    {
        private static readonly int TwoHundredThousand = 200000;

        private readonly IList<BenchWarmerResult> _results = new List<BenchWarmerResult>();
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public override void ShowResult() => Console.WriteLine(_stringBuilder);
        public override void Run()
        {
            TestSlowStruct();
            TestUnamanaged();

            BuildResult();
        }

        private void TestSlowStruct()
        {
            var ptrs = new IntPtr[10];
            Watch.Restart();

            for (var j = 0; j < 10; j++)
            {
                var buffer = new AStruct[TwoHundredThousand];
                ptrs[j] = GCHandle.Alloc(buffer, GCHandleType.Pinned).AddrOfPinnedObject();
                for (int i = 0; i < TwoHundredThousand; i++)
                {
                    buffer[i] = new AStruct { Property = i };
                }
            }

            Watch.Stop();

            Console.WriteLine($"{nameof(TestUnamanaged)}");
            foreach (var ptr in ptrs)
            {
                Console.WriteLine(ptr.ToString());
            }

            _results.Add(new BenchWarmerResult { Name = "Managed Struct", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        private void TestUnamanaged()
        {
            unsafe
            {
                var ptrs = new AStruct*[10];
                Watch.Restart();

                for (var j = 0; j < 10; j++)
                {
                    var buffer = stackalloc AStruct[TwoHundredThousand];
                    ptrs[j] = buffer;

                    for (int i = 0; i < TwoHundredThousand; i++)
                    {
                        buffer[i] = new AStruct{ Property = i };
                    }
                }

                Watch.Stop();

                Console.WriteLine($"{nameof(TestUnamanaged)}");
                foreach (var ptr in ptrs)
                {
                    Console.WriteLine(((IntPtr)ptr).ToString());
                }

                Console.WriteLine($"{ptrs[0]->Property} {ptrs[1]->Property} {ptrs[2]->Property} {ptrs[3]->Property} {ptrs[4]->Property} {ptrs[5]->Property} {ptrs[6]->Property} {ptrs[7]->Property} {ptrs[8]->Property} {ptrs[9]->Property}");

                AStruct* memPtr = ptrs[0];
                var varThatIWant = 9999;
                var aPtr = memPtr + varThatIWant;
                Console.WriteLine($"{aPtr->Property} exp: 9999");
                Console.WriteLine($"{sizeof(AStruct)} bytes");
            }

            _results.Add(new BenchWarmerResult { Name = "Unmanaged", ElapsedMiliseconds = Watch.ElapsedMilliseconds / 10 });
        }

        public override void BuildResult()
        {
            _stringBuilder
                .AppendLine()
                .AppendLine()
                .AppendLine($"********* [ {nameof(RawPointers)} ] *********")
                .AppendLine();

            foreach (var res in _results)
            {
                _stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", res.Name, res.ElapsedMiliseconds));
            }
        }

        struct AStruct
        {
            public int Property { get; set; }
        }

        class AClass
        {
            public int Property { get; set; }
        }
    }
}
