using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Ballots
    {
        [Key]
        public int id { get; set; }

        public int? votersId { get; set; }

        public int? candidateId { get; set; }

        public int? positionId { get; set; }

        public int? organizationId { get; set; }
       

        public virtual Voters  voters { get; set; }

        public virtual Candidates candidate { get; set; }

        public virtual Organizations organization { get; set; }
        public virtual Positions position { get; set; }

    }

}
