using CourseWork.Services;

namespace CourseWork.Models
{
    public interface IManagerProduct
    {
        public void AddProperties(RestaurantService service);
        public void RemoveMoldyProduct(Guid productCode);
        public void MoveToKitchen(Guid productCode);
        public void MoveToStorage(Guid productCode);
    }

    public class ManagerProduct : IManagerProduct
    {
        public KitchenService? _kitchenService { get; set; }
        public StorageService? _storageService { get; set; }

        public void AddProperties(RestaurantService service) 
        {
            if (service is KitchenService)
            {
                this._kitchenService = service as KitchenService;
            } 
            else if (service is StorageService)
            {
                this._storageService = service as StorageService;
            }
        }

        public void RemoveMoldyProduct(Guid productCode) 
        {
            this._kitchenService?.RemoveProduct(productCode);
            this._storageService?.RemoveProduct(productCode);
        }

        public void MoveToKitchen(Guid productCode) 
        {
            double value = this._storageService!.GetWeight(productCode);
            this._kitchenService!.AddWeight(productCode, value);
            this._storageService.RemoveProduct(productCode);
        }

        public void MoveToStorage(Guid productCode) 
        {
            double value = this._kitchenService!.GetWeight(productCode);
            this._storageService!.AddWeight(productCode, value);
            this._kitchenService.RemoveProduct(productCode);
        }
    }
}
