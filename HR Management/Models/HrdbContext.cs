using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Models;

public partial class HrdbContext : DbContext
{
    public HrdbContext()
    {
    }

    public HrdbContext(DbContextOptions<HrdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Et> Ets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BISSU\\SQLEXPRESS;Database=hrdb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Et>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__ET__78113481E4D9AC60");

            entity.ToTable("ET");

            entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");
            entity.Property(e => e.Department)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
