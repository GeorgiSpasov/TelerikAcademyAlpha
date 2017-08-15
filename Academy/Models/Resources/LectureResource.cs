using Academy.Models.Contracts;
using System;
using System.Text;

namespace Academy.Models.Resources
{
    public abstract class LectureResource : ILectureResource
    {
        private string name;
        private string url;

        public LectureResource(string name, string url)
        {
            this.Name = name;
            this.Url = url;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 3 || value.Length > 15)
                {
                    throw new ArgumentException("Resource name should be between 3 and 15 symbols long!");
                }
                this.name = value;
            }
        }

        public string Url
        {
            get
            {
                return this.url;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5 || value.Length > 150)
                {
                    throw new ArgumentException("Resource url should be between 5 and 150 symbols long!");
                }
                this.url = value;
            }
        }

        public string Type { get; set; }

        public abstract string ResourceSpecificData();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($@"* Resource:
     - Name: {this.Name}
     - Url: {this.Url}
     - Type: {this.Type}
");

            if (this.ResourceSpecificData() != "")
            {
                result.AppendFormat($"{this.ResourceSpecificData()}");
            }

            return result.ToString();
        }
    }
}
