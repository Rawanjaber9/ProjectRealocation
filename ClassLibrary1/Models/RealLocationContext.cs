using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Models;

public partial class RealLocationContext : DbContext
{
    public RealLocationContext()
    {
    }

    public RealLocationContext(DbContextOptions<RealLocationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<DestinationCountry> DestinationCountries { get; set; }

    public virtual DbSet<GetPostComment> GetPostComments { get; set; }

    public virtual DbSet<Mission> Missions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<SelectedMission> SelectedMissions { get; set; }

    public virtual DbSet<Term> Terms { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-N2Q4FF9\\SQLEXPRESS;Database=RealLocation;Trusted_Connection=True;Encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertNumber);

            entity.ToTable("Alert");

            entity.Property(e => e.AlertNumber).ValueGeneratedNever();
            entity.Property(e => e.AlertDate).HasColumnType("datetime");
            entity.Property(e => e.AlertName).HasMaxLength(50);
            entity.Property(e => e.AlertType).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_Alert_Users");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName);

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentNumber);

            entity.ToTable("Comment");

            entity.Property(e => e.CommentNumber).ValueGeneratedNever();
            entity.Property(e => e.CommentContent).HasMaxLength(50);
            entity.Property(e => e.PostDate).HasColumnType("date");
        });

        modelBuilder.Entity<DestinationCountry>(entity =>
        {
            entity.HasKey(e => e.CountryName);

            entity.ToTable("DestinationCountry");

            entity.Property(e => e.CountryName).HasMaxLength(50);
        });

        modelBuilder.Entity<GetPostComment>(entity =>
        {
            entity.HasKey(e => new { e.PostNumber, e.CommentNumber });

            entity.ToTable("GetPostComment");

            entity.Property(e => e.CountryName).HasMaxLength(50);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.AlertNumberNavigation).WithMany(p => p.GetPostComments)
                .HasForeignKey(d => d.AlertNumber)
                .HasConstraintName("FK_GetPostComment_Alert");

            entity.HasOne(d => d.CommentNumberNavigation).WithMany(p => p.GetPostComments)
                .HasForeignKey(d => d.CommentNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GetPostComment_Comment");

            entity.HasOne(d => d.PostNumberNavigation).WithMany(p => p.GetPostComments)
                .HasForeignKey(d => d.PostNumber)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GetPostComment_Post");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.GetPostComments)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_GetPostComment_Users");
        });

        modelBuilder.Entity<Mission>(entity =>
        {
            entity.HasKey(e => new { e.CategoryName, e.MissionNumber });

            entity.ToTable("Mission");

            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.ExecutionStatus).HasMaxLength(50);
            entity.Property(e => e.Location)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.MissionEndDate).HasColumnType("date");
            entity.Property(e => e.MissionName).HasMaxLength(50);
            entity.Property(e => e.MissionStartDate).HasColumnType("date");
            entity.Property(e => e.Opinion).HasMaxLength(50);
            entity.Property(e => e.PersnoalRemark).HasMaxLength(50);
            entity.Property(e => e.Urgency)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.AlertNumberNavigation).WithMany(p => p.Missions)
                .HasForeignKey(d => d.AlertNumber)
                .HasConstraintName("FK_Mission_Alert");

            entity.HasOne(d => d.CategoryNameNavigation).WithMany(p => p.Missions)
                .HasForeignKey(d => d.CategoryName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mission_Category");

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.Missions)
                .HasForeignKey(d => d.UserName)
                .HasConstraintName("FK_Mission_Users");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostNumber);

            entity.ToTable("Post");

            entity.Property(e => e.PostNumber).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(50);
            entity.Property(e => e.PostDate).HasColumnType("date");
        });

        modelBuilder.Entity<SelectedMission>(entity =>
        {
            entity.HasKey(e => new { e.UserName, e.MissionNumber });

            entity.ToTable("SelectedMission");

            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasOne(d => d.UserNameNavigation).WithMany(p => p.SelectedMissions)
                .HasForeignKey(d => d.UserName)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SelectedMission_Users");
        });

        modelBuilder.Entity<Term>(entity =>
        {
            entity.HasKey(e => e.VersionNumber);

            entity.Property(e => e.VersionNumber).ValueGeneratedNever();
            entity.Property(e => e.ChangesHistory).HasMaxLength(50);
            entity.Property(e => e.Details).HasMaxLength(50);
            entity.Property(e => e.LastUpdateDate).HasColumnType("date");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.Property(e => e.UserName).HasMaxLength(50);
            entity.Property(e => e.CountryName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.JoinDate).HasColumnType("date");
            entity.Property(e => e.KidsYn).HasColumnName("KidsYN");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.TransitionDate).HasColumnType("date");

            entity.HasOne(d => d.CountryNameNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.CountryName)
                .HasConstraintName("FK_Users_Country");

            entity.HasOne(d => d.VersionNumberNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.VersionNumber)
                .HasConstraintName("FK_Users_Terms");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
