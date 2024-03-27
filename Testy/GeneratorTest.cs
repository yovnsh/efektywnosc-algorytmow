using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benchmarks;

namespace Testy
{
    [TestClass]
    public class GeneratorTest
    {

        [DataRow(SortingBenchmarkSmall.DATA_SIZE)]
        [DataRow(SortingBenchmarkMedium.DATA_SIZE)]
        [DataRow(SortingBenchmarkLarge.DATA_SIZE)]
        [DataTestMethod]
        public void TestRandom(int dataSize)
        {
            var array = Generators.GetRandom(dataSize);

            Assert.AreEqual(dataSize, array.Length);
            // nic wiêcej nie mo¿na zrobiæ
        }

        [DataRow(SortingBenchmarkSmall.DATA_SIZE)]
        [DataRow(SortingBenchmarkMedium.DATA_SIZE)]
        [DataRow(SortingBenchmarkLarge.DATA_SIZE)]
        [DataTestMethod]
        public void TestSorted(int dataSize)
        {
            var array = Generators.GetSorted(dataSize);

            Assert.AreEqual(dataSize, array.Length);
            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsTrue(array[i] <= array[i + 1]);
            }
        }

        [DataRow(SortingBenchmarkSmall.DATA_SIZE)]
        [DataRow(SortingBenchmarkMedium.DATA_SIZE)]
        [DataRow(SortingBenchmarkLarge.DATA_SIZE)]
        [DataTestMethod]
        public void TestReversed(int dataSize)
        {
            var array = Generators.GetReversed(dataSize);

            Assert.AreEqual(dataSize, array.Length);
            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsTrue(array[i] >= array[i + 1]);
            }
        }

        [DataRow(SortingBenchmarkSmall.DATA_SIZE)]
        [DataRow(SortingBenchmarkMedium.DATA_SIZE)]
        [DataRow(SortingBenchmarkLarge.DATA_SIZE)]
        [DataTestMethod]
        public void TestAlmostSorted(int dataSize)
        {
            var array = Generators.GetAlmostSorted(dataSize);

            int swaps_counter = 0;
            Assert.AreEqual(dataSize, array.Length);
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    swaps_counter++;
                }
            }

            // % podmienionych * 2, bo ka¿da zamiana to potencjalne 2 b³êdy
            Assert.IsTrue(swaps_counter <= dataSize * Generators.ALMOST_SORTEDNESS * 2 / 100);
        }

        [DataRow(SortingBenchmarkSmall.DATA_SIZE)]
        [DataRow(SortingBenchmarkMedium.DATA_SIZE)]
        [DataRow(SortingBenchmarkLarge.DATA_SIZE)]
        [DataTestMethod]
        public void TestFewUnique(int dataSize)
        {
            HashSet<int> unique = new HashSet<int>();
            var array = Generators.GetFewUnique(dataSize);

            Assert.AreEqual(dataSize, array.Length);
            for (int i = 0; i < array.Length - 1; i++)
            {
                Assert.IsTrue(array[i] < Generators.UNIQUE_VALUES);
                unique.Add(array[i]);
            }

            Assert.IsTrue(unique.Count <= Generators.UNIQUE_VALUES);
        }
    }
}