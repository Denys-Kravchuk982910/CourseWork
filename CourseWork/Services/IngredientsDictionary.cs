namespace CourseWork.Services
{
    public interface IIngredientsDictionary
    {
        Dictionary<string, string> Ingredients { get; }
    }
    public class IngredientsDictionary : IIngredientsDictionary
    {
        private Dictionary<string, string> _ingredients { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, string> Ingredients => _ingredients;

        public IngredientsDictionary()
        {
            this._ingredients.Add("0a2cbfbe-d6fc-4e17-8ba7-c08c5bdf8de8", "Rice");
            this._ingredients.Add("c7d7ebe4-3823-4824-b27b-2e75a7e9b47b", "Nori");
            this._ingredients.Add("87f86e32-78f1-4c7e-98ab-19a352ce5c4c", "Cheese");
            this._ingredients.Add("d0b1b324-6d4c-4787-85db-8e76c9e08028", "Somga");
            this._ingredients.Add("9e7bd6cd-4c24-4e93-9c4f-bffdf04d73e6", "Salmon");
            this._ingredients.Add("af0384c6-8f9f-4ab1-b0b5-cf768b5eb2d1", "Cucumber");
            this._ingredients.Add("38bbbe6c-dc2e-4906-9b17-865e6c482eaf", "Crab mince");
            this._ingredients.Add("cbdbfe13-bb32-4cf4-9f36-5c2c9205e41f", "Wasabi");
            this._ingredients.Add("fd14e07c-96fc-4642-b0f1-372cff3d17ab", "Sauce");
            this._ingredients.Add("1af29c5e-f600-4b08-b277-fd2f299eddc7", "Caviar");
        }
    }
}
