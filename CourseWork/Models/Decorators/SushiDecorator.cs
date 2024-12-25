namespace CourseWork.Models.Decorators
{
    public class SushiDecorator : Sushi
    {
        protected Sushi _sushi { get; set; }

        public SushiDecorator(Sushi Sushi)
        {
            this._sushi = Sushi;
        }

        public virtual Sushi GetDecoratedSushi() 
        {
            return this._sushi;
        }

        public override void FormSet()
        {
            
        }
    }

    public class MenuSushi : SushiDecorator
    {
        public MenuSushi(Sushi sushi) : base(sushi)
        {}

        public override void FormSet()
        {
            base.FormSet();

            SushiIngredient wasabi = new SushiIngredient()
            { ProductCode = new Guid("cbdbfe13-bb32-4cf4-9f36-5c2c9205e41f"), Weight = 100 };

            SushiIngredient sauce = new SushiIngredient()
            { ProductCode = new Guid("fd14e07c-96fc-4642-b0f1-372cff3d17ab"), Weight = 50 };

            this._sushi.Ingredients.Add(wasabi);
            this._sushi.Ingredients.Add(sauce);
        }
    }
}
