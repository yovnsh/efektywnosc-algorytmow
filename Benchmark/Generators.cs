using Microsoft.Diagnostics.Tracing.Parsers.Clr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarks
{
    public class Generators
    {
        public const int ALMOST_SORTEDNESS = 10; // % elementów podmienionych
        public const int UNIQUE_VALUES = 10;     // ilość unikalnych elementów

        public static int[] GetRandom(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        public static int[] GetSorted(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            return array;
        }

        public static int[] GetReversed(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = size - i;
            }
            return array;
        }

        public static int[] GetFewUnique(int size)
        {
            int[] array = new int[size];
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(0, UNIQUE_VALUES);
            }
            return array;
        }

        public static int[] GetAlmostSorted(int size)
        {
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = i;
            }
            Random rand = new Random();
            int elementsToSwap = size * ALMOST_SORTEDNESS / 100;
            for (int i = 0; i < elementsToSwap; i++)
            {
                int index1 = rand.Next(0, size);
                int index2 = rand.Next(0, size);
                (array[index2], array[index1]) = (array[index1], array[index2]);
            }
            return array;
        }
    }
}
