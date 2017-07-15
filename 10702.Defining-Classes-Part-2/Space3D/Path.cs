﻿using System.Collections.Generic;

namespace _10702.Defining_Classes_Part_2.Space3D
{
    public class Path
    {
        private List<Point3D> pointSequence;
        public Path(List<Point3D> pointSequence)
        {
            this.PointSequence = pointSequence;
        }
        public List<Point3D> PointSequence
        {
            get
            {
                return this.pointSequence;
            }
            set
            {
                this.pointSequence = value;
            }
        }
    }
}