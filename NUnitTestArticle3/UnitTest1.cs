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
            int lenght = 100000;
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
            int lenght = 100000;
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < lenght; i++)
            {
                stack.Push(i);
            }
            for(int i = lenght-1; i>=0;i--)
            {
                Assert.AreEqual(i, stack.Pop());
            }
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
            stack.Pop();
            Assert.AreEqual(0, stack.Count);
        }
        [Test]
        public void TestAddForMyFIFO()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            int lenght = 100000;
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
            int lenght = 1000000;
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
        [Test]
        public void TestPushForMultiStack()
        {
            uint countOfStacks = 20;
            int countOfElements = 100000;
            multiStack<int> multiSt = new multiStack<int>(countOfStacks);
            Random rand = new Random(DateTime.Now.Millisecond);
            for(int i=0;i<countOfElements;i++)
            {
                multiSt.push((uint) rand.Next(0,(int)countOfStacks), rand.Next());
            }
            Assert.AreEqual(countOfElements, multiSt.TotalLenght);
        }
        [Test]
        public void TestPopForMultiStack()
        {
            uint countOfStacks = 20;
            int countOfElements = 10000000;
            multiStack<int> multiSt = new multiStack<int>(countOfStacks);
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < countOfElements; i++)
            {
                multiSt.push((uint)rand.Next(0, (int)countOfStacks), rand.Next());
            }
            for(int i=0;i<countOfStacks;i++)
            {
                for (int j = 0; j < countOfElements; j++)
                {
                    int k = i % (int)countOfStacks;
                    multiSt.pop((uint)(k));
                }
            }
            
            Assert.AreEqual(0, multiSt.TotalLenght);
        }
        [Test]
        public void TestMinForMyStack()
        {
            int countOfElements = 1000;
            myStack<int> st = new myStack<int>();
            Random rand = new Random(DateTime.Now.Millisecond);
            st.push(0);
            for (int i = 0; i < countOfElements; i++)
            {
                st.push(i);
            }
            st.push(-1);
            st.push(-1);
            for (int i = 0; i < countOfElements; i++)
            {
                st.push(rand.Next(0, 100000000));
            }
            for (int i = 0; i < countOfElements-1; i++)
            {
                st.pop();
            }
            Assert.AreEqual(-1, st.Min.value);
            for (int i = 0; i < countOfElements; i++)
            {
                st.pop();
            }
            Assert.AreEqual(0, st.Min.value);
        }
        [Test]
        public void TestPushForSetOfStack()
        {
            int countOfElements = 100;
            setOfStack<int> set = new setOfStack<int>();
            for(int i=0;i< countOfElements;i++)
            {
                set.push(i);
            }
            Assert.AreEqual(countOfElements, set.TotalLenght);
            Assert.AreEqual(1, set.CountOfStacks);
            for (int i = 0; i < countOfElements; i++)
            {
                set.push(i);
            }
            Assert.AreEqual(countOfElements*2, set.TotalLenght);
            Assert.AreEqual(2, set.CountOfStacks);
        }
        [Test]
        public void TestPopForSetOfStack()
        {
            int countOfElements = 100;
            setOfStack<int> set = new setOfStack<int>();
            for (int i = 0; i < countOfElements; i++)
            {
                set.push(i);
            }
            for (int i = 0; i < countOfElements; i++)
            {
                set.pop();
            }
            Assert.AreEqual(0, set.TotalLenght);
            Assert.AreEqual(1, set.CountOfStacks);
            for (int i = 0; i < countOfElements*3; i++)
            {
                set.push(i);
            }
            for (int i = 0; i < countOfElements; i++)
            {
                set.pop();
            }
            Assert.AreEqual(countOfElements * 2, set.TotalLenght);
            Assert.AreEqual(2, set.CountOfStacks);
            Assert.AreEqual(countOfElements * 2-1, set.pop()); 
            Assert.AreEqual(countOfElements * 2-1, set.TotalLenght);
            Assert.AreEqual(2, set.CountOfStacks);
            set.push(199);
            Assert.AreEqual(countOfElements * 2, set.TotalLenght);
            Assert.AreEqual(2, set.CountOfStacks);
            set.push(200);
            Assert.AreEqual(countOfElements * 2+1, set.TotalLenght);
            Assert.AreEqual(3, set.CountOfStacks);
        }
        [Test]
        public void TestPopAtForSetOfStack()
        {
            int countOfElements = 100;
            setOfStack<int> set = new setOfStack<int>();
            for (int i = 0; i < countOfElements*3; i++)
            {
                set.push(i);
            }
            for (int i = 0; i < countOfElements; i++)
            {
                set.popAt(1);
            }
            Assert.AreEqual(countOfElements*2, set.TotalLenght);
            Assert.AreEqual(2, set.CountOfStacks);
            for (int i = 0; i < countOfElements * 3; i++)
            {
                set.push(i);
            }
            Assert.AreEqual(countOfElements * 5, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.popAt(3);
            set.popAt(2);
            set.popAt(1);
            set.popAt(0);
            Assert.AreEqual(countOfElements * 5-4, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.push(11);
            Assert.AreEqual(countOfElements * 5 - 3, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.push(11);
            Assert.AreEqual(countOfElements * 5 - 2, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.push(11);
            Assert.AreEqual(countOfElements * 5 - 1, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.push(11);
            Assert.AreEqual(countOfElements * 5, set.TotalLenght);
            Assert.AreEqual(5, set.CountOfStacks);
            set.push(11);
            Assert.AreEqual(countOfElements * 5+1, set.TotalLenght);
            Assert.AreEqual(6, set.CountOfStacks);
            Random rand = new Random(DateTime.Now.Millisecond);
            countOfElements = 1000000;
            for(int i = 0;i<countOfElements*10;i++)
            {
                int randInt = rand.Next(0, 15);
                if (randInt >= 0 && randInt < 5)
                    set.push(i);
                else if (randInt >= 5 && randInt < 10)
                    set.pop();
                else
                    set.popAt((uint)rand.Next(0, (int)set.CountOfStacks - 1));
            }
            Assert.IsTrue(set.CountOfStacks >= 1);
            Assert.IsTrue(set.TotalLenght >= 0);
        }
        [Test]
        public void TestMyStackQueue()
        {
            int countOfElements = 100000;
            myStackQueue<int> queue = new myStackQueue<int>();
            for (int i = 0; i < countOfElements; i++)
            {
                queue.add(i);
            }
            Assert.AreEqual(countOfElements, queue.TotalLenght);
            for (int i = 0; i < countOfElements; i++)
            {
                queue.remove();
            }
            Assert.AreEqual(0, queue.TotalLenght);
            for(int i = 0; i < countOfElements; i++)
            {
                queue.add(i);
            }
            for (int i = 0; i < countOfElements; i++)
            {
                Assert.AreEqual(i, queue.remove());
            }
            Assert.AreEqual(0, queue.TotalLenght);
        }
    }
}