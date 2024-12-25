namespace CourseWork.Models
{
    public class Sushi
    {
        public string SetNumber { get; set; }
        public List<SushiIngredient> Ingredients { get; set; }
        
        public Sushi()
        {
            this.SetNumber = "";
            this.Ingredients = new List<SushiIngredient>();
        }

        public virtual void FormSet() 
        {
            SushiIngredient rice = new SushiIngredient() 
            { ProductCode = new Guid("0a2cbfbe-d6fc-4e17-8ba7-c08c5bdf8de8"), Weight = 75 };

            SushiIngredient nori = new SushiIngredient()
            { ProductCode = new Guid("c7d7ebe4-3823-4824-b27b-2e75a7e9b47b"), Weight = 20 };
            
            SushiIngredient cheese = new SushiIngredient()
            { ProductCode = new Guid("87f86e32-78f1-4c7e-98ab-19a352ce5c4c"), Weight = 35 };

            this.Ingredients.Add(rice);
            this.Ingredients.Add(nori);
            this.Ingredients.Add(cheese);
        }
    }

    public class SushiIngredient
    {
        public Guid ProductCode { get; set; }
        public double Weight { get; set; }
    }
}
