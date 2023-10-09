using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aksesuarcim.Models;

public class Shopping
{
    [Key]
   public int shoppingId { get; set; }


   [ForeignKey("Products")]
   public int product_Id { get; set; }

   public int order_amount { get; set; }

   public ICollection<Products> products { get; set; }
}
