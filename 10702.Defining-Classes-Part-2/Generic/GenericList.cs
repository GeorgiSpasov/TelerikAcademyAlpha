using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10702.Defining_Classes_Part_2.Generic
{
    public class GenericList<T>
    {
        private T[] elements;
        private int fillIndex = 0;

        public GenericList(int capacity)
        {
            this.Elements = new T[capacity];
        }

        public T[] Elements
        {
            get
            {
                return this.elements;
            }
            set
            {
                this.elements = value;
            }
        }

        public void AddElement(T element)
        {
            if (fillIndex + 1 >= this.Elements.Length)
            {
                // TODO: method GrowArray
            }
            this.Elements[fillIndex] = element;
            fillIndex++;
        }

        public T GetElement(int index)
        {
            return this.Elements[index];
        }

        public void RemoveElement(int index)
        {
            this.Elements[index] = default(T);
            //TODO shift elements <<
        }

        public void InsertElementAt(int index, T item)
        {
            //this.Elements.Insert(index, item);
        }

        public void ClearElements()
        {
            //this.Elements.Clear();
        }

        //public T FindElement(T item)
        {
            //return this.Elements.Find(item);
        }
    }
}
