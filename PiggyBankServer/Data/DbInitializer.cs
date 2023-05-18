namespace piggy_bank_server.Data
{
    public static class DbInitializer
    {

        public static IEnumerable<Expense> Expenses => new[]
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
            new Expense()
            {
                Id = 2,
                Tag = "Entertainment",
                Amount = 100,
            },
        };

        public static void Initialize(ExpensesContext context)
        {
            context.Database.EnsureCreated();

            if (HasBeenSeed(context))
            {
                return;
            }

            foreach (var expense in Expenses)
            {
                context.Add(expense);
            }

            context.SaveChanges();
        }

        public static bool HasBeenSeed(ExpensesContext context)
        {
            return context.Expenses.Any();
        }
    }
}

