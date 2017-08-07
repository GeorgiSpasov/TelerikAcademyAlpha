using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Utils.Contracts;
using Academy.Models.Enums;

namespace Academy.Models
{
    public class Student : User, IStudent
    {
        private Track track;
        public Student(string username, Track track) : this(username, track, new List<ICourseResult>())
        {

        }

        public Student(string username, Track track, IList<ICourseResult> courseResults = null) : base(username)
        {
            this.Track = track;
            this.CourseResults = courseResults;
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
                else
                {
                    this.track = value;
                }
            }
        }

        public IList<ICourseResult> CourseResults { get; set; }

        public override string GetUserSpecificData()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat($"- Track: {this.Track}\n - Course results:\n ");
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
