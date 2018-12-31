using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Chapter_3___Stacks_and_Queues
{
    /// <summary>
    /// Stack of Plates: Imagine a (literal) stack of plates. If the stack gets too high, it might topple.
    /// Therefore, in real life, we would likely start a new stack when the previous stack exceeds some
    /// threshold. Implement a data structure SetOfStacks that mimics this. SetOfStacks should be
    /// composed of several stacks and should create a new stack once the previous one exceeds capacity.
    /// SetOfStacks.push() and SetOfStacks.pop() should behave identically to a single stack
    /// (that is, pop () should return the same values as it would if there were just a single stack).
    /// </summary>
    class SetOfStacks
    {
        private readonly List<Stack> _stackList;
        private readonly int _threshold;
        private int LastIndex => _stackList.Count - 1;

        public int StackCount => _stackList.Count;

        public SetOfStacks(int threshold)
        {
            Stack initStack = new Stack();
            _stackList = new List<Stack>();
            _stackList.Add(initStack);

            _threshold = threshold;
        }

        public object Pop()
        {
            Stack lastStack = _stackList[LastIndex];

            if (lastStack.Count == 0)
            {
                int preDeleteLastIndex = LastIndex;

                if (preDeleteLastIndex == 0)
                    throw new Exception("Cannot pop empty");

                _stackList.Remove(lastStack);
                return _stackList[preDeleteLastIndex - 1].Pop();
            }

            return _stackList[LastIndex].Pop();
        }

        public void Push(int pushValue)
        {
            Stack lastStack = _stackList[LastIndex];

            if (lastStack.Count == _threshold)
            {
                Stack newStack = new Stack();
                newStack.Push(pushValue);

                _stackList.Add(newStack);
                return;
            }

            lastStack.Push(pushValue);
        }
    }

    public class _3_3_SetOfStacksTests
    {
        [Test]
        public void _3_3_SetOfStacks_WithValidPushes_ShouldCreate3StacksTotal()
        {
            SetOfStacks setOfStacks = new SetOfStacks(2);

            setOfStacks.Push(1);
            setOfStacks.Push(2);
            setOfStacks.Push(3);
            setOfStacks.Push(4);
            setOfStacks.Push(5);
            setOfStacks.Push(6);

            Assert.AreEqual(3, setOfStacks.StackCount);
        }

        [Test]
        public void _3_3_SetOfStacks_WithTooManyPops_ShouldThrowException()
        {
            SetOfStacks setOfStacks = new SetOfStacks(2);

            setOfStacks.Push(1);
            setOfStacks.Push(2);
            setOfStacks.Push(3);

            Assert.AreEqual(3, setOfStacks.Pop());
            Assert.AreEqual(2, setOfStacks.Pop());
            Assert.AreEqual(1, setOfStacks.Pop());

            Assert.AreEqual(1, setOfStacks.StackCount);
            Assert.Throws<Exception>(() => setOfStacks.Pop());
        }

        [Test]
        public void _3_3_SetOfStacks_WithLargeThreshold_MaintainOneStack()
        {
            SetOfStacks setOfStacks = new SetOfStacks(20);

            setOfStacks.Push(1);
            setOfStacks.Push(2);
            setOfStacks.Push(3);
            setOfStacks.Push(4);
            setOfStacks.Push(5);
            setOfStacks.Push(6);
            setOfStacks.Push(7);
            setOfStacks.Push(8);
            setOfStacks.Push(9);
            setOfStacks.Push(10);

            Assert.AreEqual(1, setOfStacks.StackCount);
        }
    }
}
