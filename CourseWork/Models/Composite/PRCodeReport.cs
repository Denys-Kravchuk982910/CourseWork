using CourseWork.Services;

namespace CourseWork.Models.Composite
{
    public class PRCodeReport : IReport
    {
        private Dictionary<string, string> _ingredients;

        public PRCodeReport(IIngredientsDictionary ingredients)
        {
            _ingredients = ingredients.Ingredients;
        }

        public void AddReport(IReport report)
        {
            Console.WriteLine("The last element in chain");
        }

        public string GetReport()
        {
            string codes = "";

            foreach (var key in this._ingredients.Keys)
            {
                codes += $"\t\t{key}: {this._ingredients[key]}\n";
            }

            return codes;
        }
    }
}
