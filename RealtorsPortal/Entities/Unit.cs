using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class Unit
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<RealEstateInfomation> RealEstateInfomations { get; set; } = new List<RealEstateInfomation>();
}
