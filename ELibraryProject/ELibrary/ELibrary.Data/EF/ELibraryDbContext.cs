using System;
using ELibrary.Data.Configurations;
using ELibrary.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Data.EF
{
  public class ELibraryDbContext : IdentityDbContext<User>
  {
    public ELibraryDbContext(DbContextOptions<ELibraryDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new BookBorrowingRequestDetailsConfig());

      modelBuilder.ApplyConfiguration(new BookBorrowingRequestConfig());

      modelBuilder.ApplyConfiguration(new UserConfig());

      modelBuilder.ApplyConfiguration(new CategoryConfig());

      modelBuilder.ApplyConfiguration(new BookConfig());
    }
    public DbSet<BookBorrowingRequestDetails> BookBorrowingRequestDetails { get; set; }
    public DbSet<BookBorrowingRequest> BookBorrowingRequests { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Book> Books { get; set; }
  }
}