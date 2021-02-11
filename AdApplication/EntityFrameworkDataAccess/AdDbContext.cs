using System.Threading;
using System.Threading.Tasks;
using AdApplication.EntityFrameworkDataAccess.Configurations;
using AdApplication.Models.Ad;
using AdApplication.Models.Categories;
using AdApplication.Models.Metric;
using BuildingBlock.DataAccess.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace AdApplication.EntityFrameworkDataAccess
{
    public class AdDbContext : DbContext, IUnitOfWork
    {
        public AdDbContext(DbContextOptions<AdDbContext> options) : base(options)
        {
        }
        
        public DbSet<Ad> Ads { get; set; }

        public DbSet<AdCategory> AdCategories { get; set; }
        
        public DbSet<AdMetric> AdMetrics { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Metric> Metrics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            
            modelBuilder.ApplyConfiguration(new MetricEntityTypeConfiguration());
            
            modelBuilder.ApplyConfiguration(new AdEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new AdCategoryEntityTypeConfiguration());
            
            modelBuilder.ApplyConfiguration(new AdMetricEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await SaveChangesAsync(cancellationToken);

            return result != 0;
        }
    }
}