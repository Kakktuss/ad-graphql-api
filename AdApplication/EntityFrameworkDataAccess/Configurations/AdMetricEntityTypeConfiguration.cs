using AdApplication.Models.Ad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdApplication.EntityFrameworkDataAccess.Configurations
{
    public class AdMetricEntityTypeConfiguration : IEntityTypeConfiguration<AdMetric>
    {
        public void Configure(EntityTypeBuilder<AdMetric> builder)
        {
            builder.ToTable("AdMetrics");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .Metadata
                .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasOne(e => e.Ad)
                .WithMany(e => e.Metrics)
                .HasForeignKey(e => e.AdId);

            builder.HasIndex(e => e.AdId)
                .HasDatabaseName("UIX_AdMetrics_AdId");
            
            builder.HasOne(e => e.Metric)
                .WithMany(e => e.Ads)
                .HasForeignKey(e => e.MetricId);
            
            builder.HasIndex(e => e.MetricId)
                .HasDatabaseName("UIX_AdMetrics_MetricId");
        }
    }
}