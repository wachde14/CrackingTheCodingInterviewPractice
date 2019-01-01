using NUnit.Framework;
using System.Collections.Generic;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Sort Stack: Write a program to sort a stack such that the smallest items are on the top. You can use
    /// an additional temporary stack, but you may not copy the elements into any other data structure
    /// (such as an array). The stack supports the following operations: push, pop, peek, and is Empty.
    /// </summary>
    class _3_5_SortStack
    {
        public void SortStack(Stack<int> initialStack)
        {
            Stack<int> bufferStack = new Stack<int>();

            while (initialStack.Count > 0)
            {
                int temp = initialStack.Pop();
                while (bufferStack.Count > 0 && bufferStack.Peek() > temp)
                {
                    initialStack.Push(bufferStack.Pop());
                }
                bufferStack.Push(temp);
            }

            while (bufferStack.Count > 0)
            {
                initialStack.Push(bufferStack.Pop());
            }
        }
    }

    public class _3_5_SortStackTests
    {
        _3_5_SortStack _practice = new _3_5_SortStack();

        [Test]
        public void _3_5_SortStack_WithValidUniquePushes_ShouldSortSuccessfully()
        {
            Stack<int> testStack = new Stack<int>();
            testStack.Push(2);
            testStack.Push(3);
            testStack.Push(1);
            testStack.Push(9);
            testStack.Push(0);
            testStack.Push(6);

            _practice.SortStack(testStack);

            Assert.AreEqual(0, testStack.Pop());
            Assert.AreEqual(1, testStack.Pop());
            Assert.AreEqual(2, testStack.Pop());
            Assert.AreEqual(3, testStack.Pop());
            Assert.AreEqual(6, testStack.Pop());
            Assert.AreEqual(9, testStack.Pop());
        }

        [Test]
        public void _3_5_SortStack_WithValidDuplicatePushes_ShouldSortSuccessfully()
        {
            Stack<int> testStack = new Stack<int>();
            testStack.Push(1);
            testStack.Push(1);
            testStack.Push(1);
            testStack.Push(9);
            testStack.Push(0);
            testStack.Push(6);

            _practice.SortStack(testStack);

            Assert.AreEqual(0, testStack.Pop());
            Assert.AreEqual(1, testStack.Pop());
            Assert.AreEqual(1, testStack.Pop());
            Assert.AreEqual(1, testStack.Pop());
            Assert.AreEqual(6, testStack.Pop());
            Assert.AreEqual(9, testStack.Pop());
        }
    }
}
