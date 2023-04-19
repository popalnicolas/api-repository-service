using Microsoft.AspNetCore.Mvc;
using PopApp.dk.Business.Services.IServices;
using PopApp.dk.DataAccess.Models;
using PopApp.dk.DataTransferObject.Account;

namespace PopApp.dk.Api.Controllers;

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