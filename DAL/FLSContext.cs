using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<ConstraintType> ConstraintTypes { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<LectureSemesterRegister> LectureSemesterRegisters { get; set; }
        public virtual DbSet<LecturerPlanConstraint> LecturerPlanConstraints { get; set; }
        public virtual DbSet<LecturerRating> LecturerRatings { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<PreferSubject> PreferSubjects { get; set; }
        public virtual DbSet<PreferTimeSlot> PreferTimeSlots { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestType> RequestTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<SemesterPlan> SemesterPlans { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<TeachingLevel> TeachingLevels { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
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

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.BlogCategoryId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

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

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blog_Department");
            });

            modelBuilder.Entity<BlogCategory>(entity =>
            {
                entity.ToTable("BlogCategory");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LecturerId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Picture).IsRequired();

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Certificate_Lecture");
            });

            modelBuilder.Entity<ConstraintType>(entity =>
            {
                entity.ToTable("ConstraintType");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_Semester");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Lecture>(entity =>
            {
                entity.ToTable("Lecture");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_Department");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Lectures)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Lecture_User");
            });

            modelBuilder.Entity<LectureSemesterRegister>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SemesterId });

                entity.ToTable("LectureSemesterRegister");

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

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

            modelBuilder.Entity<LecturerPlanConstraint>(entity =>
            {
                entity.HasKey(e => new { e.SemesterPlanId, e.LecturerId });

                entity.ToTable("LecturerPlanConstraint");

                entity.Property(e => e.SemesterPlanId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ConstraintTypeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.TimeSlotId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.ConstraintType)
                    .WithMany(p => p.LecturerPlanConstraints)
                    .HasForeignKey(d => d.ConstraintTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LecturerPlanConstraint_ConstraintType");

                entity.HasOne(d => d.SubjectCodeNavigation)
                    .WithMany(p => p.LecturerPlanConstraints)
                    .HasForeignKey(d => d.SubjectCode)
                    .HasConstraintName("FK_LecturerPlanConstraint_Subject");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.LecturerPlanConstraints)
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK_LecturerPlanConstraint_TimeSlot");
            });

            modelBuilder.Entity<LecturerRating>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SemesterPlanId });

                entity.ToTable("LecturerRating");

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SemesterPlanId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

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

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Level)
                    .HasPrincipalKey<TeachingLevel>(p => p.LevelId)
                    .HasForeignKey<Level>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Level_TeachingLevel");
            });

            modelBuilder.Entity<PreferSubject>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SubjectCode });

                entity.ToTable("PreferSubject");

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.PreferSubjects)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreferSubject_Lecture");

                entity.HasOne(d => d.SubjectCodeNavigation)
                    .WithMany(p => p.PreferSubjects)
                    .HasForeignKey(d => d.SubjectCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreferSubject_Subject");
            });

            modelBuilder.Entity<PreferTimeSlot>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.TimeSlotId });

                entity.ToTable("PreferTimeSlot");

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.TimeSlotId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.PreferTimeSlots)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreferTimeSlot_Lecture");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.PreferTimeSlots)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PreferTimeSlot_TimeSlot");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.CreateAt).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.RequestTypeId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.RequestTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_RequestType");

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Request_User");
            });

            modelBuilder.Entity<RequestType>(entity =>
            {
                entity.ToTable("RequestType");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.UsernameNavigation)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.Username)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_User");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => new { e.LecturerId, e.SessionId });

                entity.ToTable("Schedule");

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.SessionId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Lecture");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Schedule_Session");
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<SemesterPlan>(entity =>
            {
                entity.ToTable("SemesterPlan");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SemesterId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.SemesterPlans)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SemesterPlan_Semester");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("Session");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.TimeSlotId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_Course");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.TimeSlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Session_TimeSlot");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectCode);

                entity.ToTable("Subject");

                entity.Property(e => e.SubjectCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PreviousCode)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Department");
            });

            modelBuilder.Entity<TeachingLevel>(entity =>
            {
                entity.HasKey(e => new { e.LevelId, e.LecturerId });

                entity.ToTable("TeachingLevel");

                entity.HasIndex(e => e.LevelId, "IX_TeachingLevel")
                    .IsUnique();

                entity.Property(e => e.LevelId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LecturerId)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.TeachingLevels)
                    .HasForeignKey(d => d.LecturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeachingLevel_Lecture");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("TimeSlot");

                entity.Property(e => e.Id)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("time(0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("time(0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Username)
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
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
