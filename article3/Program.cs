using System;

namespace article3
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class stackElement<T>
    {
        public T value;
        public stackElement<T> next;
        //public stackElement<T> prev;
    }
    public class myStack<T>
    {
        private int lenght;
        public stackElement<T> first;
        public stackElement<T> last;
        public myStack()
        {
            lenght = 0;
            first = null;
            last = null;
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
                //newEl.prev = null;
                first = newEl;
            }
            else
            {
                newEl.next = last;
            }
            last = newEl;
            lenght++;
        }
        public T pop()
        {
            T res = default(T);
            if (lenght > 0)
            {
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
}
