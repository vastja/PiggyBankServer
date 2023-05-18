using Microsoft.AspNetCore.Mvc;
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

    [HttpGet(Name = "GetExpenses")]
    public IEnumerable<Expense> Get()
    {
        return _expenses.Expenses;
    }
}

