using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PigyBankServer.Models;

namespace PiggyBankServer.Data;
public static class DbInitializer
{

    public static IEnumerable<Expense> Expenses => new[]
    {
            new Expense()
            {
                Tag = "Food",
                Amount = 120,
            },
            new Expense()
            {
                Tag = "Travel",
                Amount = 72,
            },
            new Expense()
            {
                Tag = "Entertainment",
                Amount = 100,
            },
        };

    public static IEnumerable<Income> Incomes => new[]
    {
            new Income()
            {
                Tag = "Salary",
                Amount = 1000,
            }
        };

    public static void Initialize(ExpensesContext expenseContext, IncomeContext incomeContext)
    {
        incomeContext.Database.EnsureCreated();
        var databaseCreator = expenseContext.GetService<IRelationalDatabaseCreator>();
        databaseCreator.CreateTables();

        Initialize(expenseContext, Expenses, (context) => context.Expenses.Any());
        Initialize(incomeContext, Incomes, (context) => context.Incomes.Any());
    }

    public static void Initialize<T, K>(T context, IEnumerable<K> data, Predicate<T> hasBeenSeed) where T : DbContext
    {
        if (hasBeenSeed(context))
        {
            return;
        }

        foreach (var item in data)
        {
            context.Add(item);
        }

        context.SaveChanges();
    }

}

