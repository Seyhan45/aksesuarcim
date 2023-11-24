using aksesuarcim.Models;

namespace aksesuarcim.Dto
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; }

        public decimal GrandTotal { get; set; }
    }
}
