using System.ComponentModel.DataAnnotations;

namespace aksesuarcim.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Display(Name = "Kategori Adı")]
    [Required(ErrorMessage = "Bu Alan Boş Bırakılmaz")]
    public string? CategoryName { get; set; }
    public List<Products>? Products { get; set; }

}
