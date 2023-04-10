namespace VotingSystem.Data
{
    public class Comelecs
    {
        public int id { get; set; }
        public string name { get; set; }

        public string user { get; set; }

        public string password { get; set; }

        public int? organizationId { get; set; }

        

        public virtual Organizations organization { get; set; }
    }
}
