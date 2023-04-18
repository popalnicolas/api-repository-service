using POPAPP.DK.DATA.Models;

namespace POPAPP.DK.DATA.Repositories.IRepositories;

public interface IAccountRepository: IGenericRepository<Account>
{
    Task<Account?> GetByUsernameAndPassword(string username, string password);
}