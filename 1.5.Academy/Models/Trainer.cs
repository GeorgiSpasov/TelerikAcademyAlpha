using System.Collections.Generic;

using Academy.Models.Contracts;

namespace Academy.Models
{
    public class Trainer : User, ITrainer
    {
        public Trainer(string username, IList<string> technologies) : base(username)
        {
            this.Technologies = technologies;
        }

        public IList<string> Technologies { get; set; }

        public override string GetUserSpecificData()
        {
            string result = string.Format($"- Technologies: {string.Join("; ", this.Technologies)}");

            return result;
        }
    }
}
