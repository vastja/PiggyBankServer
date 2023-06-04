using System;
namespace PiggyBankServer.Models
{
	public class Category
	{

		public string Tag { get; set; }

		public decimal Amount { get; set; }

		public float Percentage { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Category category &&
                Tag == category.Tag &&
                Math.Abs(Amount - category.Amount) < 0.001m &&
                Math.Abs(Percentage - category.Percentage) < 0.01;
        }
    }
}

