using System;
using System.Collections.Generic;

namespace NetProviders.Models;

public partial class ProviderContact
{
    public int Id { get; set; }

    public int IdProvider { get; set; }

    public string Department { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Phone2 { get; set; }
}
