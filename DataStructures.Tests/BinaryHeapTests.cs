﻿using System;
using System.Collections.Generic;

using NUnit.Framework;

namespace DataStructures.Tests
{
    static class BinaryHeapTests
    {
        [Test]
        public static void Constructor_UseCustomComparer_BuildCorrectHeap()
        {
            var revHeap = new BinaryHeap<int>(Comparer<int>.Create((x, y) => x.CompareTo(y) * -1));
            foreach (int i in new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 })
            {
                revHeap.Push(i);
            }

            Assert.AreEqual(10, revHeap.Count);
            Assert.AreEqual(1, revHeap.Peek());
            Assert.AreEqual(1, revHeap.Pop());
            Assert.AreEqual(2, revHeap.Peek());
        }

        [Test]
        public static void Push_AddElements_BuildCorrectHeap()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.AreEqual(10, heap.Peek());
            Assert.AreEqual(10, heap.Count);
        }

        [Test]
        public static void Push_AddElementAlreadyInHeap_ThrowsCorrectException()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.Throws<ArgumentException>(() => heap.Push(1));
        }

        public static void Pop_RemoveElements_HeapStillValid()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.AreEqual(10, heap.Peek());
            Assert.AreEqual(10, heap.Count);

            Assert.AreEqual(10, heap.Pop());
            Assert.AreEqual(9, heap.Count);
            Assert.IsFalse(heap.Contains(10));

            Assert.AreEqual(9, heap.Pop());
            Assert.AreEqual(8, heap.Count);
            Assert.IsFalse(heap.Contains(9));
        }

        [Test]
        public static void Pop_EmptyHeap_ThrowsCorrectException()
        {
            var heap = new BinaryHeap<int>();

            Assert.Throws<InvalidOperationException>(() => heap.Pop());
        }

        [Test]
        public static void Peek_NonEmptyHeap_ReturnsCorrectAnswer()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.AreEqual(10, heap.Peek());
        }

        [Test]
        public static void Peek_EmptyHeap_ThrowsCorrectExcception()
        {
            var heap = new BinaryHeap<int>();

            Assert.Throws<InvalidOperationException>(() => heap.Peek());
        }

        [Test]
        public static void PushPop_EmptyHeap_ReturnsCorrectAnswer()
        {
            var heap = new BinaryHeap<int>();

            Assert.AreEqual(10, heap.PushPop(10));
        }

        [Test]
        public static void PushPop_NonEmptyHeap_ReturnsCorrectAnswer()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.AreEqual(20, heap.PushPop(20));
            Assert.AreEqual(10, heap.PushPop(-10));
        }

        [Test]
        public static void Contains_NonEmptyHeap_ReturnsCorrectAnswer()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            Assert.IsTrue(heap.Contains(1));
            Assert.IsTrue(heap.Contains(5));
            Assert.IsTrue(heap.Contains(10));
            Assert.IsFalse(heap.Contains(11));
        }

        [Test]
        public static void Contains_EmptyHeap_ReturnsCorrectAnswer()
        {
            var heap = new BinaryHeap<int>();

            Assert.IsFalse(heap.Contains(1));
            Assert.IsFalse(heap.Contains(5));
            Assert.IsFalse(heap.Contains(10));
            Assert.IsFalse(heap.Contains(11));
        }

        [Test]
        public static void Remove_NonEmptyHeap_HeapStillValid()
        {
            var heap = new BinaryHeap<int>();
            var elems = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int i in elems)
            {
                heap.Push(i);
            }

            heap.Remove(5);
            Assert.IsFalse(heap.Contains(5));
            Assert.AreEqual(10, heap.Peek());
            Assert.AreEqual(9, heap.Count);

            heap.Remove(8);
            Assert.IsFalse(heap.Contains(8));
            Assert.AreEqual(10, heap.Peek());
            Assert.AreEqual(8, heap.Count);

            Assert.Throws<ArgumentException>(() => heap.Remove(11));
        }

        [Test]
        public static void Remove_EmptyHeap_ThrowsCorrectException()
        {
            var heap = new BinaryHeap<int>();

            Assert.Throws<ArgumentException>(() => heap.Remove(1));
        }
    }
}
