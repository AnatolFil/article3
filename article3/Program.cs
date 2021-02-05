using System;
using System.Collections.Generic;

namespace article3
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class stackElement<T> where T : IComparable<T>
    {
        public T value;
        public stackElement<T> next;
        private IComparer<T> comparer;
        public stackElement(IComparer<T> defaultComparer)
        {
            if (defaultComparer == null) throw new ArgumentNullException();
            comparer = defaultComparer;
        }
        public stackElement() : this(Comparer<T>.Default) { }
    }
    public class myStack<T> where T : IComparable<T>
    {
        private int lenght;
        public stackElement<T> first;
        public stackElement<T> last;
        private stackElement<T> min;
        public stackElement<T> Min
        {
            get { return min; }
        }
        
        public myStack()
        {
            lenght = 0;
            first = null;
            last = null;
            min = new stackElement<T>();
        }
        public int Lenght
        {
            get { return lenght; }
        }
        public void push(T newElement)
        {
            stackElement<T> newEl = new stackElement<T>();
            newEl.value = newElement;
            if (lenght == 0)
            {
                newEl.next = null;
                first = newEl;
                min.value = newEl.value;
            }
            else
            {
                newEl.next = last;
                if (newElement.CompareTo(min.value) < 0 || newElement.CompareTo(min.value) == 0)
                {
                    stackElement<T> newMin = new stackElement<T>(); 
                    newMin.value = newEl.value;
                    newMin.next = min;
                    min = newMin;
                }   
            }
            last = newEl;
            lenght++;
        }
        public T pop()
        {
            T res = default(T);
            if (lenght > 0)
            {
                if (min.value.CompareTo(last.value) == 0 && min.next != null)
                {
                    min = min.next;
                }   
                res = last.value;
                last = last.next;
                lenght--;
            }
            return res;
        }
    }
    public class fifoElement<T>
    {
        public T value;
        public fifoElement<T> prev;
    }
    public class myFIFO<T>
    {
        private int lenght;
        private fifoElement<T> first;
        private fifoElement<T> last;
        public myFIFO()
        {
            lenght = 0;
            first = null;
            last = null;
        }
        public int Lenght
        {
            get {return lenght;}
        }
        public void add(T newElement)
        {
            fifoElement<T> newEl = new fifoElement<T>();
            newEl.value = newElement;
            if(lenght == 0)
            {
                newEl.prev = null;
                first = newEl; 
            }
            else
            {
                last.prev = newEl;
            }
            lenght++;
            last = newEl;
        }
        public T remove()
        {
            T res = default(T);
            if(lenght > 0)
            {
                res = first.value;
                first = first.prev;
                lenght--;
            }
            return res;
        }
    }
    public class multiStack<T>
    {
        private class stackElement<T>
        {
            public T value;
            public uint next;
        }
        private class stackInfo
        {
            public uint lenght;
            public uint capisity;
            public uint last;
        }
        private uint countOfStacks;
        private uint totalLenght;
        public uint TotalLenght
        {
            get { return totalLenght; }
        }
        private uint totalCapisity;
        private stackInfo[] info;
        private stackElement<T>[] mas;
        private uint defaultSize = 100;
        public multiStack(uint count)
        {
            info = new stackInfo[count];
            mas = new stackElement<T>[count * defaultSize];
            countOfStacks = count;
            totalCapisity = count * defaultSize;
            for (int i=0;i<count;i++)
            {
                info[i] = new stackInfo();
                info[i].capisity = defaultSize;
                info[i].last = 0;
                info[i].lenght = 0;
            }
        }
        public void push(uint stack, T value)
        {
            if(stack < countOfStacks)
            {
                stackElement<T> newEl = new stackElement<T>();
                newEl.value = value;
                if(totalLenght >= totalCapisity)
                {
                    stackElement<T>[] newMas = new stackElement<T>[totalCapisity * 2];
                    for (int i = 0; i < totalCapisity; i++)
                    {
                        newMas[i] = mas[i];
                    }
                    mas = newMas;
                    totalCapisity = totalCapisity * 2;
                }
                bool findPlace = false;
                uint place = 0;
                for (uint i = info[stack].last; i < totalCapisity; i++)
                {
                    if (mas[i] == null)
                    {
                        findPlace = true;
                        place = i;
                        break;
                    }
                }
                if (findPlace == false)
                {
                    for (uint i = 0; i < info[stack].last; i++)
                    {
                        if (mas[i] == null)
                        {
                            place = i;
                            break;
                        }
                    }
                }
                mas[place] = newEl;
                newEl.next = info[stack].last;
                info[stack].last = place;
                info[stack].lenght++;
                totalLenght++;
            }
        }
        public void pop(uint stack)
        {
            if(stack < countOfStacks)
            {
                if(info[stack].lenght > 0)
                {
                    uint tmp = mas[info[stack].last].next;
                    mas[info[stack].last] = null;
                    info[stack].last = tmp;
                    info[stack].lenght--;
                    totalLenght--;
                }
            }//here it would be great to add cleaning memory
        }
    }

}
