using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VoluntariatModel
{
    public partial class VoluntariatEntitiesModel : DbContext
    {
        public VoluntariatEntitiesModel()
            : base("name=VoluntariatEntitiesModel")
        {
        }

        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Office> Offices { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Office>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.Office)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Sponsor>()
                .HasMany(e => e.Events)
                .WithOptional(e => e.Sponsor)
                .WillCascadeOnDelete();
        }
    }
}
