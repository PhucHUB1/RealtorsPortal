using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class Package
{
    public int Id { get; set; }

    public string PackageName { get; set; } = null!;

    public decimal Price { get; set; }

    public string Description { get; set; } = null!;
}
