using System;
using System.Collections.Generic;

namespace NetProviders.Models;

public partial class ProviderBankAccount
{
    public int Id { get; set; }

    public int IdProvider { get; set; }

    public string Name { get; set; } = null!;

    public string Iban { get; set; } = null!;

    public bool? Status { get; set; }
}
