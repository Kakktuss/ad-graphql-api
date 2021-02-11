using AdApplication.Models.Ad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdApplication.EntityFrameworkDataAccess.Configurations
{
    public class AdCategoryEntityTypeConfiguration : IEntityTypeConfiguration<AdCategory>
    {
        public void Configure(EntityTypeBuilder<AdCategory> builder)
        {
            builder.ToTable("AdCategories");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .Metadata
                .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.HasOne(e => e.Ad)
                .WithMany(e => e.Categories)
                .HasForeignKey(e => e.AdId);
            
            builder.HasIndex(e => e.AdId)
                .HasDatabaseName("UIX_AdCategories_AdId");

            builder.HasOne(e => e.Category)
                .WithMany(e => e.Ads)
                .HasForeignKey(e => e.CategoryId);
            
            builder.HasIndex(e => e.CategoryId)
                .HasDatabaseName("UIX_AdCategories_CategoryId");
        }
    }
}