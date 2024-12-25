namespace CourseWork.Models.Bridge
{
    public interface ICocktailBuilder
    {
        void AddLiquid();
        void AddIce();
        void AddSugar();
        Coctail GetCoctail();
        ICreator _creator { get; set; }
    }

    public class CocktailBuilder : ICocktailBuilder
    {
        private Coctail _coctail { get; set; }
        public ICreator _creator { get; set; }

        public CocktailBuilder()
        {
            this._coctail = new Coctail();
        }

        public void AddIce()
        {
            Ice ice = this._creator.AddIce();

            switch (ice)
            {
                case Ice.MOJITO:
                    {
                        this._coctail.Ice = 3;
                        break;
                    }
                case Ice.JUICE:
                    {
                        this._coctail.Ice = 2;
                        break;
                    }
                case Ice.ALCOHOL:
                    {
                        this._coctail.Ice = 0;
                        break;
                    }
                default:
                    break;
            }

            this._coctail.Ice = (int)ice;
        }

        public void AddLiquid()
        {
            Statics liquid = this._creator.FillLiquid();

            switch (liquid)
            {
                case Statics.MOJITO:
                    {
                        this._coctail.Title = "Mojito";
                        break;
                    }
                case Statics.JUICE:
                    {
                        this._coctail.Title = "Juice";
                        break;
                    }
                case Statics.ALCOHOL:
                    {
                        this._coctail.Title = "Alcohol";
                        this._coctail.Alcohol = true;
                        break;
                    }
                default:
                    break;
            }
        }

        public void AddSugar()
        {
            Sugar sugar = this._creator.AddSugar();

            switch (sugar)
            {
                case Sugar.MOJITO:
                    {
                        this._coctail.Sugar = 2;
                        break;
                    }
                case Sugar.JUICE:
                    {
                        this._coctail.Ice = 0;
                        break;
                    }
                case Sugar.ALCOHOL:
                    {
                        this._coctail.Ice = 1;
                        break;
                    }
                default:
                    break;
            }
        }

        public Coctail GetCoctail()
        {
            return this._coctail;
        }
    }
}
