using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHeap
{
    public class MinHeap
    {
        public MinHeap(int capacity)
        {
            Capacity = capacity;
            Items = new int[Capacity];
        }
        public int Capacity { get; }
        public int Size { get; private set; } = 0;
        public int[] Items { get; private set; }

        private int GetLeftChildIndex(int index) { return 2 * index + 1; }
        private int GetRightChildIndex(int index) { return 2 * index + 2; }
        private int GetParentIndex(int index) { return (index - 1) / 2; }

        private bool HasLeftChild(int index) { return GetLeftChildIndex(index) < Size; }
        private bool HasRightChild(int index) { return GetRightChildIndex(index) < Size; }
        private bool HasParent(int index) { return GetParentIndex(index) >= 0; }

        private int LeftChild(int index) { return Items[GetLeftChildIndex(index)]; }
        private int RightChild(int index) { return Items[GetRightChildIndex(index)]; }
        private int Parent(int index) { return Items[GetParentIndex(index)]; }

        private void swap(int indexOne, int indexTwo)
        {
            int temp = Items[indexOne]; Items[indexOne] = Items[indexTwo]; Items[indexTwo] = temp;
        }

        public int Peek()
        {
            if (Size == 0) throw new InvalidOperationException("Tree masih kosong!");
            return Items[0];
        }

        public int Poll()
        {
            if (Size == 0) throw new InvalidOperationException("Tree masih kosong!");
            int item = Items[0];
            Items[0] = Items[Size - 1];
            Size--;
            HeapifyDown();
            return item;

        }

        public void Add(int item)
        {
            if (Size == Capacity)
            {
                throw new InvalidOperationException("Tree sudah penuh!");
            }
            Items[Size] = item;
            Size++;
            HeapifyUp();
        }

        public void HeapifyDown()
        {
            int index = 0;
            while (HasLeftChild(index))
            {
                int smallerChildIndex = GetLeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) < LeftChild(index))
                {
                    smallerChildIndex = GetRightChildIndex(index);
                }
                if (Items[index] < Items[smallerChildIndex])
                {
                    break;
                }
                else
                {
                    swap(index, smallerChildIndex);
                }
                index = smallerChildIndex;

            }
        }

        public void HeapifyUp()
        {
            int index = Size - 1;
            while (HasParent(index) && Parent(index) > Items[index])
            {
                swap(GetParentIndex(index), index);
                index = GetParentIndex(index);
            }
        }
    }
}
