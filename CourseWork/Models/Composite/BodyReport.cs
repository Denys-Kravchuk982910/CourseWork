using CourseWork.Services;

namespace CourseWork.Models.Composite
{
    public class BodyReport : IReport
    {
        protected List<IReport> _reports { get; set; }
        public KitchenService _kitchenService { get; set; }
        public StorageService _storageService { get; set; }
        private Dictionary<string, string> _ingredients { get; set; }

        public BodyReport(KitchenService kitchenService, 
            StorageService storageService, IIngredientsDictionary ingredients)
        {
            _kitchenService = kitchenService;
            _storageService = storageService;
            _ingredients = ingredients.Ingredients;


            _reports = new List<IReport>();
        }

        public string GetReport()
        {
            string kItems = "\n\tПродукти на кухні: \n";

            foreach (var item in this._kitchenService.GetProducts())
            {
                kItems += $"\t{this._ingredients[item.ProductCode.ToString()]}: {item.Weight} грам\n";
            }

            kItems += "\n\tПродукти на складі: \n";

            foreach (var item in this._storageService.GetProducts())
            {
                kItems += $"\t{this._ingredients[item.ProductCode.ToString()]}: {item.Weight} грам\n";
            }

            kItems += "\n\t\tКоди продуктів:\n";

            foreach (var item in this._reports)
            {
                kItems += item.GetReport();
            }

            return kItems;
        }

        public void AddReport(IReport report)
        {
            this._reports.Add(report);
        }
    }
}
