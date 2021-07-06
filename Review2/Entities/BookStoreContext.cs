using Microsoft.EntityFrameworkCore;

namespace Review2.Entities
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options) { }
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<ClientEntity> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookEntity>().HasMany(b => b.Authors);
            modelBuilder.Entity<AuthorEntity>().HasMany(a => a.Books);
            modelBuilder.Entity<ClientEntity>().HasMany(c => c.Books);

            modelBuilder.Entity<ClientEntity>().HasData(new ClientEntity
            {
                Name = "Client1",
                ClientId = 1
            });
            modelBuilder.Entity<BookEntity>().HasData(new BookEntity
            {
                BookId = 1,
                Name = "Book1",
                ClientId = 1
            });
            modelBuilder.Entity<AuthorEntity>().HasData(new AuthorEntity
            {
                AuthorId = 1,
                Name = "Author1",
            });
        }
    }
}