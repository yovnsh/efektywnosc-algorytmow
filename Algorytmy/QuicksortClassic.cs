using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorytmy
{
    public class QuicksortClassic : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }

        private void QuickSort(int[] array, int left, int right)
        {
            if (left >= right) return;

            int pivot_i = left + ((right - left) / 2);
            int pivot = array[pivot_i];

            Swap(array, pivot_i, right);

            int i = left;
            int j = right;
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }

            if (left < j) QuickSort(array, left, j);
            if (i < right) QuickSort(array, i, right);
        }
    }
}
