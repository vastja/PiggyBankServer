using System;
using System.ComponentModel.DataAnnotations;

namespace PigyBankServer.Models;

public class Income
{
    [Key]
    public int Id { get; set; }

    public string Tag { get; set; }

    public decimal Amount { get; set; }
}


