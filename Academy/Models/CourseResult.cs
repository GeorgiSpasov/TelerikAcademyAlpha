using System;

using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;
            this.Grade = DefineGrade(examPoints, coursePoints);
        }

        public ICourse Course { get; set; }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }
            set
            {
                if (value < 0 || value > 1000)
                {
                    throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
                }
                else
                {
                    this.examPoints = value;
                }
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }
            set
            {
                if (value < 0 || value > 125)
                {
                    throw new ArgumentException("Course result's course points should be between 0 and 125!");
                }
                else
                {
                    this.coursePoints = value;
                }
            }
        }

        public Grade Grade
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

        public Grade DefineGrade(float examPoints, float coursePoints)
        {
            Grade result = 0;
            if (examPoints >= 65 || coursePoints >= 75)
            {
                result = Grade.Excellent;
            }
            else if (examPoints >= 30 || coursePoints >= 45)
            {
                result = Grade.Passed;
            }
            else
            {
                result = Grade.Failed;
            }

            return result;
        }

        public override string ToString()
        {
            string result = string.Format($"  *{this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}");

            return result;
        }
    }
}
