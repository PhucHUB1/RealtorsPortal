using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class Province
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string FullName { get; set; } = null!;

    public string? FullNameEn { get; set; }

    public string? CodeName { get; set; }

    public virtual ICollection<BasicInfomation> BasicInfomations { get; set; } = new List<BasicInfomation>();

    public virtual ICollection<District> Districts { get; set; } = new List<District>();
}
