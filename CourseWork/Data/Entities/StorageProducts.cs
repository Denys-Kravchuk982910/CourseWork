namespace CourseWork.Data.Entities
{
    public class StorageProduct
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public Guid ProductCode { get; set; }
        public DateTime LastDate { get; set; }
        public double Weight { get; set; }
    }
}
