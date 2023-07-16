namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
    private readonly VaultsService _vaultsService;
    private readonly Auth0Provider _auth;
    private readonly VaultKeepService _vkService;

    public VaultsController(VaultsService vaultsService, Auth0Provider auth, VaultKeepService vkService)
    {
        _vaultsService = vaultsService;
        _auth = auth;
        _vkService = vkService;
    }

    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Vault>> CreatingVault([FromBody] Vault vaultData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            vaultData.CreatorId = userInfo.Id;
            Vault vault = _vaultsService.CreateVault(vaultData);
            return Ok(vault);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vaultId}")]

    public ActionResult<Vault> GetVaultById(int vaultId)
    {
        try
        {
            Vault vault = _vaultsService.GetVaultById(vaultId);
            return Ok(vault);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{vaultId}")]
    [Authorize]
    public ActionResult<Vault> UpdateVault(int vaultId, [FromBody] Vault updateData)
    {
        try
        {
            updateData.Id = vaultId;
            Vault vault = _vaultsService.UpdateVault(updateData);
            return Ok(vault);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{vaultId}")]
    [Authorize]
    public ActionResult<string> RemoveVault(int vaultId)
    {
        try
        {
            string message = _vaultsService.RemoveVault(vaultId);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    // [HttpGet("{vaultId}/keeps")]

    // public ActionResult<List<VaultKeep>> GetKeepsByVaultId(int vaultId)
    // {
    //     try
    //     {
    //         List<Keep> keeps = GetkeepsByVaultId(vaultId);
    //         return Ok(keeps);
    //     }
    //     catch (Exception e)
    //     {
    //         return BadRequest(e.Message);
    //     }

    // }

}
