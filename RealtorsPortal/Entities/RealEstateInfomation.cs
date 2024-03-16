using System;
using System.Collections.Generic;

namespace RealtorsPortal.Entities;

public partial class RealEstateInfomation
{
    public int Id { get; set; }

    public string Acreage { get; set; } = null!;

    public decimal Price { get; set; }

    public int UnitId { get; set; }

    public int JuridicalId { get; set; }

    public int InteriorId { get; set; }

    public string NumberOfBedrooms { get; set; } = null!;

    public string NumberOfBathrooms { get; set; } = null!;

    public string NumberOfFloors { get; set; } = null!;

    public int HouseDirectionId { get; set; }

    public int BalconyDirectionId { get; set; }

    public string WayIn { get; set; } = null!;

    public string Facade { get; set; } = null!;

    public virtual BalconyDirection BalconyDirection { get; set; } = null!;

    public virtual HouseDirection HouseDirection { get; set; } = null!;

    public virtual Interior Interior { get; set; } = null!;

    public virtual Juridical Juridical { get; set; } = null!;

    public virtual ICollection<NewPost> NewPosts { get; set; } = new List<NewPost>();

    public virtual Unit Unit { get; set; } = null!;
}
