using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GroupAssignmentREAL.Models
{
    public partial class School_DBContext : DbContext
    {
        public virtual DbSet<AcademicHistory> AcademicHistory { get; set; }
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Enrolment> Enrolment { get; set; }
        public virtual DbSet<Students> Students { get; set; }

        public School_DBContext(DbContextOptions<School_DBContext> options) : base(options)
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicHistory>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("Academic_History");

                entity.Property(e => e.Sid)
                    .HasColumnName("SId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.Compulsory)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.PreRequisites)
                    .HasColumnName("Pre_requisites")
                    .HasMaxLength(50);

                entity.Property(e => e.Topic).HasMaxLength(30);
            });

            modelBuilder.Entity<Enrolment>(entity =>
            {
                entity.HasKey(e => e.EnrolId);

                entity.Property(e => e.CourseDescription)
                    .IsRequired()
                    .HasColumnName("Course Description")
                    .HasMaxLength(20);

                entity.Property(e => e.CourseId)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PreRequisite)
                    .IsRequired()
                    .HasColumnName("Pre-Requisite")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrolment)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CourseEnrol");
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.Property(e => e.Sid).HasColumnName("SId");

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Phone).HasMaxLength(30);
            });
        }
    }
}
