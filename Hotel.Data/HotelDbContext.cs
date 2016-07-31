namespace Hotel.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class HotelDbContext : IdentityDbContext<User>
    {
        public HotelDbContext()
            : base("HotelConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public static HotelDbContext Create()
        {
            return new HotelDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Author)
                .WithMany(r => r.Reviews)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}