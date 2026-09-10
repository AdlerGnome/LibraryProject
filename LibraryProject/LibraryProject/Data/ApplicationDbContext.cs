using LibraryProject.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<BorrowedBook> BorrowedBook { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AId);

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { PId = 1, Name = "Black Library" },
                new Publisher { PId = 2, Name = "Geoffrey Bles" },
                new Publisher { PId = 3, Name = "George Allen & Unwin" },
                new Publisher { PId = 4, Name = "Hodder & Stoughton Ltd" }
                );

            modelBuilder.Entity<Author>().HasData(
                new Author { AId = 1, FirstName = "C.S.", LastName = "Lewis", Birthyear = 1898, Deathyear = 1963 },
                new Author { AId = 2, FirstName = "J.R.R.", LastName = "Tolkien", Birthyear = 1892, Deathyear = 1973 },
                new Author { AId = 3, FirstName = "Guy", LastName = "Haley", Birthyear = 1973 },
                new Author { AId = 4, FirstName = "John", LastName = "French", Birthyear = 1989 },
                new Author { AId = 5, FirstName = "Robert", LastName = "Rath", Birthyear = 1990 },
                new Author { AId = 6, FirstName = "Dan", LastName = "Abnett", Birthyear = 1965 },
                new Author { AId = 7, FirstName = "Frank", LastName = "Herbert", Birthyear = 1920, Deathyear = 1986 },
                new Author { AId = 8, FirstName = "Justin D.", LastName = "Hill", Birthyear = 1971 }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { BId = 1, AId = 1, Title = "The Lion, the Witch and the Wardrobe", PublishYear = 1950, PId = 2, Pagecount = 208, Stock = 2, Edition = 1,Description="" },
                new Book { BId = 2, AId = 2, Title = "The Hobbit", PublishYear = 1937, PId = 3, Pagecount = 300, Edition = 1, Stock = 2, Description = "" },
                new Book { BId = 3, AId = 3, Title = "Dark Imperium", PublishYear = 2021, PId = 1, Pagecount = 432, Edition = 2, Stock = 1, Description = "" },
                new Book { BId = 4, AId = 3, Title = "Dark Imperium: Plague War", PublishYear = 2022, PId = 1, Pagecount = 401, Edition = 2, Stock = 1, Description = "" },
                new Book { BId = 5, AId = 3, Title = "Dark Imperium: Godblight", PublishYear = 2022, PId = 1, Pagecount = 431, Edition = 2, Stock = 1, Description = "" },
                new Book { BId = 6, AId = 7, Title = "Dune", PublishYear = 2015, PId = 4, Pagecount = 577, Edition = 4, Stock = 1, Description = "" },
                new Book { BId = 7, AId = 7, Title = "Dune Messiah", PublishYear = 2017, PId = 4, Pagecount = 293, Edition = 4, Stock = 2, Description = "" },
                new Book { BId = 8, AId = 7, Title = "Children of Dune", PublishYear = 2021, PId = 4, Pagecount = 423, Edition = 4, Stock = 2, Description = "" },
                new Book { BId = 9, AId = 7, Title = "God Emperor of Dune", PublishYear = 2020, PId = 4, Pagecount = 420, Edition = 3, Stock = 2, Description = "" },
                new Book { BId = 10, AId = 5, Title = "The Fall of Cadia", PublishYear = 2023, PId = 1, Pagecount = 656, Edition = 1, Stock = 1, Description = "" },
                new Book { BId = 11, AId = 5, Title = "Assassinorum: Kingmaker", PublishYear = 2022, PId = 1, Pagecount = 464, Edition = 1, Stock = 1, Description = "" },
                new Book { BId = 12, AId = 4, Title = "Cypher: Lord of the Fallen", PublishYear = 2024, PId = 1, Pagecount = 192, Edition = 1, Stock = 1, Description = "" },
                new Book { BId = 13, AId = 4, Title = "Ahriman: The Omnibus", PublishYear = 2024, PId = 1, Pagecount = 880, Edition = 2, Stock = 1, Description = "" },
                new Book { BId = 14, AId = 6, Title = "The Founding", PublishYear = 2022, PId = 1, Pagecount = 880, Edition = 2, Stock = 2, Description = "" },
                new Book { BId = 15, AId = 8, Title = "Minka Lesk: The Last Whiteshield", PublishYear = 2023, PId = 1, Pagecount = 1079, Edition = 1, Stock = 1, Description = "" },
                new Book { BId = 16, AId = 2, Title = "The Fellowship of the Ring", PublishYear = 1937, PId = 3, Pagecount = 423, Edition = 1, Stock = 3, Description = "" },
                new Book { BId = 17, AId = 2, Title = "The Two Towers", PublishYear = 1937, PId = 3, Pagecount = 352, Edition = 1, Stock = 3, Description = "" },
                new Book { BId = 18, AId = 2, Title = "The Return of the King", PublishYear = 1937, PId = 3, Pagecount = 416, Edition = 1, Stock = 3, Description = "" }
                );

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GId = 1, Name = "Fantasy" },
                new Genre { GId = 2, Name = "Science Fiction" },
                new Genre { GId = 3, Name = "Horror" },
                new Genre { GId = 4, Name = "Romance" },
                new Genre { GId = 5, Name = "Thriller" }
                );
        }
    }
}
