using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sims.Models.Relations;

namespace Sims.Models.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public DbSet<Sim> Sims { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ActivityRequiresSkill> ActivityRequiresSkillsTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ActivityRequiresSkill>().HasKey(m => new { m.SkillID, m.ActivityID });
            modelBuilder.Entity<ActivityRequiresSkill>().Property(a => a.ActivityID).ValueGeneratedNever();
            modelBuilder.Entity<ActivityRequiresSkill>().Property(a => a.SkillID).ValueGeneratedNever();


            
        }
    }
}
