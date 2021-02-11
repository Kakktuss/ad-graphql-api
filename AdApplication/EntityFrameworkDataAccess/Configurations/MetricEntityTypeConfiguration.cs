using AdApplication.Models.Categories;
using AdApplication.Models.Metric;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdApplication.EntityFrameworkDataAccess.Configurations
{
    public class MetricEntityTypeConfiguration : IEntityTypeConfiguration<Metric>
    {
        public void Configure(EntityTypeBuilder<Metric> builder)
        {
            builder.ToTable("Metrics");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .Metadata
                .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(e => e.Uuid)
                .IsRequired();

            builder.HasIndex(e => e.Uuid)
                .HasDatabaseName("UIX_Metrics_Uuid")
                .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .HasDatabaseName("UIX_Metrics_Name")
                .IsUnique();
        }
    }
}