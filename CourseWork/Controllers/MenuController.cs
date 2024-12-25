using CourseWork.Data;
using CourseWork.Data.Entities;
using CourseWork.Models;
using CourseWork.Models.Bridge;
using CourseWork.Models.Builders;
using CourseWork.Models.Decorators;
using CourseWork.Models.Visitors;
using CourseWork.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private EFContext _context;
        private KitchenService _kitchenService;
        private StorageService _storageService;
        private DrinkService _drinkService;
        private Dictionary<string, string> _ingredients;
        private IVisitor _visitor;

        public MenuController(EFContext context, IIngredientsDictionary ingredients,
            IManagerProduct managerProduct, IVisitor visitor)
        {
            this._context = context;
            this._storageService = new StorageService(this._context);
            this._kitchenService = new KitchenService(this._storageService, this._context);
            _drinkService = new DrinkService(this._context);

            managerProduct.AddProperties(this._storageService);
            managerProduct.AddProperties(this._kitchenService);

            this._ingredients = ingredients.Ingredients;
            this._visitor = visitor;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            this._kitchenService.AddProduct(product);
            return Created("/", new { });
        }

        [HttpGet]
        [Route("transfer")]
        public IActionResult MoveProduct([FromQuery] Guid productCode, [FromQuery] double count) 
        {
            var productOnSt = _context.StorageProducts
                .Where(pr => pr.ProductCode == productCode).FirstOrDefault();

            var kp = _context.KitchenProducts
                        .FirstOrDefault(x => x.ProductCode == productCode);

            if (productOnSt != null)
            {
                double accessiblePlace = count;

                if (productOnSt.Weight > accessiblePlace)
                {
                    productOnSt.Weight -= accessiblePlace;
                }
                else if (productOnSt.Weight <= accessiblePlace)
                {
                    accessiblePlace = productOnSt.Weight;

                    _context.StorageProducts.Remove(productOnSt);
                }

                if (kp != null)
                {
                    kp.Weight += accessiblePlace;
                }
                else
                {
                    KitchenProduct newKP = new KitchenProduct
                    {
                        ProductCode = productCode,
                        Weight = accessiblePlace,
                        Title = productOnSt.Title,
                    };

                    _context.KitchenProducts.Add(newKP);
                }

                _context.SaveChanges();
            } 
            else
            {
                return NotFound("Product with given Id hasn't been found!");
            }


            return Ok("Transfered successfully!");
        }

        [HttpGet]
        [Route("giveset/{number}")]
        public IActionResult GiveSet(int number) 
        {
            Sushi sushi;
            SushiGenerator generator;

            switch (number)
            {
                case 1:
                    {
                        generator = new SushiGenerator(new SalmonSushiBuilder());
                        generator.FormSushi();

                        sushi = generator.GetSushiSet();
                        break;
                    }

                case 2:
                default:
                    {
                        generator = new SushiGenerator(new CrabSushiBuilder());
                        generator.FormSushi();

                        sushi = generator.GetSushiSet();
                        break;
                    }
            }

            if (sushi != null)
            {
                foreach (var ingredient in sushi.Ingredients)
                {
                    var kitchenProduct = _context.KitchenProducts
                        .FirstOrDefault(kp => kp.ProductCode == ingredient.ProductCode);

                    if (kitchenProduct != null)
                    {
                        if (kitchenProduct.Weight >= ingredient.Weight)
                        {
                            kitchenProduct.Weight -= ingredient.Weight;

                            if (kitchenProduct.Weight <= 0)
                            {
                                _context.KitchenProducts.Remove(kitchenProduct);
                            }
                        }
                        else
                        {
                            return BadRequest($"You need to transfer " +
                                $"{this._ingredients[kitchenProduct.ProductCode.ToString()]} into kitchen");
                        }

                        _context.SaveChanges();
                    }
                    else
                    {
                        return BadRequest($"You need to transfer " +
                            $"{this._ingredients[ingredient.ProductCode.ToString()]} into kitchen");
                    }
                }
            }

            if (sushi != null)
            {
                SushiDecorator sushiDecorator = new MenuSushi(sushi);

                sushiDecorator.FormSet();

                return Ok(sushi);
            }

            return NotFound("This set isn't defined in our restaurant");
        }

        [HttpPost]
        [Route("getdrink")]
        public IActionResult GetDrink([FromForm] CoctailModel coctail) 
        {
            MojitoCreator mojitoCreator = new MojitoCreator();
            JuiceCreator juiceCreator = new JuiceCreator();
            AlcoholCreator alcoholCreator = new AlcoholCreator();

            #region Form Coctail

            ICocktailBuilder cocktailBuilder = new CocktailBuilder();

            switch (coctail.Water)
            {
                case Statics.MOJITO:
                    {
                        cocktailBuilder._creator = mojitoCreator;
                        break;
                    }

                case Statics.JUICE:
                    {
                        cocktailBuilder._creator = juiceCreator;
                        break;
                    }

                case Statics.ALCOHOL:
                    {
                        cocktailBuilder._creator = alcoholCreator;
                        break;
                    }
            }

            cocktailBuilder.AddLiquid();

            switch (coctail.Sugar)
            {
                case Sugar.MOJITO:
                    {
                        cocktailBuilder._creator = mojitoCreator;
                        break;
                    }

                case Sugar.JUICE:
                    {
                        cocktailBuilder._creator = juiceCreator;
                        break;
                    }

                case Sugar.ALCOHOL:
                    {
                        cocktailBuilder._creator = alcoholCreator;
                        break;
                    }
            }

            cocktailBuilder.AddSugar();

            switch (coctail.Ice)
            {
                case Ice.MOJITO:
                    {
                        cocktailBuilder._creator = mojitoCreator;
                        break;
                    }

                case Ice.JUICE:
                    {
                        cocktailBuilder._creator = juiceCreator;
                        break;
                    }

                case Ice.ALCOHOL:
                    {
                        cocktailBuilder._creator = alcoholCreator;
                        break;
                    }
            }

            cocktailBuilder.AddIce();

            #endregion

            Coctail coctailRes = cocktailBuilder.GetCoctail();

            this._visitor.CheckDrinkService(this._drinkService);

            _drinkService.RemoveDrink(coctailRes);

            return Ok(coctailRes);
        }

        [HttpPost]
        [Route("adddrink")]
        public IActionResult AddDrink([FromBody] DrinkModel drinkModel) 
        {
            this._visitor.CheckDrinkService(this._drinkService);

            _drinkService.AddDrinks(drinkModel.ProductCode, drinkModel.Count);

            return Created("/", new { });
        }
    }
    
}
