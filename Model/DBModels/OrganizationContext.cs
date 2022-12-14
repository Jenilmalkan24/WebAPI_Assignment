using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model.DBModels;

public partial class OrganizationContext : DbContext
{
    public OrganizationContext()
    {
    }

    public OrganizationContext(DbContextOptions<OrganizationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=BLR-7W5GL13-L\\SQLEXPRESS;Database=Organization;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.CurrentProject).HasMaxLength(50);
            entity.Property(e => e.EmployeeName).HasMaxLength(50);
            entity.Property(e => e.JoiningDate).HasMaxLength(50);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("Admin");



            entity.Property(e => e.AdminId)
                 .ValueGeneratedNever()
                 .HasColumnName("AdminID");
            entity.Property(e => e.Email).HasColumnName("Email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(50)
                .HasColumnName("AdminName");
            entity.Property(e => e.Manager).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
