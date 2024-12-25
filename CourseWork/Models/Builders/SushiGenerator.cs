using CourseWork.Models.Builder;

namespace CourseWork.Models.Builders
{
    public class SushiGenerator
    {
        private SushiBuilder _builder { get; set; }

        public SushiGenerator(SushiBuilder builder)
        {
            _builder = builder;
        }

        public void FormSushi()
        {
            _builder.CreateSushiSet();

            _builder.AddCaviar();
            _builder.AddCrab();
            _builder.AddSalmon();
            _builder.AddCucumber();
            _builder.SetNumber();
        }

        public Sushi GetSushiSet()
        {
            return _builder.GetSushiSet();
        }
    }
}
