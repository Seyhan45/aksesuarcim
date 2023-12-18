using aksesuarcim.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace aksesuarcim.Data;

public class ApplicationDbContext :IdentityDbContext<AppUser, AppRole, int>
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{

	}
	public DbSet<Category>? categories { get; set; }

    public DbSet<Admin>? admins { get; set; }

	public DbSet<Slider> sliders { get; set; }

	public DbSet<Products>? Products { get; set; }

    public DbSet<CartItem>? cartItems { get; set; }
	


}