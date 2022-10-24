namespace WebApiAssigment2.DTOs
{
    public class UpdateProductRequest
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Manufacture { get; set; } = null!;
    }
}