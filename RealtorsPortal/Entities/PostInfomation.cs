using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class PostInfomation
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();
}
