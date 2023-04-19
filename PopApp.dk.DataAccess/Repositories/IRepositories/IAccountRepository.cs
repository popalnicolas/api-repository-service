using PopApp.dk.DataAccess.Models;

namespace PopApp.dk.DataAccess.Repositories.IRepositories;

public interface IAccountRepository: IGenericRepository<Account>
{
    Task<Account?> GetByUsernameAndPassword(string username, string password);
}