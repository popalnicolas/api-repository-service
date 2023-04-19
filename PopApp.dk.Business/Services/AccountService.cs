using AutoMapper;
using PopApp.dk.Business.Services.IServices;
using PopApp.dk.DataAccess.Models;
using PopApp.dk.DataAccess.Repositories.IRepositories;
using PopApp.dk.DataTransferObject.Account;

namespace PopApp.dk.Business.Services;

public class AccountService: IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;
    
    public AccountService(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        this._mapper = mapper;
    }
    
    public async Task<IEnumerable<AccountDTO>?> GetALlAccounts()
    {
        return _mapper.Map<IEnumerable<AccountDTO>>(await _accountRepository.GetList());
    }
    
    public async Task<AccountToAddDTO> Register(AccountToRegisterDTO account)
    {
        var addedUser = await _accountRepository.Add(_mapper.Map<Account>(account));
        var userToReturn = _mapper.Map<AccountToAddDTO>(addedUser);
        
        return userToReturn;
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