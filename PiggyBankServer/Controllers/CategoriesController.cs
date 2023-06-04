using Microsoft.AspNetCore.Mvc;
using PiggyBankServer.Computation;
using PiggyBankServer.Data;
using PiggyBankServer.Models;

namespace PiggyBankServer.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CategoriesController
	{
        private readonly ExpensesContext _expenses;

        public CategoriesController(ExpensesContext expenses)
		{
            _expenses = expenses;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return CategoriesComputation.ComputeCategories(_expenses.Expenses);
        }

    }
}

