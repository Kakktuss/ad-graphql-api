using AdApplication.Models.Ad;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdApplication.EntityFrameworkDataAccess.Configurations
{
    public class AdEntityTypeConfiguration : IEntityTypeConfiguration<Ad>
    {
        public void Configure(EntityTypeBuilder<Ad> builder)
        {
            builder.ToTable("Ads");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .Metadata
                .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(e => e.Uuid)
                .IsRequired();
            
            builder.HasIndex(e => e.Uuid)
                .IsUnique()
                .HasDatabaseName("UIX_Ads_Uuid");

            builder.Property(e => e.Title)
                .IsRequired();

            builder.Property(e => e.Description)
                .IsRequired();
        }
    }
}