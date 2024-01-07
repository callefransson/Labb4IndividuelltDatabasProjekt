using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Labb4IndividuelltDatabasProjekt.Models;

public partial class SchoolContext : DbContext
{
    public SchoolContext()
    {
    }

    public SchoolContext(DbContextOptions<SchoolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Proffesion> Proffesions { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-V6VVKPT\\SQLEXPRESS;Database=School; Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.ClassId).HasColumnName("ClassID");
            entity.Property(e => e.ClassName).HasMaxLength(50);
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.CourseStatus)
                .HasMaxLength(10)
                .HasDefaultValueSql("('Active')");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentsId);

            entity.Property(e => e.EnrollmentsId).HasColumnName("EnrollmentsID");
            entity.Property(e => e.FkcourseId).HasColumnName("FKCourseID");
            entity.Property(e => e.FkgradesId).HasColumnName("FKGradesID");
            entity.Property(e => e.FkstaffId).HasColumnName("FKStaffID");
            entity.Property(e => e.FkstudentId).HasColumnName("FKStudentID");
            entity.Property(e => e.GradeSetDay).HasColumnType("date");

            entity.HasOne(d => d.Fkcourse).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkcourseId)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Fkgrades).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkgradesId)
                .HasConstraintName("FK_Enrollments_Grades");

            entity.HasOne(d => d.Fkstaff).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkstaffId)
                .HasConstraintName("FK_Enrollments_Staffs");

            entity.HasOne(d => d.Fkstudent).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.FkstudentId)
                .HasConstraintName("FK_Enrollments_Students1");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.GradesId);

            entity.Property(e => e.GradesId).HasColumnName("GradesID");
            entity.Property(e => e.Grade1).HasColumnName("Grade");
        });

        modelBuilder.Entity<Proffesion>(entity =>
        {
            entity.Property(e => e.ProffesionId).HasColumnName("ProffesionID");
            entity.Property(e => e.ProffesionName).HasMaxLength(50);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("TR_SetSex"));

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.FkproffesionId).HasColumnName("FKProffesionID");
            entity.Property(e => e.StaffFirstName).HasMaxLength(50);
            entity.Property(e => e.StaffLastName)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StaffSex)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StaffSsn)
                .HasMaxLength(20)
                .HasColumnName("StaffSSN");
            entity.Property(e => e.StaffStartDate).HasColumnType("date");

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkclassId)
                .HasConstraintName("FK_Staffs_Classes");

            entity.HasOne(d => d.Fkproffesion).WithMany(p => p.Staff)
                .HasForeignKey(d => d.FkproffesionId)
                .HasConstraintName("FK_Staffs_Proffesions");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.FkclassId).HasColumnName("FKClassID");
            entity.Property(e => e.SocialSecurityNumber).HasMaxLength(20);
            entity.Property(e => e.StudentEmail).HasMaxLength(100);
            entity.Property(e => e.StudentFirstName).HasMaxLength(50);
            entity.Property(e => e.StudentLastName).HasMaxLength(50);

            entity.HasOne(d => d.Fkclass).WithMany(p => p.Students)
                .HasForeignKey(d => d.FkclassId)
                .HasConstraintName("FK_Students_Classes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
