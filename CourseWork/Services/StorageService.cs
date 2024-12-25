using CourseWork.Data;
using CourseWork.Data.Entities;
using CourseWork.Models;

namespace CourseWork.Services
{
    public class StorageService : RestaurantService
    {
        public EFContext _context { get; set; }
        public IIngredientsDictionary _ingredients { get; set; }

        public StorageService(EFContext context, IIngredientsDictionary ingredients = null)
        {
            this._context = context;
            this._ingredients = ingredients;
        }
        public override void AddProduct(ProductModel product)
        {
            StorageProduct? ks = this._context.StorageProducts
                .Where(pr => pr.ProductCode == product.ProductCode).FirstOrDefault();

            if (ks != null)
            {
                ks.Weight += product.Weight;
            }
            else
            {
                StorageProduct newSp = new StorageProduct
                {
                    Title = product.Title,
                    Weight = product.Weight,
                    ProductCode = product.ProductCode,
                };

                _context.StorageProducts.Add(newSp);
            }
          
            _context.SaveChanges();
        }

        public override void RemoveProduct(Guid productCode)
        {
            var kSt = this._context.KitchenProducts
                .FirstOrDefault(x => x.ProductCode == productCode);

            if (kSt != null)
            {
                _context.KitchenProducts.Remove(kSt);
            }

            _context.SaveChanges();
        }

        public override double GetWeight(Guid productCode)
        {
            var sPr = this._context.StorageProducts
                .FirstOrDefault(x => x.ProductCode == productCode);

            if (sPr != null)
            {
                return sPr.Weight;
            }

            return 0;
        }

        public override void AddWeight(Guid productCode, double weight)
        {
            var sPr = this._context.StorageProducts
               .FirstOrDefault(x => x.ProductCode == productCode);

            if (sPr != null)
            {
                sPr.Weight += weight;
                _context.SaveChanges();
            }
            else
            {
                if (weight > 0)
                {
                    StorageProduct newSpr = new StorageProduct()
                    {
                        ProductCode = productCode,
                        Weight = weight,
                        Title = _ingredients.Ingredients[productCode.ToString()]
                    };

                    this._context.StorageProducts.Add(newSpr);
                    this._context.SaveChanges();
                }
            }
        }

        public List<StorageProduct> GetProducts()
        {
            return _context.StorageProducts.ToList();
        }
    }
}
