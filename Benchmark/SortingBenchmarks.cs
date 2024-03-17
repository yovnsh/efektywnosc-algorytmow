using Algorytmy;
using BenchmarkDotNet.Attributes;

namespace Benchmarks
{
    public class SortingBenchmarks
    {
        const int ALMOST_SORTEDNESS = 10; // % elementów podmienionych
        const int UNIQUE_VALUES = 10; // ilość unikalnych elementów

        private readonly int[] random;
        private readonly int[] sorted;
        private readonly int[] reversed;
        private readonly int[] almostSorted;
        private readonly int[] fewUnique;

        private static ISortingAlgorithm[] algos = new ISortingAlgorithm[]
        {
            new InsertionSort(),
            new MergeSort(),
            new QuicksortClassical(),
            new QuicksortHeuristic(),
        };

        public static IEnumerable<ISortingAlgorithm> sortingAlgorithms()
        {
            foreach (var algo in algos)
            {
                yield return algo;
            }
        }
        
        public SortingBenchmarks(int dataSize)
        {
            random = new int[dataSize];
            sorted = new int[dataSize];
            reversed = new int[dataSize];
            almostSorted = new int[dataSize];
            fewUnique = new int[dataSize];

            var randomGenerator = new Random();

            for (int i = 0; i < dataSize; i++)
            {
                random[i] = randomGenerator.Next();
                sorted[i] = i;
                reversed[dataSize - i - 1] = i;
                almostSorted[i] = i;
                fewUnique[i] = randomGenerator.Next(0, UNIQUE_VALUES);
            }

            int elementsToSwap = dataSize * ALMOST_SORTEDNESS / 100;

            for (int i = 0; i < elementsToSwap; i++)
            {
                int index1 = randomGenerator.Next(0, dataSize);
                int index2 = randomGenerator.Next(0, dataSize);
                (almostSorted[index2], almostSorted[index1]) = (almostSorted[index1], almostSorted[index2]);
            }
        }

        [ParamsSource(nameof(sortingAlgorithms))]
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
        public SortingBenchmarkSmall() : base(10)
        {

        }
    }

    public class SortingBenchmarkMedium : SortingBenchmarks
    {
        public SortingBenchmarkMedium() : base(1_000)
        {

        }
    }

    public class SortingBenchmarkLarge : SortingBenchmarks
    {
        public SortingBenchmarkLarge() : base(100_000)
        {

        }
    }
}