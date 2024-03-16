using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class Juridical
{
    public int Id { get; set; }

    public string JuridicalType { get; set; } = null!;

    public virtual ICollection<RealEstateInfomation> RealEstateInfomations { get; set; } = new List<RealEstateInfomation>();
}
