using CourseWork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseWork.Data.Configuration
{
    public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.ToTable("tblDrinks");

            builder.HasKey(x => x.Id);
        }
    }
}
