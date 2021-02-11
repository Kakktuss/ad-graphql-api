using AdApplication.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdApplication.EntityFrameworkDataAccess.Configurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .Metadata
                .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            builder.Property(e => e.Uuid)
                .IsRequired();

            builder.HasIndex(e => e.Uuid)
                .HasDatabaseName("UIX_Categories_Uuid")
                .IsUnique();

            builder.Property(e => e.Name)
                .IsRequired();

            builder.HasIndex(e => e.Name)
                .HasDatabaseName("UIX_Categories_Name")
                .IsUnique();
        }
    }
}