namespace VirtualShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public decimal Value { get; set; }
        
        public Product()
        {
            
        }

    }
}