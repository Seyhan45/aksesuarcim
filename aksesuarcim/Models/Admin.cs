using System.ComponentModel.DataAnnotations;

namespace aksesuarcim.Models;

public class Admin
{
    [Key]
    [Display(Name ="Admin Id")]
    public int admin_Id { get; set; }
    [Display(Name = "Admin Adı")]
    public string? email { get; set; }
    [Display(Name = "Admin Şifresi")]
    public string? password { get; set; }

}
