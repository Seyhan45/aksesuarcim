using System.ComponentModel.DataAnnotations;

namespace aksesuarcim.Models;

public class Orders
{
    [Key]
    public int order_Id { get; set; }

    public int product_Id { get; set; }

    public int order_amount { get; set; }

}
