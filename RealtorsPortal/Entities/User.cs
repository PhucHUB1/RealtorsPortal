using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string? PersonalTaxCode { get; set; }

    public string? Picture { get; set; }

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();
}
