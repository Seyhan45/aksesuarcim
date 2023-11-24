using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace aksesuarcim.Models;

public class Products
{
    [Key]
   
    public int product_Id { get; set; }
    
    public string? product_Name { get; set; } 
  
    public int? product_Code { get; set; }

    public int product_price { get; set; }
    public string? image { get; set; }
   

    public string? detail { get; set; } 
   
    public int? discount { get; set; }
    
  
   
    public int? CategoryId { get; set; }

    
    virtual public Category? Category { get; set; }
    public string? union { get; set; }

    public string? criterion { get; set; }

    [NotMapped]
    public IFormFile? ResimYukle { get; set; }





}
