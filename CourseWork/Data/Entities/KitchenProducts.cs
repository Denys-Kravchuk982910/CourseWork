namespace CourseWork.Data.Entities
{
    public class KitchenProduct
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Guid ProductCode { get; set; }
        public double Weight { get; set; }
    }
}
