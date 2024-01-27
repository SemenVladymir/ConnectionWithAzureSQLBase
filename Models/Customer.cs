using System;
using System.Collections.Generic;

namespace ConnectionWithAzure.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string CustomName { get; set; } = null!;

    public string? CustomAddress { get; set; }

    public string? CustomCity { get; set; }

    public string? CustomCountry { get; set; }
}
