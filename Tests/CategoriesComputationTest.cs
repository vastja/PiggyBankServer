using PiggyBankServer;
using PiggyBankServer.Computation;
using PiggyBankServer.Models;

namespace Tests
{
    public class CategoriesComputationTest
	{

        private readonly IEnumerable<Expense> _expenses = new[]
        {
            new Expense()
            {
                Tag = "Other",
                Amount = 245.50m,
            },
            new Expense()
            {
                Tag = "Food",
                Amount = 560.50m
            },
            new Expense()
            {
                Tag = "Entertainment",
                Amount = 295
            },
            new Expense()
            {
                Tag = "Food",
                Amount = 500
            },
            new Expense()
            {
                Tag = "Food Outside",
                Amount = 600
            },
            new Expense()
            {
                Tag = "Other",
                Amount = 345
            }
        };

        [Fact]
		public void GroupByTag()
		{
            var grouped = CategoriesComputation.GroupExpensesByTag(_expenses);

            Assert.Equal(590.50m, grouped["Other"]);
            Assert.Equal(1060.50m, grouped["Food"]);
            Assert.Equal(295, grouped["Entertainment"]);
            Assert.Equal(600, grouped["Food Outside"]);
        }

        [Fact]
        public void GroupByTag_EmptyInput_EmptyOutput()
        {
            var grouped = CategoriesComputation.GroupExpensesByTag(Enumerable.Empty<Expense>());
            Assert.Empty(grouped);
        }

        [Fact]
        public void ComputeCategories()
        {
            var categories = CategoriesComputation.ComputeCategories(_expenses);

            var other = new Category() { Tag = "Other", Amount = 590.50m , Percentage = 23.19f};
            Assert.Contains(other, categories);
            var food = new Category() { Tag = "Food", Amount = 1060.50m , Percentage = 41.65f};
            Assert.Contains(food, categories);
            var entertainment = new Category() { Tag = "Entertainment", Amount = 295, Percentage = 11.59f };
            Assert.Contains(entertainment, categories);
            var foodOutside = new Category() { Tag = "Food Outside", Amount = 600, Percentage = 23.57f};
            Assert.Contains(foodOutside, categories);
        }
    }
}

