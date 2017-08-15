namespace Academy.Models.Resources
{
    public class DemoResource : LectureResource
    {
        public DemoResource(string name, string url) : base(name, url)
        {
            base.Type = "Demo";
        }

        public override string ResourceSpecificData()
        {
            return "";
        }
    }
}
