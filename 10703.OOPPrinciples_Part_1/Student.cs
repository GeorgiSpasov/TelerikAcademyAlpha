using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10703.OOPPrinciples_Part_1
{
    public class Student : Human
    {
        private int grade;

        public Student(string firstName, string lastName, int grade) : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"{base.FirstName} {this.LastName} - {this.Grade} grade");
        }
    }
}
