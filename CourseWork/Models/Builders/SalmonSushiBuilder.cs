using CourseWork.Models.Builder;

namespace CourseWork.Models.Builders
{
    public class SalmonSushiBuilder : SushiBuilder
    {
        public override void AddSalmon()
        {
            SushiIngredient salmon = new SushiIngredient()
            { ProductCode = new Guid("9e7bd6cd-4c24-4e93-9c4f-bffdf04d73e6"), Weight = 100 };

            this.sushi.Ingredients.Add(salmon);
        }

        public override void AddCaviar()
        {
            SushiIngredient caviar = new SushiIngredient()
            { ProductCode = new Guid("1af29c5e-f600-4b08-b277-fd2f299eddc7"), Weight = 50 };

            this.sushi.Ingredients.Add(caviar);
        }

        public override void AddCrab()
        {
            
        }

        public override void AddCucumber()
        {
            
        }

        public override void SetNumber()
        {
            this.sushi.SetNumber = "#1 Sushi with salmon";
        }
    }
}
