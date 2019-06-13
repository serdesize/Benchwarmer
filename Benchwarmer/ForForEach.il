.class public auto ansi beforefieldinit Benchwarmer.Tests.ForForEach
	extends BenchWarmer.Tests.BaseTest
{
	// Fields
	.field private initonly int32 OneMillion
	.field private initonly class [System.Runtime]System.Collections.Generic.IList`1<class BenchWarmer.Tests.BenchWarmerResult> _results
	.field private initonly class [System.Runtime]System.Text.StringBuilder _stringBuilder

	// Methods
	.method public hidebysig virtual 
		instance void ShowResult () cil managed 
	{
		// Method begins at RVA 0x24da
		// Code size 13 (0xd)
		.maxstack 8

		// 	Console.WriteLine(_stringBuilder);
		IL_0000: ldarg.0
		IL_0001: ldfld class [System.Runtime]System.Text.StringBuilder Benchwarmer.Tests.ForForEach::_stringBuilder
		IL_0006: call void [System.Console]System.Console::WriteLine(object)
		// (no C# code)
		IL_000b: nop
		IL_000c: ret
	} // end of method ForForEach::ShowResult

	.method public hidebysig virtual 
		instance void Run () cil managed 
	{
		// Method begins at RVA 0x24e8
		// Code size 23 (0x17)
		.maxstack 8

		// (no C# code)
		IL_0000: nop
		// 	TestForeach();
		IL_0001: ldarg.0
		IL_0002: call instance void Benchwarmer.Tests.ForForEach::TestForeach()
		// (no C# code)
		IL_0007: nop
		// 	TestFor();
		IL_0008: ldarg.0
		IL_0009: call instance void Benchwarmer.Tests.ForForEach::TestFor()
		// (no C# code)
		IL_000e: nop
		// 	BuildResult();
		IL_000f: ldarg.0
		IL_0010: callvirt instance void BenchWarmer.Tests.BaseTest::BuildResult()
		// (no C# code)
		IL_0015: nop
		IL_0016: ret
	} // end of method ForForEach::Run

	.method private hidebysig 
		instance void TestForeach () cil managed 
	{
		// Method begins at RVA 0x2500
		// Code size 169 (0xa9)
		.maxstack 5
		.locals init (
			[0] class [System.Runtime]System.Collections.Generic.IEnumerable`1<int32>,
			[1] int32,
			[2] int32[],
			[3] class [System.Runtime]System.Collections.Generic.IEnumerator`1<int32>,
			[4] int32,
			[5] bool
		)

		// (no C# code)
		IL_0000: nop
		// 	IEnumerable<int> enumerable = Enumerable.Range(0, OneMillion);
		IL_0001: ldc.i4.0
		IL_0002: ldarg.0
		IL_0003: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
		IL_0008: call class [System.Runtime]System.Collections.Generic.IEnumerable`1<int32> [System.Linq]System.Linq.Enumerable::Range(int32, int32)
		IL_000d: stloc.0
		// 	base.Watch.Restart();
		IL_000e: ldarg.0
		IL_000f: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_0014: callvirt instance void [System.Runtime.Extensions]System.Diagnostics.Stopwatch::Restart()
		// (no C# code)
		IL_0019: nop
		// 	for (int i = 0; i < 10; i++)
		IL_001a: ldc.i4.0
		IL_001b: stloc.1
		// (no C# code)
		IL_001c: br.s IL_005e
		// loop start (head: IL_005e)
			IL_001e: nop
			// 		int[] array = new int[OneMillion];
			IL_001f: ldarg.0
			IL_0020: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
			IL_0025: newarr [System.Runtime]System.Int32
			IL_002a: stloc.2
			// (no C# code)
			IL_002b: nop
			// 		foreach (int item in enumerable)
			IL_002c: ldloc.0
			IL_002d: callvirt instance class [System.Runtime]System.Collections.Generic.IEnumerator`1<!0> class [System.Runtime]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
			// (no C# code)
			IL_0032: stloc.3
			.try
			{
				IL_0033: br.s IL_0044
				// loop start (head: IL_0044)
					// 		foreach (int item in enumerable)
					IL_0035: ldloc.3
					IL_0036: callvirt instance !0 class [System.Runtime]System.Collections.Generic.IEnumerator`1<int32>::get_Current()
					// (no C# code)
					IL_003b: stloc.s 4
					IL_003d: nop
					// 			int num = array[i] = item;
					IL_003e: ldloc.2
					IL_003f: ldloc.1
					// (no C# code)
					IL_0040: ldloc.s 4
					IL_0042: stelem.i4
					IL_0043: nop

					// 		foreach (int item in enumerable)
					IL_0044: ldloc.3
					IL_0045: callvirt instance bool [System.Runtime]System.Collections.IEnumerator::MoveNext()
					// (no C# code)
					IL_004a: brtrue.s IL_0035
				// end loop

				IL_004c: leave.s IL_0059
			} // end .try
			finally
			{
				IL_004e: ldloc.3
				IL_004f: brfalse.s IL_0058

				IL_0051: ldloc.3
				IL_0052: callvirt instance void [System.Runtime]System.IDisposable::Dispose()
				IL_0057: nop

				IL_0058: endfinally
			} // end handler

			IL_0059: nop
			// 	for (int i = 0; i < 10; i++)
			IL_005a: ldloc.1
			IL_005b: ldc.i4.1
			IL_005c: add
			IL_005d: stloc.1

			// 	for (int i = 0; i < 10; i++)
			IL_005e: ldloc.1
			IL_005f: ldc.i4.s 10
			IL_0061: clt
			IL_0063: stloc.s 5
			// (no C# code)
			IL_0065: ldloc.s 5
			IL_0067: brtrue.s IL_001e
		// end loop

		// 	base.Watch.Stop();
		IL_0069: ldarg.0
		IL_006a: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_006f: callvirt instance void [System.Runtime.Extensions]System.Diagnostics.Stopwatch::Stop()
		// (no C# code)
		IL_0074: nop
		// 	_results.Add(new BenchWarmerResult
		// 	{
		// 		Name = "Foreach",
		// 		ElapsedMiliseconds = base.Watch.ElapsedMilliseconds / 10
		// 	});
		IL_0075: ldarg.0
		IL_0076: ldfld class [System.Runtime]System.Collections.Generic.IList`1<class BenchWarmer.Tests.BenchWarmerResult> Benchwarmer.Tests.ForForEach::_results
		IL_007b: newobj instance void BenchWarmer.Tests.BenchWarmerResult::.ctor()
		IL_0080: dup
		IL_0081: ldstr "Foreach"
		IL_0086: callvirt instance void BenchWarmer.Tests.BenchWarmerResult::set_Name(string)
		// (no C# code)
		IL_008b: nop
		IL_008c: dup
		IL_008d: ldarg.0
		IL_008e: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_0093: callvirt instance int64 [System.Runtime.Extensions]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
		IL_0098: ldc.i4.s 10
		IL_009a: conv.i8
		IL_009b: div
		IL_009c: callvirt instance void BenchWarmer.Tests.BenchWarmerResult::set_ElapsedMiliseconds(int64)
		IL_00a1: nop
		IL_00a2: callvirt instance void class [System.Runtime]System.Collections.Generic.ICollection`1<class BenchWarmer.Tests.BenchWarmerResult>::Add(!0)
		IL_00a7: nop
		IL_00a8: ret
	} // end of method ForForEach::TestForeach

	.method private hidebysig 
		instance void TestFor () cil managed 
	{
		// Method begins at RVA 0x25c8
		// Code size 187 (0xbb)
		.maxstack 5
		.locals init (
			[0] int32[],
			[1] int32,
			[2] bool,
			[3] int32,
			[4] int32[],
			[5] int32,
			[6] bool,
			[7] bool
		)

		// (no C# code)
		IL_0000: nop
		// 	int[] array = new int[OneMillion];
		IL_0001: ldarg.0
		IL_0002: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
		IL_0007: newarr [System.Runtime]System.Int32
		IL_000c: stloc.0
		// 	for (int i = 0; i < OneMillion; i++)
		IL_000d: ldc.i4.0
		IL_000e: stloc.1
		// (no C# code)
		IL_000f: br.s IL_001b
		// loop start (head: IL_001b)
			IL_0011: nop
			// 		array[i] = i;
			IL_0012: ldloc.0
			IL_0013: ldloc.1
			IL_0014: ldloc.1
			IL_0015: stelem.i4
			// (no C# code)
			IL_0016: nop
			// 	for (int i = 0; i < OneMillion; i++)
			IL_0017: ldloc.1
			IL_0018: ldc.i4.1
			IL_0019: add
			IL_001a: stloc.1

			// 	for (int i = 0; i < OneMillion; i++)
			IL_001b: ldloc.1
			IL_001c: ldarg.0
			IL_001d: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
			IL_0022: clt
			IL_0024: stloc.2
			// (no C# code)
			IL_0025: ldloc.2
			IL_0026: brtrue.s IL_0011
		// end loop

		// 	base.Watch.Restart();
		IL_0028: ldarg.0
		IL_0029: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_002e: callvirt instance void [System.Runtime.Extensions]System.Diagnostics.Stopwatch::Restart()
		// (no C# code)
		IL_0033: nop
		// 	for (int j = 0; j < 10; j++)
		IL_0034: ldc.i4.0
		IL_0035: stloc.3
		// (no C# code)
		IL_0036: br.s IL_0070
		// loop start (head: IL_0070)
			IL_0038: nop
			// 		int[] array2 = new int[OneMillion];
			IL_0039: ldarg.0
			IL_003a: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
			IL_003f: newarr [System.Runtime]System.Int32
			IL_0044: stloc.s 4
			// 		for (int k = 0; k < OneMillion; k++)
			IL_0046: ldc.i4.0
			IL_0047: stloc.s 5
			// (no C# code)
			IL_0049: br.s IL_005b
			// loop start (head: IL_005b)
				IL_004b: nop
				// 			array2[j] = array[k];
				IL_004c: ldloc.s 4
				IL_004e: ldloc.3
				IL_004f: ldloc.0
				IL_0050: ldloc.s 5
				IL_0052: ldelem.i4
				IL_0053: stelem.i4
				// (no C# code)
				IL_0054: nop
				// 		for (int k = 0; k < OneMillion; k++)
				IL_0055: ldloc.s 5
				IL_0057: ldc.i4.1
				IL_0058: add
				IL_0059: stloc.s 5

				// 		for (int k = 0; k < OneMillion; k++)
				IL_005b: ldloc.s 5
				IL_005d: ldarg.0
				IL_005e: ldfld int32 Benchwarmer.Tests.ForForEach::OneMillion
				IL_0063: clt
				IL_0065: stloc.s 6
				// (no C# code)
				IL_0067: ldloc.s 6
				IL_0069: brtrue.s IL_004b
			// end loop

			IL_006b: nop
			// 	for (int j = 0; j < 10; j++)
			IL_006c: ldloc.3
			IL_006d: ldc.i4.1
			IL_006e: add
			IL_006f: stloc.3

			// 	for (int j = 0; j < 10; j++)
			IL_0070: ldloc.3
			IL_0071: ldc.i4.s 10
			IL_0073: clt
			IL_0075: stloc.s 7
			// (no C# code)
			IL_0077: ldloc.s 7
			IL_0079: brtrue.s IL_0038
		// end loop

		// 	base.Watch.Stop();
		IL_007b: ldarg.0
		IL_007c: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_0081: callvirt instance void [System.Runtime.Extensions]System.Diagnostics.Stopwatch::Stop()
		// (no C# code)
		IL_0086: nop
		// 	_results.Add(new BenchWarmerResult
		// 	{
		// 		Name = "For",
		// 		ElapsedMiliseconds = base.Watch.ElapsedMilliseconds / 10
		// 	});
		IL_0087: ldarg.0
		IL_0088: ldfld class [System.Runtime]System.Collections.Generic.IList`1<class BenchWarmer.Tests.BenchWarmerResult> Benchwarmer.Tests.ForForEach::_results
		IL_008d: newobj instance void BenchWarmer.Tests.BenchWarmerResult::.ctor()
		IL_0092: dup
		IL_0093: ldstr "For"
		IL_0098: callvirt instance void BenchWarmer.Tests.BenchWarmerResult::set_Name(string)
		// (no C# code)
		IL_009d: nop
		IL_009e: dup
		IL_009f: ldarg.0
		IL_00a0: call instance class [System.Runtime.Extensions]System.Diagnostics.Stopwatch BenchWarmer.Tests.BaseTest::get_Watch()
		IL_00a5: callvirt instance int64 [System.Runtime.Extensions]System.Diagnostics.Stopwatch::get_ElapsedMilliseconds()
		IL_00aa: ldc.i4.s 10
		IL_00ac: conv.i8
		IL_00ad: div
		IL_00ae: callvirt instance void BenchWarmer.Tests.BenchWarmerResult::set_ElapsedMiliseconds(int64)
		IL_00b3: nop
		IL_00b4: callvirt instance void class [System.Runtime]System.Collections.Generic.ICollection`1<class BenchWarmer.Tests.BenchWarmerResult>::Add(!0)
		IL_00b9: nop
		IL_00ba: ret
	} // end of method ForForEach::TestFor

	.method public hidebysig virtual 
		instance void BuildResult () cil managed 
	{
		// Method begins at RVA 0x2690
		// Code size 128 (0x80)
		.maxstack 4
		.locals init (
			[0] class [System.Runtime]System.Collections.Generic.IEnumerator`1<class BenchWarmer.Tests.BenchWarmerResult>,
			[1] class BenchWarmer.Tests.BenchWarmerResult
		)

		// (no C# code)
		IL_0000: nop
		// 	_stringBuilder.AppendLine().AppendLine().AppendLine("********* [ ForForEach ] *********")
		// 		.AppendLine("  iterate over 1 million objects")
		// 		.AppendLine();
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Runtime]System.Text.StringBuilder Benchwarmer.Tests.ForForEach::_stringBuilder
		IL_0007: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine()
		IL_000c: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine()
		IL_0011: ldstr "********* [ ForForEach ] *********"
		IL_0016: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine(string)
		IL_001b: ldstr "  iterate over 1 million objects"
		IL_0020: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine(string)
		IL_0025: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine()
		IL_002a: pop
		// (no C# code)
		IL_002b: nop
		// 	foreach (BenchWarmerResult result in _results)
		IL_002c: ldarg.0
		IL_002d: ldfld class [System.Runtime]System.Collections.Generic.IList`1<class BenchWarmer.Tests.BenchWarmerResult> Benchwarmer.Tests.ForForEach::_results
		IL_0032: callvirt instance class [System.Runtime]System.Collections.Generic.IEnumerator`1<!0> class [System.Runtime]System.Collections.Generic.IEnumerable`1<class BenchWarmer.Tests.BenchWarmerResult>::GetEnumerator()
		// (no C# code)
		IL_0037: stloc.0
		.try
		{
			IL_0038: br.s IL_006a
			// loop start (head: IL_006a)
				// 	foreach (BenchWarmerResult result in _results)
				IL_003a: ldloc.0
				IL_003b: callvirt instance !0 class [System.Runtime]System.Collections.Generic.IEnumerator`1<class BenchWarmer.Tests.BenchWarmerResult>::get_Current()
				// (no C# code)
				IL_0040: stloc.1
				IL_0041: nop
				// 		_stringBuilder.AppendLine(string.Format("{0, -15} {1, 5}ms", result.Name, result.ElapsedMiliseconds));
				IL_0042: ldarg.0
				IL_0043: ldfld class [System.Runtime]System.Text.StringBuilder Benchwarmer.Tests.ForForEach::_stringBuilder
				IL_0048: ldstr "{0, -15} {1, 5}ms"
				IL_004d: ldloc.1
				IL_004e: callvirt instance string BenchWarmer.Tests.BenchWarmerResult::get_Name()
				IL_0053: ldloc.1
				IL_0054: callvirt instance int64 BenchWarmer.Tests.BenchWarmerResult::get_ElapsedMiliseconds()
				IL_0059: box [System.Runtime]System.Int64
				IL_005e: call string [System.Runtime]System.String::Format(string, object, object)
				IL_0063: callvirt instance class [System.Runtime]System.Text.StringBuilder [System.Runtime]System.Text.StringBuilder::AppendLine(string)
				IL_0068: pop
				// (no C# code)
				IL_0069: nop

				// 	foreach (BenchWarmerResult result in _results)
				IL_006a: ldloc.0
				IL_006b: callvirt instance bool [System.Runtime]System.Collections.IEnumerator::MoveNext()
				// (no C# code)
				IL_0070: brtrue.s IL_003a
			// end loop

			IL_0072: leave.s IL_007f
		} // end .try
		finally
		{
			IL_0074: ldloc.0
			IL_0075: brfalse.s IL_007e

			IL_0077: ldloc.0
			IL_0078: callvirt instance void [System.Runtime]System.IDisposable::Dispose()
			IL_007d: nop

			IL_007e: endfinally
		} // end handler

		IL_007f: ret
	} // end of method ForForEach::BuildResult

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x272c
		// Code size 41 (0x29)
		.maxstack 8

		// 	OneMillion = 1000000;
		IL_0000: ldarg.0
		IL_0001: ldc.i4 1000000
		IL_0006: stfld int32 Benchwarmer.Tests.ForForEach::OneMillion
		// 	_results = new List<BenchWarmerResult>();
		IL_000b: ldarg.0
		IL_000c: newobj instance void class [System.Collections]System.Collections.Generic.List`1<class BenchWarmer.Tests.BenchWarmerResult>::.ctor()
		IL_0011: stfld class [System.Runtime]System.Collections.Generic.IList`1<class BenchWarmer.Tests.BenchWarmerResult> Benchwarmer.Tests.ForForEach::_results
		// 	_stringBuilder = new StringBuilder();
		IL_0016: ldarg.0
		IL_0017: newobj instance void [System.Runtime]System.Text.StringBuilder::.ctor()
		IL_001c: stfld class [System.Runtime]System.Text.StringBuilder Benchwarmer.Tests.ForForEach::_stringBuilder
		// 	base..ctor();
		IL_0021: ldarg.0
		IL_0022: call instance void BenchWarmer.Tests.BaseTest::.ctor()
		// (no C# code)
		IL_0027: nop
		IL_0028: ret
	} // end of method ForForEach::.ctor

} // end of class Benchwarmer.Tests.ForForEach
