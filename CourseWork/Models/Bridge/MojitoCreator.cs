namespace CourseWork.Models.Bridge
{
    public class MojitoCreator : ICreator
    {
        public Ice AddIce()
        {
            return Ice.MOJITO;
        }

        public Sugar AddSugar()
        {
            return Sugar.MOJITO;
        }

        public Statics FillLiquid()
        {
            return Statics.MOJITO;
        }
    }
}
