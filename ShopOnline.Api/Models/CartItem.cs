namespace ShopOnline.Api.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconCSS { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
    }
}
