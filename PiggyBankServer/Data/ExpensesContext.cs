using Microsoft.EntityFrameworkCore;

namespace PiggyBankServer.Data;

public class ExpensesContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    public ExpensesContext(DbContextOptions<ExpensesContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expense>().ToTable("Expense");
    }
}


