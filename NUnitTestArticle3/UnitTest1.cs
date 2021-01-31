using NUnit.Framework;
using System;
using article3;
using System.Collections.Generic;

namespace NUnitTestArticle3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestPushForMyStack()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenght = 100000000;
            myStack<int> stack = new myStack<int>();
            for(int i = 0;i<lenght;i++)
            {
                stack.push(rand.Next());
            }
            Assert.AreEqual(lenght, stack.Lenght);
        }
        [Test]
        public void TestPushForSTDStack()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenght = 100000000;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < lenght; i++)
            {
                stack.Push(rand.Next());
            }
            Assert.AreEqual(lenght, stack.Count);
        }
        [Test]
        public void TestPopForMyStack()
        {
            int lenght = 100000000;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < lenght; i++)
            {
                stack.Push(i);
            }
            for(int i = lenght-1; i>=0;i--)
            {
                Assert.AreEqual(i, stack.Pop());
            }
        }
        [Test]
        public void TestAddForMyFIFO()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenght = 100000000;
            myFIFO<int> fifo = new myFIFO<int>();
            for (int i = 0; i < lenght; i++)
            {
                fifo.add(rand.Next());
            }
            Assert.AreEqual(lenght, fifo.Lenght);
        }
        [Test]
        public void TestRemoveForMyFIFO()
        {
            int lenght = 100000000;
            myFIFO<int> fifo = new myFIFO<int>();
            for (int i = 0; i < lenght; i++)
            {
                fifo.add(i);
            }
            for (int i = 0; i > lenght; i++)
            {
                Assert.AreEqual(i, fifo.remove());
            }
        }
    }
}