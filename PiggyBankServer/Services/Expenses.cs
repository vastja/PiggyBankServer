using System;

namespace piggy_bank_server.Services
{
	public class Expenses : IExpenses
	{
        IEnumerable<Expense> IExpenses.Expenses => new[]
        {
            new Expense()
            {
                Id = 0,
                Tag = "Food",
                Amount = 120,
            },
            new Expense()
            {
                Id = 1,
                Tag = "Travel",
                Amount = 72,
            },
        };
    }
}

