using NUnit.Framework;
using System;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Three in One: Describe (implement) how you could use a single array to implement three stacks.
    /// </summary>
    class ThreeStackFixedSize
    {
        private readonly int[] _array;

        private readonly int _firstStackEndBoundary;
        private readonly int _secondStackEndBoundary;
        private readonly int _thirdStackEndBoundary;

        private int _currFirstStackPointer;
        private int _currSecondStackPointer;
        private int _currThirdStackPointer;

        public ThreeStackFixedSize(int eachStackSize = 10)
        {
            _array = new int[eachStackSize * 3];

            _firstStackEndBoundary = eachStackSize - 1;
            _secondStackEndBoundary = (eachStackSize * 2) - 1;
            _thirdStackEndBoundary = (eachStackSize * 3) - 1;

            _currFirstStackPointer = -1;
            _currSecondStackPointer = eachStackSize - 1;
            _currThirdStackPointer = eachStackSize * 2 - 1;
        }

        public int Pop(int stackNumber)
        {
            if (stackNumber == 1)
            {
                if (_currFirstStackPointer == -1)
                {
                    throw new Exception("No value to pop.");
                }

                int popValue = _array[_currFirstStackPointer];
                _array[_currFirstStackPointer] = 0;
                _currFirstStackPointer--;
                return popValue;
            }

            if (stackNumber == 2)
            {
                if (_currSecondStackPointer == _firstStackEndBoundary)
                {
                    throw new Exception("No value to pop.");
                }

                int popValue = _array[_currSecondStackPointer];
                _array[_currSecondStackPointer] = 0;
                _currSecondStackPointer--;
                return popValue;
            }

            if (stackNumber == 3)
            {
                if (_currThirdStackPointer == _secondStackEndBoundary)
                {
                    throw new Exception("No value to pop.");
                }

                int popValue = _array[_currThirdStackPointer];
                _array[_currThirdStackPointer] = 0;
                _currThirdStackPointer--;
                return popValue;
            }

            throw new Exception("Unable to find stack");
        }

        public void Push(int stackNumber, int value)
        {
            if (stackNumber == 1)
            {
                if (_currFirstStackPointer == _firstStackEndBoundary)
                {
                    throw new Exception("No room to push.");
                }

                _currFirstStackPointer++;
                _array[_currFirstStackPointer] = value;
                return;
            }

            if (stackNumber == 2)
            {
                if (_currSecondStackPointer == _secondStackEndBoundary)
                {
                    throw new Exception("No room to push.");
                }

                _currSecondStackPointer++;
                _array[_currSecondStackPointer] = value;
                return;
            }

            if (stackNumber == 3)
            {
                if (_currThirdStackPointer == _thirdStackEndBoundary)
                {
                    throw new Exception("No room to push.");
                }

                _currThirdStackPointer++;
                _array[_currThirdStackPointer] = value;
                return;
            }

            throw new Exception("Unable to find stack");
        }

        public int Peek(int stackNumber)
        {
            if (stackNumber == 1)
            {
                if (_currFirstStackPointer == -1)
                {
                    throw new Exception("No value to pop.");
                }

                return _array[_currFirstStackPointer];
            }

            if (stackNumber == 2)
            {
                if (_currSecondStackPointer == _firstStackEndBoundary)
                {
                    throw new Exception("No value to pop.");
                }

                return _array[_currSecondStackPointer];
            }

            if (stackNumber == 3)
            {
                if (_currThirdStackPointer == _secondStackEndBoundary)
                {
                    throw new Exception("No value to pop.");
                }

                return _array[_currThirdStackPointer];
            }

            throw new Exception("Unable to find stack");
        }
    }

    public class _3_1_ThreeInOneTests
    {
        [Test]
        public void _3_1_ThreeStack_withValidOperations_ShouldPopSuccessfully()
        {
            ThreeStackFixedSize threeStack = new ThreeStackFixedSize(2);

            threeStack.Push(1, 10);
            threeStack.Push(1, 20);
            threeStack.Push(2, 30);
            threeStack.Push(2, 40);
            threeStack.Push(3, 50);
            threeStack.Push(3, 60);

            Assert.AreEqual(20, threeStack.Pop(1));
            Assert.AreEqual(10, threeStack.Pop(1));
            Assert.AreEqual(40, threeStack.Pop(2));
            Assert.AreEqual(30, threeStack.Pop(2));
            Assert.AreEqual(60, threeStack.Pop(3));
            Assert.AreEqual(50, threeStack.Pop(3));
        }

        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(6, 1)]
        [TestCase(6, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 1)]
        [TestCase(7, 2)]
        [TestCase(7, 3)]
        public void _3_1_ThreeStack_WithTooManyPopsTestCases_ShouldThrowException(int eachStackSize, int stackNumber)
        {
            ThreeStackFixedSize threeStack = new ThreeStackFixedSize(eachStackSize);

            for (int i = 0; i < eachStackSize; i++)
            {
                threeStack.Push(stackNumber, i);
            }

            for (int i = 0; i < eachStackSize; i++)
            {
                threeStack.Pop(stackNumber);
            }

            Assert.Throws<Exception>(() => threeStack.Pop(stackNumber));
        }

        [TestCase(2, 1)]
        [TestCase(2, 2)]
        [TestCase(2, 3)]
        [TestCase(6, 1)]
        [TestCase(6, 2)]
        [TestCase(6, 3)]
        [TestCase(7, 1)]
        [TestCase(7, 2)]
        [TestCase(7, 3)]
        public void _3_1_ThreeStack_WithTooManyPushesTestCases_ShouldThrowException(int eachStackSize, int stackNumber)
        {
            ThreeStackFixedSize threeStack = new ThreeStackFixedSize(eachStackSize);

            for (int i = 0; i < eachStackSize; i++)
            {
                threeStack.Push(stackNumber, i);
            }

            Assert.Throws<Exception>(() => threeStack.Push(stackNumber, 100));
        }

        [Test]
        public void _3_1_ThreeStack_withValidPeeks_ShouldReturnTopValues()
        {
            ThreeStackFixedSize threeStack = new ThreeStackFixedSize(2);

            threeStack.Push(1, 10);
            threeStack.Push(1, 20);
            threeStack.Push(2, 30);
            threeStack.Push(2, 40);
            threeStack.Push(3, 50);
            threeStack.Push(3, 60);

            Assert.AreEqual(20, threeStack.Peek(1));
            Assert.AreEqual(40, threeStack.Peek(2));
            Assert.AreEqual(60, threeStack.Peek(3));
        }

        [Test]
        public void _3_1_ThreeStack_withManyValidPeeks_ShouldReturnTopValueEveryTime()
        {
            ThreeStackFixedSize threeStack = new ThreeStackFixedSize(2);

            threeStack.Push(1, 10);
            threeStack.Push(1, 20);
            threeStack.Push(2, 30);
            threeStack.Push(2, 40);
            threeStack.Push(3, 50);
            threeStack.Push(3, 60);

            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(20, threeStack.Peek(1));
            }
        }
    }
}
