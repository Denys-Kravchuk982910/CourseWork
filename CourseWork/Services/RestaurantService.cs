using CourseWork.Models;

namespace CourseWork.Services
{
    public abstract class RestaurantService
    {
        protected RestaurantService _service { get; set; }

        public virtual void AddProduct(ProductModel product)
        {
            if (_service != null)
            {
                _service.AddProduct(product);
            }
        }

        public virtual void RemoveProduct(Guid productCode)
        {
            if (_service != null)
            {
                _service.RemoveProduct(productCode);
            }
        }

        public abstract double GetWeight(Guid productCode);
        public abstract void AddWeight(Guid productCode, double weight);
    }
}
