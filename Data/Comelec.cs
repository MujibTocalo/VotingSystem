using System.ComponentModel.DataAnnotations;
using VotingSystem.Data;

namespace VotingSystem.Models
{
    public class Comelec
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }

        public string user { get; set; }

        public int? organizationId { get; set; }

        public virtual Organizations Organizations { get; set; }
   
    }
}
