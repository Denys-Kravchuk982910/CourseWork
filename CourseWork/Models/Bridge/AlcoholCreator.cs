namespace CourseWork.Models.Bridge
{
    public class AlcoholCreator : ICreator
    {
        public Ice AddIce()
        {
            return Ice.ALCOHOL;
        }

        public Sugar AddSugar()
        {
            return Sugar.ALCOHOL;
        }

        public Statics FillLiquid()
        {
            return Statics.ALCOHOL;
        }
    }
}
