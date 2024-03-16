using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class ImageVideo
{
    public int Id { get; set; }

    public string? Image { get; set; }

    public string? VideoLink { get; set; }

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();
}
