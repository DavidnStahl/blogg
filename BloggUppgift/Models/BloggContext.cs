using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BloggUppgift.Models
{
    public partial class BloggContext : DbContext
    {
        public BloggContext()
        {
        }

        public BloggContext(DbContextOptions<BloggContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BloggCategories> BloggCategories { get; set; }
        public virtual DbSet<BloggInfo> BloggInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost; Database=Blogg ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BloggCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BloggInfo>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BloggInput)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Heading)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.BloggInfo)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BloggInfo_BloggCategories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
