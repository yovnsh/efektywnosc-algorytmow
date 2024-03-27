using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorytmy;
using Benchmarks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Serialization;

namespace Testy
{
    public class TestArrays
    {
        public int[] Random;
        public int[] Sorted;
        public int[] Reversed;
        public int[] FewUnique;
        public int[] AlmostSorted;

        public TestArrays Clone()
        {
            return new TestArrays
            {
                Random = (int[])Random.Clone(),
                Sorted = (int[])Sorted.Clone(),
                Reversed = (int[])Reversed.Clone(),
                FewUnique = (int[])FewUnique.Clone(),
                AlmostSorted = (int[])AlmostSorted.Clone()
            };
        }

        public TestArrays() {}

        public TestArrays(int size)
        {
            Random = Generators.GetRandom(size);
            Sorted = Generators.GetSorted(size);
            Reversed = Generators.GetReversed(size);
            FewUnique = Generators.GetFewUnique(size);
            AlmostSorted = Generators.GetAlmostSorted(size);
        }

        public delegate void SortDelegate(int[] array);

        public void SortAll(SortDelegate function)
        {
            function(Random);
            function(Sorted);
            function(Reversed);
            function(FewUnique);
            function(AlmostSorted);
        }

        public bool IsSorted()
        {
            return IsSorted(Random) && IsSorted(Sorted) && IsSorted(Reversed) && IsSorted(FewUnique) && IsSorted(AlmostSorted);
        }

        private static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }
            return true;
        }
    }

    [TestClass]
    public class AlgorithmTest
    {
        // jednorazowo wygenerowane tablice na potrzeby testów
        // ka¿dy test robi w³asn¹ kopiê zestawu danych
        // rozmiar danych => zestaw danych
        static TestArrays testData;

        [ClassInitialize]
        public static void GenerateData(TestContext yep)
        {
            testData = new TestArrays(SortingBenchmarkLarge.DATA_SIZE);
        }

        [TestMethod]
        public void TestInsertionSort()
        {
            var dataCopy = testData.Clone();
            ISortingAlgorithm insertionSort = new InsertionSort();

            dataCopy.SortAll(insertionSort.Sort);

            Assert.IsTrue(dataCopy.IsSorted());
        }

        [DataTestMethod]
        public void TestMergeSort()
        {
            var dataCopy = testData.Clone();
            ISortingAlgorithm mergeSort = new MergeSort();

            dataCopy.SortAll(mergeSort.Sort);

            Assert.IsTrue(dataCopy.IsSorted());
        }

        const int QUICKSORT_ATTEMPTS = 5; // liczba prób które musi przejœæ quicksort aby uznaæ go za dzia³aj¹cy

        [DataTestMethod]
        public void TestQuicksortClassic()
        {
            // quicksort jest bardzo delikatny
            // lepiej przeprowadziæ kilka podejœæ ¿eby mieæ pewnoœæ
            for(int n = 0; n < QUICKSORT_ATTEMPTS; n++)
            {
                var dataCopy = testData.Clone();
                ISortingAlgorithm quickSort = new QuicksortClassic();

                dataCopy.SortAll(quickSort.Sort);

                Assert.IsTrue(dataCopy.IsSorted());
            }
        }

        [DataTestMethod]
        public void TestQuicksortBuiltin()
        {
            var dataCopy = testData.Clone();
            ISortingAlgorithm quickSort = new QuicksortBuiltin();

            dataCopy.SortAll(quickSort.Sort);

            Assert.IsTrue(dataCopy.IsSorted());
        }
    }
}