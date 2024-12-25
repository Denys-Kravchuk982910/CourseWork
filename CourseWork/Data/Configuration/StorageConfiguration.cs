using CourseWork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.Data.Configuration
{
    public class StorageConfiguration : IEntityTypeConfiguration<StorageProduct>
    {
        public void Configure(EntityTypeBuilder<StorageProduct> builder)
        {
            builder.ToTable("tblStorageProducts");

            builder.HasKey(obj => obj.Id);
        }
    }
}
