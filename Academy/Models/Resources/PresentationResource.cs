namespace Academy.Models.Resources
{
    public class PresentationResource : LectureResource
    {
        public PresentationResource(string name, string url) : base(name, url)
        {
            base.Type = "Presentation";
        }

        public override string ResourceSpecificData()
        {
            return "";
        }
    }
}
