using System;
namespace piggy_bank_server.Services
{
	public interface IExpenses
	{
		IEnumerable<Expense> Expenses { get; }
	}
}

