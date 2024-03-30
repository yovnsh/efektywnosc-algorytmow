namespace Algorytmy
{
    public class InsertionSort : ISortingAlgorithm
    {
        public void Sort(int[] array)
        {
            for(int n = 1; n < array.Length; n++)
            {
                int current = array[n];
                int i = n - 1;
                while(i >= 0 && array[i] > current)
                {
                    array[i + 1] = array[i];
                    i--;
                }
                array[i + 1] = current;
            }
        }

        override public string ToString()
        {
            return "Insertion Sort";
        }
    }
}