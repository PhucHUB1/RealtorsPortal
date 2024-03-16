using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class ContactInfomation
{
    public int Id { get; set; }

    public string ContactName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string? ContactEmail { get; set; }

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();
}
