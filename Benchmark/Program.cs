using Algorytmy;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmarks
{
    class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<SortingBenchmarkSmall>();
            BenchmarkRunner.Run<SortingBenchmarkMedium>();
            BenchmarkRunner.Run<SortingBenchmarkLarge>();
        }
    }
}