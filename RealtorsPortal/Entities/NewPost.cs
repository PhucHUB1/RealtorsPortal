using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class NewPost
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int BasicInfomationId { get; set; }

    public int PostInfomationId { get; set; }

    public int RealEstateInfomationId { get; set; }

    public int ImageVideoId { get; set; }

    public int ContactInfomation { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual BasicInfomation BasicInfomation { get; set; } = null!;

    public virtual ContactInfomation ContactInfomationNavigation { get; set; } = null!;

    public virtual ImageVideo ImageVideo { get; set; } = null!;

    public virtual ICollection<ListPost> ListPosts { get; set; } = new List<ListPost>();

    public virtual PostInfomation PostInfomation { get; set; } = null!;

    public virtual RealEstateInfomation RealEstateInfomation { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
