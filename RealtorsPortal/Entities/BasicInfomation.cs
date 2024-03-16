using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class BasicInfomation
{
    public int Id { get; set; }

    public int TypePostingId { get; set; }

    public int TypeRealEstateId { get; set; }

    public string Address { get; set; } = null!;

    public string ProvinceId { get; set; } = null!;

    public string DistrictId { get; set; } = null!;

    public string WardsId { get; set; } = null!;

    public virtual District District { get; set; } = null!;

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();

    public virtual Province Province { get; set; } = null!;

    public virtual TypePosting TypePosting { get; set; } = null!;

    public virtual TypeRealestate TypeRealEstate { get; set; } = null!;

    public virtual Ward Wards { get; set; } = null!;
}
