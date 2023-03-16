using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Positions

    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int? organizationId { get; set; }

        public int? candidates { get; set; }


        public virtual Organizations Organization { get; set; }

    }
}
