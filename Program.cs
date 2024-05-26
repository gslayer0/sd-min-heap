namespace MyHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            int[] unsortedArray = [10, 8, 9, 2, 3, 12];
            int[] sortedArray = HeapSort(unsortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));

            unsortedArray = [10, 9, 8, 7, 6, 5, 4, 3];
            sortedArray = HeapSort(unsortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));
        }

        static int[] HeapSort(int[] unsortedArray)
        {
            int[] sortedArray = new int[unsortedArray.Length];
            int HeapCapacity = unsortedArray.Length;
            MinHeap heap = new MinHeap(HeapCapacity);

            foreach(int i in unsortedArray)
            {
                heap.Add(i);
            }

            int arrIndex = 0;
            while(heap.Size > 0)
            {
                sortedArray[arrIndex] = heap.Poll();
                arrIndex++;
            }
            return sortedArray;
        }
    }
}
