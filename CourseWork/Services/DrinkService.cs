using CourseWork.Data;
using CourseWork.Data.Entities;
using CourseWork.Models.Bridge;

namespace CourseWork.Services
{
    public class DrinkService
    {
        public EFContext _context;
        private Dictionary<string, string> _drinkCodes = new Dictionary<string, string>();

        public DrinkService(EFContext context)
        {
            _drinkCodes.Add("23b3967f-40f0-4e0d-a15a-09b3c1e82e20", "Mojito");
            _drinkCodes.Add("ac8dcb77-9b8c-4b4d-ae26-f2d5af0d9c11", "Juice");
            _drinkCodes.Add("6fe99e91-74b9-499e-90df-f0e92a0b2c79", "Alcohol");
            _drinkCodes.Add("c7f3c1a8-d62b-4f18-8e0a-8136a431ca14", "Sugar");
            _drinkCodes.Add("edd71a7c-08ec-46c2-8b6e-9c9a90234b27", "Ice");

            _context = context;
        }
        public void RemoveDrink(Coctail coctail)
        {
            string code = "";
            switch (coctail.Title)
            {
                case "Mojito": 
                    {
                        code = "23b3967f-40f0-4e0d-a15a-09b3c1e82e20";
                        break;
                    }

                case "Juice":
                    {
                        code = "ac8dcb77-9b8c-4b4d-ae26-f2d5af0d9c11";
                        break;
                    }

                case "Alcohol":
                    {
                        code = "6fe99e91-74b9-499e-90df-f0e92a0b2c79";
                        break;
                    }
            }

            var drink = _context.Drinks.FirstOrDefault(x => x.ProductCode 
            == new Guid(code));

            if (drink != null)
            {
                if (drink.Count > 0)
                {
                    drink.Count--;
                } else
                {
                    throw new Exception($"{_drinkCodes[code]} doesn't exist!");
                }
            }
            
            var sugar = _context.Drinks.FirstOrDefault(x => x.ProductCode
            == new Guid("c7f3c1a8-d62b-4f18-8e0a-8136a431ca14"));

            if (sugar != null)
            {
                if (sugar.Count >= coctail.Sugar)
                {
                    sugar.Count -= coctail.Sugar;
                } else
                {
                    throw new Exception($"sugar doesn't exist!");
                }
            }
            
            var ice = _context.Drinks.FirstOrDefault(x => x.ProductCode
            == new Guid("edd71a7c-08ec-46c2-8b6e-9c9a90234b27"));

            if (ice != null)
            {
                if (ice.Count >= coctail.Ice)
                {
                    ice.Count -= coctail.Ice;
                }
                else
                {
                    throw new Exception($"ice doesn't exist!");
                }
            }

            _context.SaveChanges();
        }

        public void InitializeDrinks()
        {
            foreach (var item in _drinkCodes)
            {
                Drink drink = new Drink()
                {
                    Count = 0,
                    Title = item.Value,
                    ProductCode = new Guid(item.Key)
                };

                var pr = _context.Drinks
                    .FirstOrDefault(x => x.ProductCode == new Guid(item.Key));
                if (pr == null)
                {
                    _context.Drinks.Add(drink);
                }
            }

            _context.SaveChanges();
        }

        public void AddDrinks(Guid productCode, int count) 
        {
            var product = _context.Drinks
                .FirstOrDefault(dr => dr.ProductCode == productCode);

            if (product != null)
            {
                product.Count += count;
            }

            _context.SaveChanges();
        }
    }
}
