using System;

namespace Academy.Models.Resources
{
    public class VideoResource : LectureResource
    {
        public VideoResource(string name, string url) : base(name, url)
        {
            base.Type = "Video";
        }

        public DateTime UploadedOn { get; set; }

        public override string ResourceSpecificData()
        {
            string result = string.Format($"     - Uploaded on: {this.UploadedOn}");

            return result;
        }
    }
}
