namespace VirtualShop.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}