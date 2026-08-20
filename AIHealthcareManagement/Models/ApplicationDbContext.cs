using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AIHealthcareManagement.Models;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<AisymptomAssessment> AisymptomAssessments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AuditLog> AuditLogs { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Prescription> Prescriptions { get; set; }

    public virtual DbSet<Reminder> Reminders { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=AIHealthcareManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Administ__719FE488885FE7A6");

            entity.HasIndex(e => e.UserId, "UQ__Administ__1788CC4DF67C584A").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(150);

            entity.HasOne(d => d.User).WithOne(p => p.Administrator)
                .HasForeignKey<Administrator>(d => d.UserId)
                .HasConstraintName("FK_Admins_Users");
        });

        modelBuilder.Entity<AisymptomAssessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__AISympto__3D2BF81E90FAC870");

            entity.ToTable("AISymptomAssessments");

            entity.HasIndex(e => e.PatientId, "IX_AIAssessments_Patient");

            entity.Property(e => e.AiresultSummary).HasColumnName("AIResultSummary");
            entity.Property(e => e.ConfidenceScore).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ModelVersion).HasMaxLength(50);
            entity.Property(e => e.UrgencyLevel).HasMaxLength(30);

            entity.HasOne(d => d.Patient).WithMany(p => p.AisymptomAssessments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AIAssessments_Patients");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC24F7B427B");

            entity.HasIndex(e => new { e.DoctorId, e.AppointmentDate }, "IX_Appointments_DoctorDate");

            entity.HasIndex(e => new { e.PatientId, e.AppointmentDate }, "IX_Appointments_PatientDate");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.ReasonForVisit).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appointments_Patients");
        });

        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__AuditLog__5E548648307D77DD");

            entity.Property(e => e.Action).HasMaxLength(200);
            entity.Property(e => e.EntityName).HasMaxLength(100);
            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.User).WithMany(p => p.AuditLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_AuditLogs_Users");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBF9F65D398");

            entity.HasIndex(e => e.Specialization, "IX_Doctors_Specialization");

            entity.HasIndex(e => e.UserId, "UQ__Doctors__1788CC4D91355053").IsUnique();

            entity.Property(e => e.ConsultationFee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.LicenseNumber).HasMaxLength(100);
            entity.Property(e => e.Qualification).HasMaxLength(200);
            entity.Property(e => e.Specialization).HasMaxLength(150);

            entity.HasOne(d => d.User).WithOne(p => p.Doctor)
                .HasForeignKey<Doctor>(d => d.UserId)
                .HasConstraintName("FK_Doctors_Users");
        });

        modelBuilder.Entity<DoctorAvailability>(entity =>
        {
            entity.HasKey(e => e.AvailabilityId).HasName("PK__DoctorAv__DA3979B1A6B18BC9");

            entity.ToTable("DoctorAvailability");

            entity.Property(e => e.IsAvailable).HasDefaultValue(true);

            entity.HasOne(d => d.Doctor).WithMany(p => p.DoctorAvailabilities)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK_Availability_Doctors");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId).HasName("PK__MedicalR__FBDF78E977DAF76F");

            entity.HasIndex(e => e.PatientId, "IX_MedicalRecords_Patient");

            entity.Property(e => e.RecordDate).HasDefaultValueSql("(sysutcdatetime())");

            entity.HasOne(d => d.Appointment).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.AppointmentId)
                .HasConstraintName("FK_Records_Appointments");

            entity.HasOne(d => d.Doctor).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_Doctors");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Records_Patients");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E129FCBD6F8");

            entity.Property(e => e.Channel)
                .HasMaxLength(20)
                .HasDefaultValue("InApp");
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifications_Users");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC3662A0D372D");

            entity.HasIndex(e => e.UserId, "UQ__Patients__1788CC4D3D5FAB3C").IsUnique();

            entity.Property(e => e.Address).HasMaxLength(300);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.EmergencyContactName).HasMaxLength(150);
            entity.Property(e => e.EmergencyContactPhone).HasMaxLength(20);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Gender).HasMaxLength(20);

            entity.HasOne(d => d.User).WithOne(p => p.Patient)
                .HasForeignKey<Patient>(d => d.UserId)
                .HasConstraintName("FK_Patients_Users");
        });

        modelBuilder.Entity<Prescription>(entity =>
        {
            entity.HasKey(e => e.PrescriptionId).HasName("PK__Prescrip__40130832D1E52DD4");

            entity.Property(e => e.Dosage).HasMaxLength(100);
            entity.Property(e => e.Frequency).HasMaxLength(100);
            entity.Property(e => e.Instructions).HasMaxLength(500);
            entity.Property(e => e.MedicineName).HasMaxLength(200);

            entity.HasOne(d => d.Record).WithMany(p => p.Prescriptions)
                .HasForeignKey(d => d.RecordId)
                .HasConstraintName("FK_Prescriptions_Records");
        });

        modelBuilder.Entity<Reminder>(entity =>
        {
            entity.HasKey(e => e.ReminderId).HasName("PK__Reminder__01A83087710DEEA2");

            entity.HasIndex(e => e.ReminderDateTime, "IX_Reminders_DateTime");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.ReminderType).HasMaxLength(30);

            entity.HasOne(d => d.Patient).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reminders_Patients");

            entity.HasOne(d => d.RelatedAppointment).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.RelatedAppointmentId)
                .HasConstraintName("FK_Reminders_Appointments");

            entity.HasOne(d => d.RelatedPrescription).WithMany(p => p.Reminders)
                .HasForeignKey(d => d.RelatedPrescriptionId)
                .HasConstraintName("FK_Reminders_Prescriptions");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AC4B7B064");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B616066F6DCAF").IsUnique();

            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C7380DABC");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4B0564D92").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F6C33F05").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.PasswordHash).HasMaxLength(500);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.SecurityStamp).HasMaxLength(500);
            entity.Property(e => e.Username).HasMaxLength(100);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
