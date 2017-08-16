using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Lecture : ILecture
    {
        private string name;

        public Lecture(string name, DateTime date, ITrainer trainer)
        {
            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.Resources = new List<ILectureResource>();
        }


        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }

        public DateTime Date { get; set; }

        public ITrainer Trainer { get; set; }

        public IList<ILectureResource> Resources { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($"* Lecture:\n   - Name: {this.Name}\n   - Date: {this.Date}\n   - Trainer username: {this.Trainer.Username}\n   - Resources:\n    ");
            if (this.Resources.Count == 0)
            {
                result.Append("* There are no resources in this lecture.");
            }
            else
            {
                result.Append(string.Join("\n    ", this.Resources));
            }

            return result.ToString();
        }
    }
}
