using System;

namespace _10702.Defining_Classes_Part_2
{
    [AttributeUsage(AttributeTargets.Struct
        | AttributeTargets.Class
        | AttributeTargets.Interface
        | AttributeTargets.Enum
        | AttributeTargets.Method, AllowMultiple = false)]
    public class VersionAttribute : Attribute
    {
        public string Major { get; private set; }
        public string Minor { get; private set; }

        public VersionAttribute(string version)
        {
            this.Major = version.Split('.')[0];
            this.Minor = version.Split('.')[1];
        }
    }
}
