using Microsoft.EntityFrameworkCore;
using PigyBankServer.Models;

namespace PiggyBankServer.Data;

public class IncomeContext : DbContext
{
    public DbSet<Income> Incomes { get; set; }

    public IncomeContext(DbContextOptions<IncomeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Income>().ToTable("Income");
    }
}

