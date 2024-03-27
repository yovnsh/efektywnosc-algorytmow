using BenchmarkDotNet.Attributes;
using Algorytmy;


namespace Benchmarks
{
    public class SortingBenchmarks
    {
        private readonly int[] random;
        private readonly int[] sorted;
        private readonly int[] reversed;
        private readonly int[] almostSorted;
        private readonly int[] fewUnique;

        private static ISortingAlgorithm[] algos = new ISortingAlgorithm[]
        {
            new InsertionSort(),
            new MergeSort(),
            new QuicksortClassic(),
            new QuicksortBuiltin(),
        };

        public static IEnumerable<ISortingAlgorithm> SortingAlgorithms()
        {
            foreach (var algo in algos)
            {
                yield return algo;
            }
        }
        
        public SortingBenchmarks(int dataSize)
        {
            random = Generators.GetRandom(dataSize);
            sorted = Generators.GetSorted(dataSize);
            reversed = Generators.GetReversed(dataSize);
            almostSorted = Generators.GetAlmostSorted(dataSize);
            fewUnique = Generators.GetFewUnique(dataSize);
        }

        [ParamsSource(nameof(SortingAlgorithms))]
        public ISortingAlgorithm Algorithm { get; set; }

        [Benchmark]
        public void Random()
        {
            Algorithm.Sort((int[])random.Clone());
        }

        [Benchmark]
        public void Sorted()
        {
            Algorithm.Sort((int[])sorted.Clone());
        }

        [Benchmark]
        public void Reversed()
        {
            Algorithm.Sort((int[])reversed.Clone());
        }

        [Benchmark]
        public void AlmostSorted()
        {
            Algorithm.Sort((int[])almostSorted.Clone());
        }

        [Benchmark]
        public void FewUnique()
        {
            Algorithm.Sort((int[])fewUnique.Clone());
        }
    }

    // vvv warianty dla małych, średnich i dużych zbiorów danych vvv
    public class SortingBenchmarkSmall : SortingBenchmarks
    {
        public const int DATA_SIZE = 10;

        public SortingBenchmarkSmall() : base(DATA_SIZE)
        {

        }
    }

    public class SortingBenchmarkMedium : SortingBenchmarks
    {
        public const int DATA_SIZE = 1_000;

        public SortingBenchmarkMedium() : base(DATA_SIZE)
        {

        }
    }

    public class SortingBenchmarkLarge : SortingBenchmarks
    {
        public const int DATA_SIZE = 100_000;

        public SortingBenchmarkLarge() : base(DATA_SIZE)
        {

        }
    }
}