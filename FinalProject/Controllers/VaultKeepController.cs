namespace FinalProject.Controllers;

[ApiController]
[Route("api/vaultkeeps")]
public class VaultKeepController : ControllerBase
{
    private readonly VaultKeepService _vkService;
    private readonly Auth0Provider _auth;
    private readonly VaultsService _vaultsService;


    public VaultKeepController(VaultKeepService vkService, Auth0Provider auth, VaultsService vaultsService)
    {
        _vkService = vkService;
        _auth = auth;
        _vaultsService = vaultsService;
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vkData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            // string userId = userInfo.Id;
            vkData.CreatorId = userInfo.Id;
            // Vault vault = _vaultsService.GetVaultById(vkData.VaultId, userId);
            VaultKeep newVaultKeep = _vkService.CreateVault(vkData);
            return Ok(newVaultKeep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

    [HttpGet("{vaultkeepId}")]

    public ActionResult<VaultKeep> GetVaultKeepById(int vaultkeepId)
    {
        try
        {
            VaultKeep vaultkeep = _vkService.GetVaultKeepById(vaultkeepId);
            return Ok(vaultkeep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpDelete("{vaultkeepId}")]
    [Authorize]

    public async Task<ActionResult<string>> DeleteVaultKeep(int vaultkeepId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            string userId = userInfo.Id;
            string message = _vkService.DeleteVaultKeep(vaultkeepId, userId);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



}
