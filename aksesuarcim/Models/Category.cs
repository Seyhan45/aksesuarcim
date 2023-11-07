using System.ComponentModel.DataAnnotations;

namespace aksesuarcim.Models;

public class Category
{
    [Key]
    [Display(Name = "Kategori Id")]
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Kategori Adını Boş Bırakamazsınız")]
    [Display(Name = "Kategori Adı")]
    public string? CategoryName { get; set; }

    virtual public  List<Products>? Products { get; set; }
}
