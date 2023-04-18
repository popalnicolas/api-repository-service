using POPAPP.DK.BUSINESS.Services.IServices;
using POPAPP.DK.DATA.Models;
using POPAPP.DK.DATA.Repositories.IRepositories;

namespace POPAPP.DK.BUSINESS.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;
    
    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }
    
    public async Task<IEnumerable<Account>?> GetALlAccounts()
    {
        return await _accountRepository.GetList();
    }
    
    public async Task<Account> Register(Account account)
    {
        return await _accountRepository.Add(account);
    }
    
    public async Task Delete(Account account)
    {
        await _accountRepository.Delete(account);
    }
    
    public async Task<Account> Update(Account account)
    {
        return await _accountRepository.Update(account);
    }
    
    public async Task<Account?> GetById(long id)
    {
        return await _accountRepository.Get(f => f.AccountId == id);
    }
}