using Microsoft.EntityFrameworkCore;
using POPAPP.DK.DATA.DataContext;
using POPAPP.DK.DATA.Models;
using POPAPP.DK.DATA.Repositories.IRepositories;

namespace POPAPP.DK.DATA.Repositories;

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