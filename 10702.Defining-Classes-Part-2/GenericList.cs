using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10702.Defining_Classes_Part_2
{
    public class GenericList<T>
        where T : class, IEnumerable<T>, IList<T>, ICollection<T>
    {
        private T[] elements;

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
            int nullIndex = 0;
            for (int i = 0; i < this.Elements.Length; i++)
            {
                if (this.Elements[i] == null)
                {
                    nullIndex = i;
                    break;
                }
            }
            this.Elements[nullIndex] = element;
        }
    }
}
