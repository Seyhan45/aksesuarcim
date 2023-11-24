using System.ComponentModel.DataAnnotations;

namespace aksesuarcim.Models
{
    public class CartItem
    {
        [Key]
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }

        public decimal Total
        {
            get { return Quantity * Price; }
        }
        public CartItem() { }
        public CartItem(Products Products)
        {
            ProductId = Products.product_Id;
            ProductName = Products.product_Name;
            Quantity = 1;
            Price = Products.product_price;
            Image = Products.image;
        }
    }
}
