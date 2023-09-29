using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.UserPermission.Data.Entities;

public partial class UserPermissionContext : DbContext
{
    public UserPermissionContext()
    {
    }

    public UserPermissionContext(DbContextOptions<UserPermissionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupPermission> GroupPermissions { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<Key> Keys { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<UserPermission> UserPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Group");

            entity.HasIndex(e => e.Deleted, "IX_FILTER_Deleted").HasFilter("([Deleted]=(0))");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupPermission>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("GroupPermission");

            entity.HasIndex(e => e.GroupIdentifier, "IX_GroupPermission_Group");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.SubUnitId).HasColumnName("SubUnitID");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("GroupUser");

            entity.HasIndex(e => e.GroupIdentifier, "IX_GroupUser_Group");

            entity.HasIndex(e => e.UserId, "IX_GroupUser_User");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Key>(entity =>
        {
            entity.HasKey(e => e.Identifier).HasName("PK_PermissionKey");

            entity.ToTable("Key");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Deleted)
                .HasMaxLength(10)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.KeyValue)
                .HasMaxLength(350)
                .HasColumnName("Key");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("Permission");

            entity.HasIndex(e => e.Deleted, "IX_FILTER_Deleted").HasFilter("([Deleted]=(0))");

            entity.HasIndex(e => e.KeyId, "IX_Permission_Key");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Key).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.KeyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Permission_Key");
        });

        modelBuilder.Entity<UserPermission>(entity =>
        {
            entity.HasKey(e => e.Identifier);

            entity.ToTable("UserPermission");

            entity.Property(e => e.Identifier).HasDefaultValueSql("(newid())");
            entity.Property(e => e.OrganizationId).HasColumnName("OrganizationID");
            entity.Property(e => e.SubUnitId).HasColumnName("SubUnitID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Permission).WithMany(p => p.UserPermissions)
                .HasForeignKey(d => d.PermissionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserPermission_Permission");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
