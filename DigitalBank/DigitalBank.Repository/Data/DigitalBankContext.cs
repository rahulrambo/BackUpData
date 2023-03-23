using System;
using System.Collections.Generic;
using DigitalBank.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DigitalBank.Repository.Data
{
    public partial class DigitalBankContext : DbContext
    {
        public DigitalBankContext()
        {
        }

        public DigitalBankContext(DbContextOptions<DigitalBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Bank> Banks { get; set; } = null!;
        public virtual DbSet<BankBranch> BankBranches { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Transaction> Transactions { get; set; } = null!;

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{            
//            optionsBuilder.UseLazyLoadingProxies();
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Digitalbank;Trusted_Connection=True; MultipleActiveResultSets=true");
//            }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Balance).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_BankId");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BranchId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_BranchId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_CustomerId");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("Bank");

                entity.HasIndex(e => e.Code, "UQ_Bank_Code")
                    .IsUnique();

                entity.Property(e => e.Code)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BankBranch>(entity =>
            {
                entity.ToTable("BankBranch");

                entity.HasIndex(e => e.Code, "UQ_BankBranch_Code")
                    .IsUnique();

                entity.Property(e => e.Address1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.BankBranches)
                    .HasForeignKey(d => d.BankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BankBranch_BankId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address1)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.District)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionTime).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Transactions_AccountId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
