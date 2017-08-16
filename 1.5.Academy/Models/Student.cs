using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academy.Models
{
    public class Student : User, IStudent
    {
        private Track track;

        public Student(string username, Track track) : base(username)
        {
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }

        public Track Track
        {
            get
            {
                return this.track;
            }
            set
            {
                if (!Enum.IsDefined(typeof(Track), value))
                {
                    throw new ArgumentException("The provided track is not valid!");
                }
                this.track = value;
            }
        }

        public IList<ICourseResult> CourseResults { get; set; }

        public override string GetUserSpecificData()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($@"- Track: {this.Track}
 - Course results:
 ");
            if (this.CourseResults == null || this.CourseResults.Count == 0)
            {
                result.Append(" * User has no course results!");
            }
            else
            {
                result.Append(string.Join("\n  ", this.CourseResults));
            }

            return result.ToString();
        }
    }
}
