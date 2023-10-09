using aksesuarcim.Models;
using Microsoft.EntityFrameworkCore;

namespace aksesuarcim.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    public DbSet<Category> categories { get; set; }

    public DbSet<Products> products { get; set; }

    public DbSet<Orders> orders { get; set; }

    public DbSet<Shopping> shoppings { get; set; }

    public DbSet<Admin> admins { get; set; }

}