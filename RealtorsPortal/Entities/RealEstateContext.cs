using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RealtorsPortal.Entities;

public partial class RealEstateContext : DbContext
{
    public RealEstateContext()
    {
    }

    public RealEstateContext(DbContextOptions<RealEstateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BalconyDirection> BalconyDirections { get; set; }

    public virtual DbSet<BasicInfomation> BasicInfomations { get; set; }

    public virtual DbSet<ContactInfomation> ContactInfomations { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<HouseDirection> HouseDirections { get; set; }

    public virtual DbSet<ImageVideo> ImageVideos { get; set; }

    public virtual DbSet<Interior> Interiors { get; set; }

    public virtual DbSet<Juridical> Juridicals { get; set; }

    public virtual DbSet<ListPost> ListPosts { get; set; }

    public virtual DbSet<NewPost> NewPosts { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PostInfomation> PostInfomations { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<RealEstateInfomation> RealEstateInfomations { get; set; }

    public virtual DbSet<TypePosting> TypePostings { get; set; }

    public virtual DbSet<TypeRealestate> TypeRealestates { get; set; }

    public virtual DbSet<Unit> Units { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Ward> Wards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\PHUCPC,1433; Database=RealEstate;User=Real estate;Password=123456;TrustServerCertificate=true;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BalconyDirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__balcony___3214EC07CA675FCF");

            entity.ToTable("balcony_direction");

            entity.HasIndex(e => e.NameDirection, "UQ__balcony___5C429003F87FC43D").IsUnique();

            entity.Property(e => e.NameDirection).HasMaxLength(100);
        });

        modelBuilder.Entity<BasicInfomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__basic_in__3214EC070E002DFD");

            entity.ToTable("basic_infomation");

            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.DistrictId).HasMaxLength(20);
            entity.Property(e => e.ProvinceId).HasMaxLength(20);
            entity.Property(e => e.WardsId).HasMaxLength(20);

            entity.HasOne(d => d.District).WithMany(p => p.BasicInfomations)
                .HasForeignKey(d => d.DistrictId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_district");

            entity.HasOne(d => d.Province).WithMany(p => p.BasicInfomations)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_province");

            entity.HasOne(d => d.TypePosting).WithMany(p => p.BasicInfomations)
                .HasForeignKey(d => d.TypePostingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__basic_inf__TypeP__46B27FE2");

            entity.HasOne(d => d.TypeRealEstate).WithMany(p => p.BasicInfomations)
                .HasForeignKey(d => d.TypeRealEstateId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__basic_inf__TypeR__47A6A41B");

            entity.HasOne(d => d.Wards).WithMany(p => p.BasicInfomations)
                .HasForeignKey(d => d.WardsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_wards");
        });

        modelBuilder.Entity<ContactInfomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__contact___3214EC073A8E2E7E");

            entity.ToTable("contact_infomation");

            entity.Property(e => e.ContactEmail).HasMaxLength(100);
            entity.Property(e => e.ContactName).HasMaxLength(255);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("districts_pkey");

            entity.ToTable("districts");

            entity.HasIndex(e => e.ProvinceCode, "idx_districts_province");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
            entity.Property(e => e.ProvinceCode)
                .HasMaxLength(20)
                .HasColumnName("province_code");

            entity.HasOne(d => d.ProvinceCodeNavigation).WithMany(p => p.Districts)
                .HasForeignKey(d => d.ProvinceCode)
                .HasConstraintName("districts_province_code_fkey");
        });

        modelBuilder.Entity<HouseDirection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__house_di__3214EC0763B485B6");

            entity.ToTable("house_direction");

            entity.HasIndex(e => e.NameDirection, "UQ__house_di__5C4290032BCEE328").IsUnique();

            entity.Property(e => e.NameDirection).HasMaxLength(100);
        });

        modelBuilder.Entity<ImageVideo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__image_vi__3214EC0744A0DCBC");

            entity.ToTable("image_video");
        });

        modelBuilder.Entity<Interior>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__interior__3214EC0777EE265D");

            entity.ToTable("interior");

            entity.HasIndex(e => e.InteriorType, "UQ__interior__89D62051631740B2").IsUnique();

            entity.Property(e => e.InteriorType).HasMaxLength(100);
        });

        modelBuilder.Entity<Juridical>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__juridica__3214EC0737DE4C17");

            entity.ToTable("juridical");

            entity.HasIndex(e => e.JuridicalType, "UQ__juridica__76D203E6E9BD9A12").IsUnique();

            entity.Property(e => e.JuridicalType).HasMaxLength(100);
        });

        modelBuilder.Entity<ListPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__list_pos__3214EC07067B562A");

            entity.ToTable("list_post");

            entity.HasOne(d => d.Post).WithMany(p => p.ListPosts)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__list_post__PostI__76619304");
        });

        modelBuilder.Entity<NewPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__new_post__3214EC07CF35A7A9");

            entity.ToTable("new_post");

            entity.Property(e => e.DateTime).HasColumnType("datetime");

            entity.HasOne(d => d.BasicInfomation).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.BasicInfomationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__BasicI__6FB49575");

            entity.HasOne(d => d.ContactInfomationNavigation).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.ContactInfomation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__Contac__73852659");

            entity.HasOne(d => d.ImageVideo).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.ImageVideoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__ImageV__72910220");

            entity.HasOne(d => d.PostInfomation).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.PostInfomationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__PostIn__70A8B9AE");

            entity.HasOne(d => d.RealEstateInfomation).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.RealEstateInfomationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__RealEs__719CDDE7");

            entity.HasOne(d => d.User).WithMany(p => p.NewPosts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__new_post__UserId__6EC0713C");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__package__3214EC075A5B3E4C");

            entity.ToTable("package");

            entity.HasIndex(e => e.PackageName, "UQ__package__73856F7A79B79CDD").IsUnique();

            entity.Property(e => e.PackageName).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 3)");
        });

        modelBuilder.Entity<PostInfomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__post_inf__3214EC0778CE9728");

            entity.ToTable("post_infomation");

            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("provinces_pkey");

            entity.ToTable("provinces");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");
        });

        modelBuilder.Entity<RealEstateInfomation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__real_est__3214EC07D6BE23B1");

            entity.ToTable("real_estate_infomation");

            entity.Property(e => e.Acreage).HasMaxLength(1);
            entity.Property(e => e.Facade).HasMaxLength(1);
            entity.Property(e => e.NumberOfBathrooms).HasMaxLength(100);
            entity.Property(e => e.NumberOfBedrooms).HasMaxLength(100);
            entity.Property(e => e.NumberOfFloors).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(12, 3)");
            entity.Property(e => e.WayIn).HasMaxLength(1);

            entity.HasOne(d => d.BalconyDirection).WithMany(p => p.RealEstateInfomations)
                .HasForeignKey(d => d.BalconyDirectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__real_esta__Balco__531856C7");

            entity.HasOne(d => d.HouseDirection).WithMany(p => p.RealEstateInfomations)
                .HasForeignKey(d => d.HouseDirectionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__real_esta__House__5224328E");

            entity.HasOne(d => d.Interior).WithMany(p => p.RealEstateInfomations)
                .HasForeignKey(d => d.InteriorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__real_esta__Inter__51300E55");

            entity.HasOne(d => d.Juridical).WithMany(p => p.RealEstateInfomations)
                .HasForeignKey(d => d.JuridicalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__real_esta__Jurid__503BEA1C");

            entity.HasOne(d => d.Unit).WithMany(p => p.RealEstateInfomations)
                .HasForeignKey(d => d.UnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__real_esta__UnitI__4F47C5E3");
        });

        modelBuilder.Entity<TypePosting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_pos__3214EC073EEBF6F2");

            entity.ToTable("type_postings");

            entity.HasIndex(e => e.TypeName, "UQ__type_pos__D4E7DFA8F5D2D9FC").IsUnique();

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<TypeRealestate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__type_rea__3214EC0752EE34DE");

            entity.ToTable("type_realestate");

            entity.HasIndex(e => e.TypeName, "UQ__type_rea__D4E7DFA83F37C300").IsUnique();

            entity.Property(e => e.TypeName).HasMaxLength(100);
        });

        modelBuilder.Entity<Unit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__unit__3214EC07A04AAFE9");

            entity.ToTable("unit");

            entity.HasIndex(e => e.UnitName, "UQ__unit__B5EE66786F7E4C74").IsUnique();

            entity.Property(e => e.UnitName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3214EC0752DABE3B");

            entity.ToTable("users");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PersonalTaxCode).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<Ward>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("wards_pkey");

            entity.ToTable("wards");

            entity.HasIndex(e => e.DistrictCode, "idx_wards_district");

            entity.Property(e => e.Code)
                .HasMaxLength(20)
                .HasColumnName("code");
            entity.Property(e => e.CodeName)
                .HasMaxLength(255)
                .HasColumnName("code_name");
            entity.Property(e => e.DistrictCode)
                .HasMaxLength(20)
                .HasColumnName("district_code");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .HasColumnName("full_name");
            entity.Property(e => e.FullNameEn)
                .HasMaxLength(255)
                .HasColumnName("full_name_en");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NameEn)
                .HasMaxLength(255)
                .HasColumnName("name_en");

            entity.HasOne(d => d.DistrictCodeNavigation).WithMany(p => p.Wards)
                .HasForeignKey(d => d.DistrictCode)
                .HasConstraintName("wards_district_code_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
