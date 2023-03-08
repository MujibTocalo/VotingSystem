using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Models
{
    public class Comelec
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
   
    }
}
