using NUnit.Framework;
using System;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Stack Min: How would you design a stack which, in addition to push and pop, has a function min
    /// which returns the minimum element? Push, pop and min should all operate in 0(1) time.
    /// </summary>
    class StackWithMinimum
    {
        private readonly int[] _array;
        private readonly int[] _minimumArray;

        private int _currStackPointer;

        public StackWithMinimum(int stackSize = 10)
        {
            _array = new int[stackSize];
            _minimumArray = new int[stackSize];
            _currStackPointer = -1;
        }

        public int Pop()
        {
            if (_currStackPointer == -1)
            {
                throw new Exception("No value to pop.");
            }

            int popValue = _array[_currStackPointer];
            _minimumArray[_currStackPointer] = 0;
            _array[_currStackPointer] = 0;

            _currStackPointer--;
            return popValue;
        }

        public int Peek()
        {
            if (_currStackPointer == -1)
            {
                throw new Exception("No value to pop.");
            }

            return _array[_currStackPointer];
        }

        public int PeekMin()
        {
            if (_currStackPointer == -1)
            {
                return int.MaxValue;
            }

            return _minimumArray[_currStackPointer];
        }

        public void Push(int pushValue)
        {
            if (_currStackPointer == _array.Length)
            {
                throw new Exception("Stack is full.");
            }

            int currMin = pushValue < PeekMin() ? pushValue : PeekMin();

            _currStackPointer++;
            _minimumArray[_currStackPointer] = currMin;
            _array[_currStackPointer] = pushValue;
        }
    }

    public class _3_2_StackMinTests
    {
        [Test]
        public void _3_2_StackWithMinimum_WithValidMinimums_ShouldStoreSuccessfully()
        {
            StackWithMinimum minStack = new StackWithMinimum();

            minStack.Push(2);
            minStack.Push(3);
            minStack.Push(6);
            minStack.Push(1);
            minStack.Push(9);
            minStack.Push(0);

            Assert.AreEqual(0, minStack.PeekMin());
            Assert.AreEqual(0, minStack.Pop());

            Assert.AreEqual(1, minStack.PeekMin());
            Assert.AreEqual(9, minStack.Pop());

            Assert.AreEqual(1, minStack.PeekMin());
            Assert.AreEqual(1, minStack.Pop());

            Assert.AreEqual(2, minStack.PeekMin());
            Assert.AreEqual(6, minStack.Pop());

            Assert.AreEqual(2, minStack.PeekMin());
            Assert.AreEqual(3, minStack.Pop());

            Assert.AreEqual(2, minStack.PeekMin());
            Assert.AreEqual(2, minStack.Pop());
        }
        [Test]
        public void _3_2_StackWithMinimum_WithValidMinimumsAndNegatives_ShouldStoreSuccessfully()
        {
            StackWithMinimum minStack = new StackWithMinimum();

            minStack.Push(2);
            minStack.Push(-2);
            minStack.Push(-1);
            minStack.Push(1);
            minStack.Push(-3);

            Assert.AreEqual(-3, minStack.PeekMin());
            Assert.AreEqual(-3, minStack.Pop());

            Assert.AreEqual(-2, minStack.PeekMin());
            Assert.AreEqual(1, minStack.Pop());

            Assert.AreEqual(-2, minStack.PeekMin());
            Assert.AreEqual(-1, minStack.Pop());

            Assert.AreEqual(-2, minStack.PeekMin());
            Assert.AreEqual(-2, minStack.Pop());

            Assert.AreEqual(2, minStack.PeekMin());
            Assert.AreEqual(2, minStack.Pop());
        }
    }
}
