namespace FinalProject.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly Auth0Provider _auth0Provider;
    private readonly VaultsService _vaultService;

    public AccountController(AccountService accountService, Auth0Provider auth0Provider, VaultsService vaultService = null)
    {
        _accountService = accountService;
        _auth0Provider = auth0Provider;
        _vaultService = vaultService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Account>> Get()
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            return Ok(_accountService.GetOrCreateProfile(userInfo));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpGet("vaults")]
    [Authorize]
    public async Task<ActionResult<Vault>> GetMyVault()
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            List<Vault> myVault = _vaultService.GetMyVault(userInfo.Id);
            return Ok(myVault);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut]
    [Authorize]
    public async Task<ActionResult<Account>> EditAccount([FromBody] Account editData)
    {
        try
        {
            Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
            editData.Id = userInfo.Id;
            Account acc = _accountService.Edit(editData, userInfo.Email);
            return Ok(acc);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



}
