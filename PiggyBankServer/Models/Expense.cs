
using System.ComponentModel.DataAnnotations;

namespace piggy_bank_server;

public class Expense
{
    [Key]
    public int Id { get; set; }

    public string Tag { get; set; }

    public decimal Amount { get; set; }
}

