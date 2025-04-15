

using Invoices.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Invoices.Data;

public class InvoicesDbContext : DbContext
{
    public DbSet<Person>? Persons { get; set; }
    public DbSet<Invoice>? Invoices { get; set; }


    public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Invoice>().HasOne(i => i.Seller).WithMany(p => p.Sells).HasForeignKey(i => i.SellerId).OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Invoice>().HasOne(i => i.Buyer).WithMany(p => p.Purchases).HasForeignKey(i => i.BuyerId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Invoice>().Property(i => i.Price).HasColumnType("decimal");
        
    }
}