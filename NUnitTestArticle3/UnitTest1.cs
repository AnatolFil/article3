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
    }
}