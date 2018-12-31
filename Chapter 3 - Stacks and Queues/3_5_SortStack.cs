using NUnit.Framework;
using System.Collections;
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
                bufferStack.Push(initialStack.Pop());
            }

            while (bufferStack.Count > 0)
            {
                //int currInsertNumber = bufferStack.Pop();

                //if (initialStack.Count == 0)
                //    initialStack.Push(currInsertNumber);

                //int amountToPutBack = 0;
                //while (currInsertNumber < initialStack.Peek())
                //{
                //    bufferStack.Push();
                //}



            }
        }
    }

    public class _3_5_SortStackTests
    {
        [Test]
        public void _3_5_SortStack_WithValidEnqueues_ShouldDequeueSuccessfully()
        {
        }
    }
}
