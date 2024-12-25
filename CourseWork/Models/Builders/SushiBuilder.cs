namespace CourseWork.Models.Builder
{
    public abstract class SushiBuilder
    {
        protected Sushi sushi { get; private set; }

        public void CreateSushiSet() 
        {
            this.sushi = new Sushi();
            this.sushi.FormSet();
        }

        public Sushi GetSushiSet() 
        {
            return this.sushi;
        }

        public abstract void AddSalmon();
        public abstract void AddCaviar();
        public abstract void AddCrab();
        public abstract void AddCucumber();
        public abstract void SetNumber();
    }
}
