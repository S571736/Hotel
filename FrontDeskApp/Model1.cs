namespace FrontDeskApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<bookings> bookings { get; set; }
        public virtual DbSet<customer> customer { get; set; }
        public virtual DbSet<rooms> rooms { get; set; }
        public virtual DbSet<services> services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<bookings>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.firstName)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.lastName)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.bookings)
                .WithRequired(e => e.customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rooms>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<rooms>()
                .HasMany(e => e.bookings)
                .WithRequired(e => e.rooms)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<services>()
                .Property(e => e.serviceType)
                .IsUnicode(false);

            modelBuilder.Entity<services>()
                .Property(e => e.serviceStatus)
                .IsUnicode(false);

            modelBuilder.Entity<services>()
                .Property(e => e.note)
                .IsUnicode(false);
        }
    }
}
