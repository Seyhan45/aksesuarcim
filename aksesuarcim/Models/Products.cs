using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing.Printing;

namespace aksesuarcim.Models;

public class Products
{
    [Key]
    [Display(Name ="Ürün Id")]
    public int product_Id { get; set; }
    [Required(ErrorMessage ="Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Adı")]
    public string? product_Name { get; set; }
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Kodu")]
    public int product_Code { get; set; }
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Fiyatı")]
    public int product_price { get; set; }
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Resmi")]
    public string? image { get; set; }
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Açıklaması")]
    [NotMapped]
    public IFormFile ResimYukle { get; set; }
    public string? detail { get; set; }
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün İndirimi")]
    public int discount { get; set; }
    [ForeignKey("Category")]
    [Required(ErrorMessage = "Bu Alanı Boş Bırakamazsınız")]
    [Display(Name = "Ürün Kategorisi")]

    public int CategoryId { get; set; }

    public string? union { get; set; }

    public string? criterion { get; set; }

    public ICollection<Category> Categories { get; set; }

    public Shopping  Shopping { get; set; }
    public Orders Orders { get; set; }

}
