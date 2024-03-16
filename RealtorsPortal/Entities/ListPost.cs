using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class ListPost
{
    public int Id { get; set; }

    public int PostId { get; set; }

    public virtual NewPost Post { get; set; } = null!;
}
