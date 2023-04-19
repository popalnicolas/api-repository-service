using Microsoft.AspNetCore.Mvc;
using POPAPP.DK.BUSINESS.Services.IServices;
using POPAPP.DK.DATA.Models;
using POPAPP.DK.DTO.Account;

namespace POPAPP.DK.API.Controllers;

[Route("api/[controller]/[action]")]
public class AuthenticationController: ControllerBase
{
    private readonly IAccountService _accountService;

    public AuthenticationController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpGet(Name = "Get All Users")]
    public async Task<ActionResult<IEnumerable<Account>>> GetAllUsers()
    {
        return Ok(await _accountService.GetALlAccounts());
    }
    
    [HttpPost(Name = "Register User")]
    public async Task<ActionResult> Register(AccountToRegisterDTO account)
    {
        await _accountService.Register(account);
        return Ok();
    }

    [HttpPut(Name = "Update User")]
    public async Task<ActionResult> Update(Account account)
    {
        await _accountService.Update(account);
        return Ok();
    }
    
    [HttpDelete(Name = "Delete User")]
    public async Task<ActionResult> Delete(Account account)
    {
        await _accountService.Delete(account);
        return Ok();
    }

    [HttpGet("{id}", Name = "Get User By Id")]
    public async Task<ActionResult<Account>> GetById(long id)
    {
        return Ok(await _accountService.GetById(id));
    }
}