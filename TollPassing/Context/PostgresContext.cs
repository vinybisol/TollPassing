using Microsoft.EntityFrameworkCore;
using TollPassing.Models;

namespace TollPassing.Context
{
    public class PostgresContext : DbContext
    {
        public virtual DbSet<TollPassingModel> Passing { get; set; }

        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // PostgreSQL uses the public schema by default - not dbo.
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            //Rename Identity tables to lowercase
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                var currentTableName = modelBuilder.Entity(entity.Name).Metadata.GetDefaultTableName();
                modelBuilder.Entity(entity.Name).ToTable(currentTableName.ToLower());
            }

            TableBuildTollPassingModel(modelBuilder);
        }
        public void TableBuildTollPassingModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TollPassingModel>(entity =>
            {
                entity.ToTable("passing");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
                entity.Property(x => x.Vehicle).HasColumnName("pas_vehicle");
                entity.Property(x => x.LicensePlate).HasColumnName("pas_plate");
                entity.Property(x => x.Price).HasColumnName("pas_price");
                entity.Property(x => x.DateTime).HasColumnName("pas_datetime");
                entity.Property(x => x.DateTimeModification).HasColumnName("pas_modifiedin")
                .HasDefaultValueSql("now()");
            });
        }
    }
}
