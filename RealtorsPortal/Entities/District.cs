using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class District
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? NameEn { get; set; }

    public string? FullName { get; set; }

    public string? FullNameEn { get; set; }

    public string? CodeName { get; set; }

    public string? ProvinceCode { get; set; }

    public virtual ICollection<BasicInfomation> BasicInfomations { get; set; } = new List<BasicInfomation>();

    public virtual Province? ProvinceCodeNavigation { get; set; }

    public virtual ICollection<Ward> Wards { get; set; } = new List<Ward>();
}
