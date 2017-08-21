using System;
using System.Collections.Generic;
using System.Text;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeek;
        private DateTime startingDate;
        private DateTime endingDate;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = startingDate.AddDays(30);
            this.OnsiteStudents = new List<IStudent>();
            this.OnlineStudents = new List<IStudent>();
            this.Lectures = new List<ILecture>();
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
                this.name = value;
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
                    throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeek = value;
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

        public IList<IStudent> OnsiteStudents { get; private set; }

        public IList<IStudent> OnlineStudents { get; private set; }

        public IList<ILecture> Lectures { get; private set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($@"* Course:
 - Name: {this.Name}
 - Lectures per week: {this.LecturesPerWeek}
 - Starting date: {this.StartingDate}
 - Ending date: {this.EndingDate}
 - Onsite students: {this.OnsiteStudents.Count}
 - Online students: {this.OnlineStudents.Count}
 - Lectures:
  ");
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
