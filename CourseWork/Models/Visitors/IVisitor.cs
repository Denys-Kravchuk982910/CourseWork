using CourseWork.Services;

namespace CourseWork.Models.Visitors
{
    public interface IVisitor
    {
        void CheckDrinkService(DrinkService service);
    }
}
