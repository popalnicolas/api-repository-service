using POPAPP.DK.DATA.Models;

namespace POPAPP.DK.BUSINESS.Services.IServices;

public interface IAccountService
{
    Task<IEnumerable<Account>?> GetALlAccounts();
    Task<Account> Register(Account account);
    Task Delete(Account account);
    Task<Account> Update(Account account);
    Task<Account?> GetById(long id);
}