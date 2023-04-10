using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using VotingSystem.Models;
using VotingSystem.Data;

namespace VotingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //dDatabase.SetInitializer<ApplicationDbContext>(null);
        }

        public virtual DbSet<Organizations> Organizations { get; set; }
        public virtual DbSet<Ballots> Ballots { get; set; }
        public virtual DbSet<Voters> Voters { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Candidates> Candidates { get; set; }
        public virtual DbSet<Comelecs> Comelecs { get; set; }

        public virtual DbSet<Admins> Admins { get; set; }






    }
}
