using System;
using System.Collections.Generic;

namespace NetProviders.Models;

public partial class Provider
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string FiscalName { get; set; } = null!;

    public string Cif { get; set; } = null!;

    /// <summary>
    /// fiscal address
    /// </summary>
    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public decimal Risk { get; set; }

    public string Insurance { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime LastUpdate { get; set; }

    public bool? Status { get; set; }
}
