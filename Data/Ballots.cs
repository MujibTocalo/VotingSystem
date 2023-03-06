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
       

        public Voters  voters { get; set; }

        public Candidates candidate { get; set; }

        public Organizations organization { get; set; }

        public Positions position { get; set; }

    }

}
