using CourseWork.Models.Builder;

namespace CourseWork.Models.Builders
{
    public class CrabSushiBuilder : SushiBuilder
    {
        public override void AddCaviar()
        {
            
        }

        public override void AddCrab()
        {
            SushiIngredient crab = new SushiIngredient()
            { ProductCode = new Guid("38bbbe6c-dc2e-4906-9b17-865e6c482eaf"), Weight = 100 };

            this.sushi.Ingredients.Add(crab);
        }

        public override void AddCucumber()
        {
            SushiIngredient cucumber = new SushiIngredient()
            { ProductCode = new Guid("af0384c6-8f9f-4ab1-b0b5-cf768b5eb2d1"), Weight = 50 };
            
            this.sushi.Ingredients.Add(cucumber);
        }

        public override void AddSalmon()
        {

        }

        public override void SetNumber()
        {
            this.sushi.SetNumber = "#2 Sushi with crab";
        }
    }
}
