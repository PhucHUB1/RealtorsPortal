using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class TypePosting
{
    public int Id { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<BasicInfomation> BasicInfomations { get; set; } = new List<BasicInfomation>();
}
