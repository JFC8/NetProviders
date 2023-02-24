using System;
using System.Collections.Generic;

namespace NetProviders.Models;

public partial class ProviderPaymentsMethod
{
    public int IdProvider { get; set; }

    public int IdPayment { get; set; }
}
