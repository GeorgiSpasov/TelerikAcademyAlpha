using System;
using System.Linq;

namespace _10702.Defining_Classes_Part_2
{
    public class GenericList<T>
    {
        private T[] elements;
        private int fillIndex;
        private int length;

        public GenericList(int capacity)
        {
            this.Elements = new T[capacity];
            this.FillIndex = 0;
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

        public int FillIndex
        {
            get
            {
                return this.fillIndex;
            }
            private set
            {
                this.fillIndex = value;
            }
        }

        public int Length
        {
            get
            {
                return this.Elements.Length;
            }
        }

        public void AddElement(T element)
        {
            this.AutoGrow();

            this.Elements[this.FillIndex] = element;
            this.FillIndex++;
        }

        public T GetElement(int index)
        {
            return this.Elements[index];
        }

        public void RemoveElement(int index)
        {
            this.Elements[index] = default(T);
            if (index < this.Elements.Length - 1)
            {
                T currentElement;
                while (index < this.Elements.Length - 1)
                {
                    currentElement = this.Elements[index + 1];
                    this.Elements[index] = currentElement;
                    index++;
                }
                this.Elements[this.FillIndex] = default(T);
            }
            if (this.FillIndex > 0)
            {
                this.FillIndex--;
            }
        }

        public void InsertElementAt(int index, T element)
        {
            this.AutoGrow();
            
            T shiftedElement;
            int shiftIndex = this.FillIndex;
            while (shiftIndex >= index)
            {
                shiftedElement = this.Elements[shiftIndex];
                shiftIndex++;
                this.Elements[shiftIndex] = shiftedElement;
                shiftIndex -= 2;
            }
            this.Elements[index] = element;
            this.FillIndex++;
        }

        public void ClearList()
        {
            for (int i = 0; i < this.Elements.Length; i++)
            {
                this.Elements[i] = default(T);
            }
        }

        public T FindElement(T item) //Finding element by its value 
        {
            foreach (T element in this.Elements)
            {
                if (element.Equals(item))
                {
                    return element;
                }
            }
            return default(T);
        }

        private void AutoGrow()
        {
            if (this.FillIndex != this.Elements.Length)
            {
                return;
            }

            T[] newArray = new T[this.Elements.Length * 2];
            Array.Copy(this.Elements, newArray, this.FillIndex);
            this.Elements = newArray;
            this.FillIndex *= 2;
        }

        /*TODO:
        Create generic methods Min<T>() and Max<T>() for finding the minimal and maximal element in the GenericList<T>.
        May need to add a generic constraints for the type T.*/

        public override string ToString()
        {
            return string.Join("\n", this.Elements.Where(e => !e.Equals(default(T))));
        }
    }
}

