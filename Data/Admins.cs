using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Admins
    {
        [Key]
        public int id { get; set; }

        public string user { get; set; }

        public string name { get; set; }
        public string password { get; set; }

    }
}
