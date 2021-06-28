﻿// <auto-generated />
using System;
using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.Migrations
{
    [DbContext(typeof(FLSContext))]
    [Migration("20210627165426_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiledDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("PublishDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("BlogCategoryId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("DAL.Entities.BlogCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DAL.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("DAL.Entities.DepartmentBlog", b =>
                {
                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("BlogId")
                        .HasColumnType("int");

                    b.HasKey("DepartmentId", "BlogId");

                    b.HasIndex("BlogId");

                    b.ToTable("DepartmentBlog");
                });

            modelBuilder.Entity("DAL.Entities.LectureSemesterRegister", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "SemesterId");

                    b.HasIndex("SemesterId");

                    b.ToTable("LectureSemesterRegister");
                });

            modelBuilder.Entity("DAL.Entities.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("LecturerCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("LecturerTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MaxCourse")
                        .HasColumnType("int");

                    b.Property<int>("MinCourse")
                        .HasColumnType("int");

                    b.Property<int>("PriorityPoint")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("LecturerTypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Lecturer");
                });

            modelBuilder.Entity("DAL.Entities.LecturerRating", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SemesterPlanId")
                        .HasColumnType("int");

                    b.Property<int>("RatePoint")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "SemesterPlanId");

                    b.HasIndex("SemesterPlanId");

                    b.ToTable("LecturerRating");
                });

            modelBuilder.Entity("DAL.Entities.LecturerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("LecturerType");
                });

            modelBuilder.Entity("DAL.Entities.MasterPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SemesterId");

                    b.ToTable("MasterPlan");
                });

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("DAL.Entities.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("DAL.Entities.SemesterPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MasterPlanId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MasterPlanId");

                    b.HasIndex("SemesterId");

                    b.ToTable("SemesterPlan");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PreviousCode")
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.Property<string>("SubjectCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .IsUnicode(false)
                        .HasColumnType("varchar(6)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("DAL.Entities.SubjectRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SemesterPlanId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("SemesterPlanId");

                    b.HasIndex("SubjectId");

                    b.ToTable("SubjectRegister");
                });

            modelBuilder.Entity("DAL.Entities.TeachableSubject", b =>
                {
                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("MatchPoint")
                        .HasColumnType("int");

                    b.Property<int>("PreferPoint")
                        .HasColumnType("int");

                    b.HasKey("LecturerId", "SubjectId")
                        .HasName("PK_PreferSubject");

                    b.HasIndex("SubjectId");

                    b.ToTable("TeachableSubject");
                });

            modelBuilder.Entity("DAL.Entities.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time(0)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("PriorityPoint")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time(0)");

                    b.HasKey("Id");

                    b.ToTable("TimeSlot");
                });

            modelBuilder.Entity("DAL.Entities.TimeSlotRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("PreferPoint")
                        .HasColumnType("int");

                    b.Property<int>("SemesterPlanId")
                        .HasColumnType("int");

                    b.Property<int>("TimeSlotId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LecturerId");

                    b.HasIndex("SemesterPlanId");

                    b.HasIndex("TimeSlotId");

                    b.ToTable("TimeSlotRegister");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AvatarLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("date");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Fullname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("char(1)")
                        .IsFixedLength(true);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .IsUnicode(false)
                        .HasColumnType("varchar(64)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(12)
                        .IsUnicode(false)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasMaxLength(32)
                        .IsUnicode(false)
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id")
                        .HasName("PK_User_1");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.HasOne("DAL.Entities.BlogCategory", "BlogCategory")
                        .WithMany("Blogs")
                        .HasForeignKey("BlogCategoryId")
                        .HasConstraintName("FK_Blog_BlogCategory")
                        .IsRequired();

                    b.Navigation("BlogCategory");
                });

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.HasOne("DAL.Entities.Semester", "Semester")
                        .WithMany("Courses")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_Course_Semester")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Subject", "Subject")
                        .WithMany("Courses")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_Course_Subject1")
                        .IsRequired();

                    b.Navigation("Semester");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DAL.Entities.DepartmentBlog", b =>
                {
                    b.HasOne("DAL.Entities.Blog", "Blog")
                        .WithMany("DepartmentBlogs")
                        .HasForeignKey("BlogId")
                        .HasConstraintName("FK_DepartmentBlog_Blog")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Department", "Department")
                        .WithMany("DepartmentBlogs")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_DepartmentBlog_Department")
                        .IsRequired();

                    b.Navigation("Blog");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DAL.Entities.LectureSemesterRegister", b =>
                {
                    b.HasOne("DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("LectureSemesterRegisters")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_LectureSemesterRegister_Lecture")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Semester", "Semester")
                        .WithMany("LectureSemesterRegisters")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_LectureSemesterRegister_Semester")
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("DAL.Entities.Lecturer", b =>
                {
                    b.HasOne("DAL.Entities.Department", "Department")
                        .WithMany("Lectures")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Lecture_Department")
                        .IsRequired();

                    b.HasOne("DAL.Entities.LecturerType", "LecturerTypeNavigation")
                        .WithMany("Lectures")
                        .HasForeignKey("LecturerTypeId")
                        .HasConstraintName("FK_Lecture_LecturerType")
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "UserNavigation")
                        .WithMany("Lectures")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Lecture_User")
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("LecturerTypeNavigation");

                    b.Navigation("UserNavigation");
                });

            modelBuilder.Entity("DAL.Entities.LecturerRating", b =>
                {
                    b.HasOne("DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("LecturerRatings")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_LecturerRating_Lecture")
                        .IsRequired();

                    b.HasOne("DAL.Entities.SemesterPlan", "SemesterPlan")
                        .WithMany("LecturerRatings")
                        .HasForeignKey("SemesterPlanId")
                        .HasConstraintName("FK_LecturerRating_SemesterPlan")
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("SemesterPlan");
                });

            modelBuilder.Entity("DAL.Entities.MasterPlan", b =>
                {
                    b.HasOne("DAL.Entities.Semester", "Semester")
                        .WithMany("MasterPlans")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_MasterPlan_Semester")
                        .IsRequired();

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("DAL.Entities.SemesterPlan", b =>
                {
                    b.HasOne("DAL.Entities.MasterPlan", "MasterPlan")
                        .WithMany("SemesterPlans")
                        .HasForeignKey("MasterPlanId")
                        .HasConstraintName("FK_SemesterPlan_MasterPlan")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Semester", "Semester")
                        .WithMany("SemesterPlans")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("FK_SemesterPlan_Semester")
                        .IsRequired();

                    b.Navigation("MasterPlan");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.HasOne("DAL.Entities.Department", "Department")
                        .WithMany("Subjects")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Subject_Department")
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DAL.Entities.SubjectRegister", b =>
                {
                    b.HasOne("DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("SubjectRegisters")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_SubjectRegister_Lecture")
                        .IsRequired();

                    b.HasOne("DAL.Entities.SemesterPlan", "SemesterPlan")
                        .WithMany("SubjectRegisters")
                        .HasForeignKey("SemesterPlanId")
                        .HasConstraintName("FK_SubjectRegister_SemesterPlan")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Subject", "Subject")
                        .WithMany("SubjectRegisters")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_SubjectRegister_Subject1")
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("SemesterPlan");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DAL.Entities.TeachableSubject", b =>
                {
                    b.HasOne("DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("TeachableSubjects")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_PreferSubject_Lecture")
                        .IsRequired();

                    b.HasOne("DAL.Entities.Subject", "Subject")
                        .WithMany("TeachableSubjects")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("FK_TeachableSubject_Subject")
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("DAL.Entities.TimeSlotRegister", b =>
                {
                    b.HasOne("DAL.Entities.Lecturer", "Lecturer")
                        .WithMany("TimeSlotRegisters")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_TimeSlotRegister_Lecture")
                        .IsRequired();

                    b.HasOne("DAL.Entities.SemesterPlan", "SemesterPlan")
                        .WithMany("TimeSlotRegisters")
                        .HasForeignKey("SemesterPlanId")
                        .HasConstraintName("FK_TimeSlotRegister_SemesterPlan")
                        .IsRequired();

                    b.HasOne("DAL.Entities.TimeSlot", "TimeSlot")
                        .WithMany("TimeSlotRegisters")
                        .HasForeignKey("TimeSlotId")
                        .HasConstraintName("FK_TimeSlotRegister_TimeSlot")
                        .IsRequired();

                    b.Navigation("Lecturer");

                    b.Navigation("SemesterPlan");

                    b.Navigation("TimeSlot");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.HasOne("DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_User_Role")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DAL.Entities.Blog", b =>
                {
                    b.Navigation("DepartmentBlogs");
                });

            modelBuilder.Entity("DAL.Entities.BlogCategory", b =>
                {
                    b.Navigation("Blogs");
                });

            modelBuilder.Entity("DAL.Entities.Department", b =>
                {
                    b.Navigation("DepartmentBlogs");

                    b.Navigation("Lectures");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("DAL.Entities.Lecturer", b =>
                {
                    b.Navigation("LecturerRatings");

                    b.Navigation("LectureSemesterRegisters");

                    b.Navigation("SubjectRegisters");

                    b.Navigation("TeachableSubjects");

                    b.Navigation("TimeSlotRegisters");
                });

            modelBuilder.Entity("DAL.Entities.LecturerType", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("DAL.Entities.MasterPlan", b =>
                {
                    b.Navigation("SemesterPlans");
                });

            modelBuilder.Entity("DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DAL.Entities.Semester", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("LectureSemesterRegisters");

                    b.Navigation("MasterPlans");

                    b.Navigation("SemesterPlans");
                });

            modelBuilder.Entity("DAL.Entities.SemesterPlan", b =>
                {
                    b.Navigation("LecturerRatings");

                    b.Navigation("SubjectRegisters");

                    b.Navigation("TimeSlotRegisters");
                });

            modelBuilder.Entity("DAL.Entities.Subject", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("SubjectRegisters");

                    b.Navigation("TeachableSubjects");
                });

            modelBuilder.Entity("DAL.Entities.TimeSlot", b =>
                {
                    b.Navigation("TimeSlotRegisters");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}