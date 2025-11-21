using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Example01.Data;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Schoolwork> Schoolworks { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentCourse> StudentCourses { get; set; }

    public virtual DbSet<StudentGroup> StudentGroups { get; set; }

    public virtual DbSet<StudentSolution> StudentSolutions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=password;Database=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("course_pkey");
        });

        modelBuilder.Entity<Schoolwork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("schoolwork_pkey");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_pkey");

            entity.Property(e => e.GroupId).HasDefaultValueSql("nextval('student_group_id_seq1'::regclass)");
            entity.Property(e => e.Jmbag).IsFixedLength();

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_group");
        });

        modelBuilder.Entity<StudentCourse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_course_pkey");

            entity.Property(e => e.CourseId).ValueGeneratedOnAdd();
            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Course).WithMany(p => p.StudentCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_course_course_id_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentCourses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_course_student_id_fkey");
        });

        modelBuilder.Entity<StudentGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_group_pkey");
        });

        modelBuilder.Entity<StudentSolution>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("student_solution_pkey");

            entity.Property(e => e.SchoolworkId).ValueGeneratedOnAdd();
            entity.Property(e => e.StudentId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Schoolwork).WithMany(p => p.StudentSolutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_solution_schoolwork_id_fkey");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentSolutions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("student_solution_student_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
