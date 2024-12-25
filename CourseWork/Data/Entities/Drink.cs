namespace CourseWork.Data.Entities
{
    public class Drink
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Guid ProductCode { get; set; }
        public double Count { get; set; }
    }
}
