using Microsoft.AspNetCore.Mvc;
using PigyBankServer.Models;
using Microsoft.EntityFrameworkCore;
using PiggyBankServer.Data;

namespace PiggyBankServer.Controllers;

[ApiController]
[Route("[controller]")]
public class IncomesController : ControllerBase
{
    private readonly IncomeContext _incomes;

    public IncomesController(IncomeContext incomes)
    {
        _incomes = incomes;
    }

    [HttpGet]
    public IEnumerable<Income> GetIncomes(string? tag)
    {
        if (tag is not null)
        {
            return _incomes.Incomes.Where(e => e.Tag == tag);
        }

        return _incomes.Incomes;
    }

    [HttpPost]
    public async Task<ActionResult<Income>> CreateIncome([FromBody] Income income)
    {
        _incomes.Incomes.Add(income);
        await _incomes.SaveChangesAsync();

        return CreatedAtAction(nameof(GetIncomes), new { id = income.Id }, income);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Income>> DeleteIncome(int id)
    {

        Income? income = _incomes.Incomes.Where(e => e.Id == id).FirstOrDefault();
        if (income is not null)
        {
            _incomes.Incomes.Remove(income);
            await _incomes.SaveChangesAsync();

            return income;
        }

        return new NotFoundResult();

    }
}
