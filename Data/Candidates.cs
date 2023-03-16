using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Candidates
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }

        public int votes { get; set; }

        public int? positionId { get; set; }

        public int? organizationId { get; set; }

        public virtual Positions position { get; set; }
        public virtual Organizations organization { get; set; }

    }
}
