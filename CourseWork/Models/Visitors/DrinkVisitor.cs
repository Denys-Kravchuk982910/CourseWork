using CourseWork.Data.Entities;
using CourseWork.Services;

namespace CourseWork.Models.Visitors
{
    public class RestaurantVisitor : IVisitor
    {
        public void CheckDrinkService(DrinkService service)
        {
            var drinks = service._context.Drinks.ToArray();

            if (!drinks.Any())
            {
                service.InitializeDrinks();
            }
        }
    }
}
