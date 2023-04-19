using POPAPP.DK.DATA.Models;
using POPAPP.DK.DTO.Account;

namespace POPAPP.DK.BUSINESS.Services.IServices;

public interface IAccountService
{
    Task<IEnumerable<AccountDTO>?> GetALlAccounts();
    Task<AccountToLoginDTO> Register(Account account);
    Task Delete(Account account);
    Task<Account> Update(Account account);
    Task<Account?> GetById(long id);
}