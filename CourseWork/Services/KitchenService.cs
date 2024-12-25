using CourseWork.Data;
using CourseWork.Data.Entities;
using CourseWork.Models;

namespace CourseWork.Services
{
    public class KitchenService : RestaurantService
    {
        public EFContext _context { get; set; }
        public IIngredientsDictionary _ingredients { get; set; }
        public KitchenService(StorageService service,
            EFContext context, IIngredientsDictionary ingredients = null)
        {
            this._service = service;
            this._context = context;
            this._ingredients = ingredients;
        }
        public override void AddProduct(ProductModel product)
        {
            KitchenProduct? ks = this._context.KitchenProducts
                .Where(pr => pr.ProductCode == product.ProductCode).FirstOrDefault();

            if (ks != null && ks.Weight > 200)
            {
                this._service.AddProduct(product);
            }
            else
            {
                if (ks == null)
                {
                    KitchenProduct newKs = new KitchenProduct { 
                        Title = product.Title,
                        Weight = product.Weight,
                        ProductCode = product.ProductCode,
                    };

                    _context.KitchenProducts.Add(newKs);
                } else
                {
                    ks.Weight += product.Weight;
                }
            }

            _context.SaveChanges();
        }

        public override void RemoveProduct(Guid productCode)
        {
            var kPr = this._context.KitchenProducts
                .FirstOrDefault(x => x.ProductCode == productCode);

            if (kPr != null)
            {
                _context.KitchenProducts.Remove(kPr);
            }

            _context.SaveChanges();
        }

        public override double GetWeight(Guid productCode)
        {
            var kPr = this._context.KitchenProducts
                .FirstOrDefault(x => x.ProductCode == productCode);

            if (kPr != null)
            {
                return kPr.Weight;
            }

            return 0;
        }

        public override void AddWeight(Guid productCode, double weight)
        {
            var kPr = this._context.StorageProducts
               .FirstOrDefault(x => x.ProductCode == productCode);

            if (kPr != null)
            {
                kPr.Weight += weight;
                _context.SaveChanges();
            } 
            else
            {
                if (weight > 0)
                {
                    KitchenProduct newKpr = new KitchenProduct()
                    {
                        ProductCode = productCode,
                        Weight = weight,
                        Title = _ingredients.Ingredients[productCode.ToString()]
                    };

                    this._context.KitchenProducts.Add(newKpr);
                    this._context.SaveChanges();
                }
            }
        }

        public List<KitchenProduct> GetProducts() 
        {
            return _context.KitchenProducts.ToList();
        }
    }
}
