using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;
        private IList<IStudent> onsiteStudents;
        private IList<IStudent> onlineStudents;
        private IList<ILecture> lectures;


        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = startingDate.AddDays(30);
            this.onsiteStudents = new List<IStudent>();
            this.onlineStudents = new List<IStudent>();
            this.lectures = new List<ILecture>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeek;
            }
            set
            {
                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("The number of 3 / 11 lectures per week must be between 1 and 7!");
                }
                else
                {
                    this.lecturesPerWeek = value;
                }
            }
        }

        public DateTime StartingDate
        {
            get
            {
                return this.startingDate;
            }
            set
            {
                this.startingDate = value;
            }
        }

        public DateTime EndingDate
        {
            get
            {
                return this.endingDate;
            }
            set
            {
                this.endingDate = value;
            }
        }

        public IList<IStudent> OnsiteStudents
        {
            get
            {
                return this.onsiteStudents;
            }
        }

        public IList<IStudent> OnlineStudents
        {
            get
            {
                return this.onlineStudents;
            }
        }

        public IList<ILecture> Lectures
        {
            get
            {
                return this.lectures;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($"* Course:\n - Name: {this.Name}\n - Lectures per week: {this.LecturesPerWeek}\n - Starting date: {this.StartingDate}\n - Ending date: {this.EndingDate}\n - Onsite students: {this.OnsiteStudents.Count}\n - Online students: {this.OnlineStudents.Count}\n - Lectures:\n  ");
            if (this.Lectures.Count == 0)
            {
                result.Append("* There are no lectures in this course!");
            }
            else
            {
                result.Append(string.Join("\n  ", this.Lectures));
            }

            return result.ToString();
        }
    }
}
