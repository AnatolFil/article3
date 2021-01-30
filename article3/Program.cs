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
                first = newEl;
            }
            else
            {
                newEl.next = last;
            }
            last = newEl;
            lenght++;
        }
    }
}
