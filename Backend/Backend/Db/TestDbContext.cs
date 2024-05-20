using Backend.Dto;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Backend.Db
{
    public partial class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options)
           : base(options)
        {
        }
        public DbSet<TrBpkbDto> TrBpkbs { get; set; }
        public DbSet<MsStorageLocationDto> MsStorageLocations { get; set; }
        public DbSet<MsUserDto> MsUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MsUserDto>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.ToTable("ms_user"); 
            });

            modelBuilder.Entity<MsStorageLocationDto>(entity =>
            {
                entity.HasKey(e => e.LocationId);
                entity.ToTable("ms_storage_location");
            });

            modelBuilder.Entity<TrBpkbDto>(entity =>
            {
                entity.HasKey(e => e.AgreementNumber);
                entity.HasOne(e => e.StorageLocation)
                      .WithMany()
                      .HasForeignKey(e => e.LocationId)
                      .OnDelete(DeleteBehavior.Restrict);
                entity.ToTable("tr_bpkb");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
