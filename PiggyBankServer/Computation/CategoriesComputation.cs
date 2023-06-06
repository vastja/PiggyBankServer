using PiggyBankServer.Models;

namespace PiggyBankServer.Computation
{
	public static class CategoriesComputation
	{

        public static IEnumerable<Category> ComputeCategories(IEnumerable<Expense> expenses)
        {
            Dictionary<string, decimal> groupedExpenses = GroupExpensesByTag(expenses);
            decimal total = groupedExpenses.Values.Sum();

            var categories = new Category[groupedExpenses.Count()];
            int index = 0;
            foreach (var kvp in groupedExpenses)
            {
                categories[index++] = new Category()
                {
                    Tag = kvp.Key,
                    Amount = kvp.Value,
                    Percentage = (float)(kvp.Value / total) * 100f
                };
            }

            return categories;
        }

        public static Dictionary<string, decimal> GroupExpensesByTag(IEnumerable<Expense> expenses)
        {
            Dictionary<string, decimal> categories = new();

            foreach (var expense in expenses)
            {
                if (categories.TryGetValue(expense.Tag, out decimal sum))
                {
                    categories[expense.Tag] += expense.Amount;
                }
                else
                {
                    categories.Add(expense.Tag, expense.Amount);
                }
            }

            return categories;
        }
    }
}

