using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class BalconyDirection
{
    public int Id { get; set; }

    public string NameDirection { get; set; } = null!;

    public virtual ICollection<RealEstateInfomation> RealEstateInfomations { get; set; } = new List<RealEstateInfomation>();
}
