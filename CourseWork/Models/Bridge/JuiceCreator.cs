namespace CourseWork.Models.Bridge
{
    public class JuiceCreator : ICreator
    {
        public Ice AddIce()
        {
            return Ice.JUICE;
        }

        public Sugar AddSugar()
        {
            return Sugar.JUICE;
        }

        public Statics FillLiquid()
        {
            return Statics.JUICE;
        }
    }
}
