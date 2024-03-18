using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy
{
    public class MergeSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        private void Sort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                Sort(array, left, middle);
                Sort(array, middle + 1, right);
                Merge(array, left, middle, right);
            }
        }

        private static void Merge(int[] array, int left, int middle, int right)
        {
            int n1 = middle - left + 1;
            int n2 = right - middle;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            for (int i = 0; i < n1; i++)
            {
                leftArray[i] = array[left + i];
            }
            for (int j = 0; j < n2; j++)
            {
                rightArray[j] = array[middle + 1 + j];
            }

            int k = left;
            int l = 0;
            int r = 0;

            while (l < n1 && r < n2)
            {
                if (leftArray[l] <= rightArray[r])
                {
                    array[k] = leftArray[l];
                    l++;
                }
                else
                {
                    array[k] = rightArray[r];
                    r++;
                }
                k++;
            }

            while (l < n1)
            {
                array[k] = leftArray[l];
                l++;
                k++;
            }

            while (r < n2)
            {
                array[k] = rightArray[r];
                r++;
                k++;
            }
        }
    }
}