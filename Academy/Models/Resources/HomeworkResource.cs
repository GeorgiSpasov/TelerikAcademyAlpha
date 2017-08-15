using System;

namespace Academy.Models.Resources
{
    public class HomeworkResource : LectureResource
    {
        private DateTime dueDate;

        public HomeworkResource(string name, string url) : base(name, url)
        {
            base.Type = "Homework";
        }

        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value.AddDays(7);
            }
        }

        public override string ResourceSpecificData()
        {
            string result = string.Format($"     - Due date: {this.DueDate}");

            return result;
        }
    }
}
