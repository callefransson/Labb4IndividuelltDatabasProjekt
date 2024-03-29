﻿// <auto-generated />
using System;
using Labb4IndividuelltDatabasProjekt.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb4IndividuelltDatabasProjekt.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Class", b =>
                {
                    b.Property<int>("ClassId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ClassID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClassId"));

                    b.Property<string>("ClassName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ClassId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourseID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CourseStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasDefaultValueSql("('Active')");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("EnrollmentsID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentsId"));

                    b.Property<int?>("FkcourseId")
                        .HasColumnType("int")
                        .HasColumnName("FKCourseID");

                    b.Property<int?>("FkgradesId")
                        .HasColumnType("int")
                        .HasColumnName("FKGradesID");

                    b.Property<int?>("FkstaffId")
                        .HasColumnType("int")
                        .HasColumnName("FKStaffID");

                    b.Property<int?>("FkstudentId")
                        .HasColumnType("int")
                        .HasColumnName("FKStudentID");

                    b.Property<DateTime?>("GradeSetDay")
                        .HasColumnType("date");

                    b.HasKey("EnrollmentsId");

                    b.HasIndex("FkcourseId");

                    b.HasIndex("FkgradesId");

                    b.HasIndex("FkstaffId");

                    b.HasIndex("FkstudentId");

                    b.ToTable("Enrollments");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Grade", b =>
                {
                    b.Property<int>("GradesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GradesID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradesId"));

                    b.Property<int?>("Grade1")
                        .HasColumnType("int")
                        .HasColumnName("Grade");

                    b.HasKey("GradesId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Proffesion", b =>
                {
                    b.Property<int>("ProffesionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProffesionID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProffesionId"));

                    b.Property<string>("ProffesionName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double?>("ProffesionSalary")
                        .HasColumnType("float");

                    b.HasKey("ProffesionId");

                    b.ToTable("Proffesions");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StaffID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffId"));

                    b.Property<int?>("FkproffesionId")
                        .HasColumnType("int")
                        .HasColumnName("FKProffesionID");

                    b.Property<string>("StaffFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StaffLastName")
                        .HasMaxLength(10)
                        .HasColumnType("nchar(10)")
                        .IsFixedLength();

                    b.Property<DateTime?>("StaffStartDate")
                        .HasColumnType("date");

                    b.HasKey("StaffId");

                    b.HasIndex("FkproffesionId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StudentID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int?>("FkclassId")
                        .HasColumnType("int")
                        .HasColumnName("FKClassID");

                    b.Property<string>("SocialSecurityNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StudentEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StudentFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.HasIndex("FkclassId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Enrollment", b =>
                {
                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Course", "Fkcourse")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkcourseId")
                        .HasConstraintName("FK_Enrollments_Courses");

                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Grade", "Fkgrades")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkgradesId")
                        .HasConstraintName("FK_Enrollments_Grades");

                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Staff", "Fkstaff")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkstaffId")
                        .HasConstraintName("FK_Enrollments_Staffs");

                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Student", "Fkstudent")
                        .WithMany("Enrollments")
                        .HasForeignKey("FkstudentId")
                        .HasConstraintName("FK_Enrollments_Students1");

                    b.Navigation("Fkcourse");

                    b.Navigation("Fkgrades");

                    b.Navigation("Fkstaff");

                    b.Navigation("Fkstudent");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Staff", b =>
                {
                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Proffesion", "Fkproffesion")
                        .WithMany("Staff")
                        .HasForeignKey("FkproffesionId")
                        .HasConstraintName("FK_Staffs_Proffesions");

                    b.Navigation("Fkproffesion");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Student", b =>
                {
                    b.HasOne("Labb4IndividuelltDatabasProjekt.Models.Class", "Fkclass")
                        .WithMany("Students")
                        .HasForeignKey("FkclassId")
                        .HasConstraintName("FK_Students_Classes");

                    b.Navigation("Fkclass");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Class", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Grade", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Proffesion", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Staff", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("Labb4IndividuelltDatabasProjekt.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
