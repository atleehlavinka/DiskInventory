using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DiskInventory.Models
{
    public partial class disk_inventoryahContext : DbContext
    {
        public disk_inventoryahContext()
        {
        }

        public disk_inventoryahContext(DbContextOptions<disk_inventoryahContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Disk> Disks { get; set; }
        public virtual DbSet<DiskBorrower> DiskBorrowers { get; set; }
        public virtual DbSet<DiskGenre> DiskGenres { get; set; }
        public virtual DbSet<DiskHasBorrower> DiskHasBorrowers { get; set; }
        public virtual DbSet<DiskStatus> DiskStatuses { get; set; }
        public virtual DbSet<DiskType> DiskTypes { get; set; }
        public virtual DbSet<ViewBorrowerNoLoan> ViewBorrowerNoLoans { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLDEV01;Database=disk_inventoryah;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Disk>(entity =>
            {
                entity.ToTable("disk");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.DiskArtist)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("disk_artist");

                entity.Property(e => e.DiskName)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("disk_name");

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("date")
                    .HasColumnName("release_date");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.HasOne(d => d.DiskType)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.DiskTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__disk_type___2D27B809");

                entity.HasOne(d => d.Genre)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.GenreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__genre_id__2E1BDC42");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Disks)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk__status_id__2C3393D0");
            });

            modelBuilder.Entity<DiskBorrower>(entity =>
            {
                entity.HasKey(e => e.BorrowerId)
                    .HasName("PK__disk_bor__FCA5926914D7B648");

                entity.ToTable("disk_borrower");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lname");

                entity.Property(e => e.PhoneNum)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone_num");
            });

            modelBuilder.Entity<DiskGenre>(entity =>
            {
                entity.HasKey(e => e.GenreId)
                    .HasName("PK__disk_gen__18428D4261385E7A");

                entity.ToTable("disk_genre");

                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<DiskHasBorrower>(entity =>
            {
                entity.ToTable("disk_has_borrower");

                entity.Property(e => e.DiskHasBorrowerId).HasColumnName("disk_has_borrower_id");

                entity.Property(e => e.BorrowedDate)
                    .HasColumnType("date")
                    .HasColumnName("borrowed_date");

                entity.Property(e => e.BorrowerId).HasColumnName("borrower_id");

                entity.Property(e => e.DiskId).HasColumnName("disk_id");

                entity.Property(e => e.ReturnedDate)
                    .HasColumnType("date")
                    .HasColumnName("returned_date");

                entity.HasOne(d => d.Borrower)
                    .WithMany(p => p.DiskHasBorrowers)
                    .HasForeignKey(d => d.BorrowerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___borro__30F848ED");

                entity.HasOne(d => d.Disk)
                    .WithMany(p => p.DiskHasBorrowers)
                    .HasForeignKey(d => d.DiskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__disk_has___disk___31EC6D26");
            });

            modelBuilder.Entity<DiskStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__disk_sta__3683B531305970CA");

                entity.ToTable("disk_status");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<DiskType>(entity =>
            {
                entity.ToTable("disk_type");

                entity.Property(e => e.DiskTypeId).HasColumnName("disk_type_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("description");
            });

            modelBuilder.Entity<ViewBorrowerNoLoan>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Borrower_No_Loans");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("First Name");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("Last Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
