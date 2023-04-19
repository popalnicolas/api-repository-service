using Microsoft.EntityFrameworkCore;
using PopApp.dk.DataAccess.DataContext;
using PopApp.dk.DataAccess.Models;
using PopApp.dk.DataAccess.Repositories.IRepositories;

namespace PopApp.dk.DataAccess.Repositories;

public class AccountRepository : GenericRepository<Account>, IAccountRepository
{
    private readonly PopappDbContext _popappDbContext;

    public AccountRepository(PopappDbContext context) : base(context)
    {
        this._popappDbContext = context;
    }
    
    public async Task<Account?> GetByUsernameAndPassword(string username, string password)
    {
        return await _popappDbContext.Accounts.FirstOrDefaultAsync(acc => acc.Username == username && acc.Password == password);
    }
}