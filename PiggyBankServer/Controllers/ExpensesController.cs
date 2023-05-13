using Microsoft.AspNetCore.Mvc;
using piggy_bank_server.Services;

namespace piggy_bank_server.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpenses _expenses;

    public ExpensesController(IExpenses expenses)
    {
        _expenses = expenses;
    }

    [HttpGet(Name = "GetExpenses")]
    public IEnumerable<Expense> Get()
    {
        return _expenses.Expenses;
    }
}

