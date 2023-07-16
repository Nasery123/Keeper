namespace FinalProject.Controllers;

[ApiController]
[Route("api/vaultkeeps")]
public class VaultKeepController : ControllerBase
{
    private readonly VaultKeepService _vkService;
    private readonly Auth0Provider _auth;


    public VaultKeepController(VaultKeepService vkService, Auth0Provider auth)
    {
        _vkService = vkService;
        _auth = auth;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vkData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            vkData.creatorId = userInfo.Id;
            VaultKeep newVaultKeep = _vkService.CreateVault(vkData);
            return Ok(newVaultKeep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }



}
