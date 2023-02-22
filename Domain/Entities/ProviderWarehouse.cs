using System;
using System.Collections.Generic;

namespace NetProviders.Models;

public partial class ProviderWarehouse
{
    public int Id { get; set; }

    public int IdProvider { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public bool? Status { get; set; }
}
