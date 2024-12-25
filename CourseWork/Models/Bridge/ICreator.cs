namespace CourseWork.Models.Bridge
{
    public interface ICreator
    {
        Statics FillLiquid();

        Sugar AddSugar();
        Ice AddIce();
    }
}
