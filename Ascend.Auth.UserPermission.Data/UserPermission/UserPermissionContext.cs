using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ascend.Auth.UserPermission.Data.UserPermission;

public partial class UserPermissionContext : DbContext
{
    public UserPermissionContext()
    {
    }

    public UserPermissionContext(DbContextOptions<UserPermissionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=localhost;Database=UserPermissions;Encrypt=False;Trusted_Connection=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ID");
            entity.Property(e => e.Key).HasMaxLength(800);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
