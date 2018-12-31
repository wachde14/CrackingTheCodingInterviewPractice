using NUnit.Framework;
using System;
using System.Collections;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Queue via Stacks: Implement a class which implements a queue using two stacks.
    /// </summary>
    class QueueViaStacks
    {
        private readonly Stack _oldStack;
        private readonly Stack _newStack;

        public QueueViaStacks()
        {
            _oldStack = new Stack();
            _newStack = new Stack();
        }

        public object Dequeue()
        {
            MoveOldestToNewest();
            return _oldStack.Pop();
        }
        public object PeekDequeue()
        {
            MoveOldestToNewest();
            return _oldStack.Peek();
        }

        public void Enqueue(int enqueueValue)
        {
            _newStack.Push(enqueueValue);
        }

        private void MoveOldestToNewest()
        {
            if (_oldStack.Count == 0)
            {
                while (_newStack.Count > 0)
                {
                    _oldStack.Push(_newStack.Pop());
                }
            }
        }
    }

    public class _3_4_QueueViaStacksTests
    {
        readonly QueueViaStacks q = new QueueViaStacks();

        [Test]
        public void _3_4_QueueViaStacks_WithValidEnqueues_ShouldDequeueSuccessfully()
        {
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            q.Enqueue(4);
            q.Enqueue(5);

            Assert.AreEqual(1, q.Dequeue());
            Assert.AreEqual(2, q.Dequeue());
            Assert.AreEqual(3, q.Dequeue());
            Assert.AreEqual(4, q.Dequeue());
            Assert.AreEqual(5, q.Dequeue());
        }

        [Test]
        public void _3_4_QueueViaStacks_WithTooManyDequeues_ShouldThrowException()
        {
            q.Enqueue(1);
            q.Dequeue();

            Assert.Throws<InvalidOperationException>(() => q.Dequeue());
        }
    }
}
