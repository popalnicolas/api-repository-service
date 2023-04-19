using PopApp.dk.DataAccess.Models;
using PopApp.dk.DataTransferObject.Account;

namespace PopApp.dk.Business.Services.IServices;

public interface IAccountService
{
    Task<IEnumerable<AccountDTO>?> GetALlAccounts();
    Task<AccountToAddDTO> Register(AccountToRegisterDTO account);
    Task Delete(Account account);
    Task<Account> Update(Account account);
    Task<Account?> GetById(long id);
}