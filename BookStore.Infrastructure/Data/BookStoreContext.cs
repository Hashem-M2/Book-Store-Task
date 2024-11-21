using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Data;

public partial class BookStoreContext : DbContext
{
    public BookStoreContext()
    {
    }

    public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP-PC; Initial Catalog=BookStore;Integrated Security=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Authors__70DAFC141C851128");

            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Bio).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Books__3DE0C227B1D1E08C");

            entity.Property(e => e.BookId).HasColumnName("BookID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TypeBook)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_Authors");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
