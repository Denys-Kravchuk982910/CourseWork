using CourseWork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.Data.Configuration
{
    public class KitchenConfiguration : IEntityTypeConfiguration<KitchenProduct>
    {
        public void Configure(EntityTypeBuilder<KitchenProduct> builder)
        {
            builder.ToTable("tblKitchenProducts");

            builder.HasKey(obj => obj.Id);
        }
    }
}
