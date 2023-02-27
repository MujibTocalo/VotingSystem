using System;
using System.ComponentModel.DataAnnotations;

namespace VotingSystem.Data
{
    public class Organizations
    {
        [Key]
        public int id { get; set; }

        public string name { get; set; }
    }
}
