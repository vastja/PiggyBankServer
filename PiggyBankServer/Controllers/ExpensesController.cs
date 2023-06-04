using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using piggy_bank_server.Data;

namespace piggy_bank_server.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly ExpensesContext _expenses;

    public ExpensesController(ExpensesContext expenses)
    {
        _expenses = expenses;
    }

    [HttpGet]
    public IEnumerable<Expense> GetExpenses()
    {
        return _expenses.Expenses;
    }

    [HttpPost]
    public async Task<ActionResult<Expense>> CreateExpense([FromBody] Expense expense)
    {
        _expenses.Expenses.Add(expense);
        await _expenses.SaveChangesAsync();

        return CreatedAtAction(nameof(GetExpenses), new { id = expense.Id }, expense);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Expense>> DeleteExpense(int id)
    {

        Expense? expense = _expenses.Expenses.Where(e => e.Id == id).FirstOrDefault();
        if (expense is not null)
        {
            _expenses.Expenses.Remove(expense);
            await _expenses.SaveChangesAsync();

            return expense;
        }

        return new NotFoundResult();

    }
}

