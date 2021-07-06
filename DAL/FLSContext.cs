using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

#nullable disable

namespace DAL
{
    public partial class FLSContext : DbContext
    {
        public FLSContext()
        {
        }

        public FLSContext(DbContextOptions<FLSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentBlog> DepartmentBlogs { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }
        public virtual DbSet<LectureSemesterRegister> LectureSemesterRegisters { get; set; }
        public virtual DbSet<LecturerRating> LecturerRatings { get; set; }
        public virtual DbSet<LecturerType> LecturerTypes { get; set; }
        public virtual DbSet<MasterPlan> MasterPlans { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterPlan> SemesterPlans { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectRegister> SubjectRegisters { get; set; }
        public virtual DbSet<TeachableSubject> TeachableSubjects { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<TimeSlotRegister> TimeSlotRegisters { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["FLS_DB"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiledDate).HasColumnType("datetime");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.BlogCategory)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.BlogCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_BlogCategory");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("BlogCategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Semester");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Subject1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Department_User");
            });

            modelBuilder.Entity<DepartmentBlog>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.BlogId });

                entity.ToTable("DepartmentBlog");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.DepartmentBlogs)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentBlog_Blog");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.DepartmentBlogs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartmentBlog_Department");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.Property(e => e.LecturerCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_Department");

                entity.HasOne(d => d.LecturerTypeNavigation)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.LecturerTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_LecturerType");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_User");
            });

            modelBuilder.Entity<LectureSemesterRegister>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SemesterId });

                entity.ToTable("LectureSemesterRegister");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.LectureSemesterRegisters)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LectureSemesterRegister_Lecture");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.LectureSemesterRegisters)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LectureSemesterRegister_Semester");
            });

            modelBuilder.Entity<LecturerRating>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SemesterPlanId });

                entity.ToTable("LecturerRating");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.LecturerRatings)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerRating_Lecture");

                entity.HasOne(d => d.SemesterPlan)
                    .WithMany(p => p.LecturerRatings)
                    .HasForeignKey(d => d.SemesterPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerRating_SemesterPlan");
            });

            modelBuilder.Entity<LecturerType>(entity =>
            {
                entity.ToTable("LecturerType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MasterPlan>(entity =>
            {
                entity.ToTable("MasterPlan");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.MasterPlans)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MasterPlan_Semester");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<SemesterPlan>(entity =>
            {
                entity.ToTable("SemesterPlan");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MasterPlan)
                    .WithMany(p => p.SemesterPlans)
                    .HasForeignKey(d => d.MasterPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterPlan_MasterPlan");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterPlans)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterPlan_Semester");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PreviousCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectCode)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Department");
            });

            modelBuilder.Entity<SubjectRegister>(entity =>
            {
                entity.ToTable("SubjectRegister");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.SubjectRegisters)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectRegister_Lecture");

                entity.HasOne(d => d.SemesterPlan)
                    .WithMany(p => p.SubjectRegisters)
                    .HasForeignKey(d => d.SemesterPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectRegister_SemesterPlan");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectRegisters)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectRegister_Subject1");
            });

            modelBuilder.Entity<TeachableSubject>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SubjectId })
                    .HasName("PK_PreferSubject");

                entity.ToTable("TeachableSubject");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.TeachableSubjects)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreferSubject_Lecture");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeachableSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeachableSubject_Subject");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.EndTime).HasColumnType("time(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("time(0)");
            });

            modelBuilder.Entity<TimeSlotRegister>(entity =>
            {
                entity.ToTable("TimeSlotRegister");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.TimeSlotRegisters)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSlotRegister_Lecture");

                entity.HasOne(d => d.SemesterPlan)
                    .WithMany(p => p.TimeSlotRegisters)
                    .HasForeignKey(d => d.SemesterPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSlotRegister_SemesterPlan");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.TimeSlotRegisters)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSlotRegister_TimeSlot");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_User_1");

                entity.ToTable("User");

                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Birthdate).HasColumnType("date");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}