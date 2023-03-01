using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Voters
    {
        [Key]
        public int id { get; set; }

        public string user { get; set; }

        public string name { get; set; }
        public string password { get; set; }
        //public string course { get; set; }


        public int? organizationId { get; set; }

        public virtual Organizations Organization { get; set; }

    }
}
