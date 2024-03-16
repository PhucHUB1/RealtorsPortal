using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class TypeRealestate
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<BasicInfomation> BasicInfomations { get; set; } = new List<BasicInfomation>();
}
