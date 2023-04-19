using Microsoft.EntityFrameworkCore;
using PopApp.dk.DataAccess.Models;

namespace PopApp.dk.DataAccess.DataContext;

public class PopappDbContext: DbContext
{
    public PopappDbContext(DbContextOptions<PopappDbContext> options): base(options) { }
    public DbSet<Account> Accounts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account()
            {
                AccountId = 1,
                Username = "Nick",
                Password = "1234",
                Email = "nick@gmail.com"
            }
        );
    }
}