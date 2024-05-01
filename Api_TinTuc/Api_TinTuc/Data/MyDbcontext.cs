using Api_TinTuc.Model;
using Microsoft.EntityFrameworkCore;

namespace Api_TinTuc.Data
{
    public class MyDbcontext:DbContext
    {
        public MyDbcontext(DbContextOptions options) : base(options)
        { }
        #region
        public DbSet<Users> users { get; set; }
        public DbSet<Tintuc> news { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Users>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Users>().Property(e => e.Name).HasMaxLength(255);
            modelBuilder.Entity<Users>().Property(e => e.Username).HasMaxLength(255);
            modelBuilder.Entity<Users>().Property(e => e.Password).HasMaxLength(255);
            // Table News
            modelBuilder.Entity<Tintuc>().ToTable("Tintuc");
            modelBuilder.Entity<Tintuc>().Property(e => e.Id_News).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tintuc>().Property(e => e.Content).HasMaxLength(int.MaxValue);
            modelBuilder.Entity<Tintuc>().Property(e => e.Image).HasMaxLength(int.MaxValue);

        }
    }
}
