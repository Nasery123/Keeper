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

    public async Task<ActionResult<Vault>> GetVaultById(int vaultId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Vault vault = _vaultsService.GetVaultById(vaultId, userInfo?.Id);
            return Ok(vault);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault updateData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            updateData.CreatorId = userInfo.Id;
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
    public async Task<ActionResult<string>> RemoveVault(int vaultId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            string message = _vaultsService.RemoveVault(vaultId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{vaultId}/keeps")]

    public async Task<ActionResult<List<KeepsInVault>>> GetKeepsByVaultId(int vaultId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<KeepsInVault> keeps = _vkService.GetKeepsByVaultId(vaultId, userInfo?.Id);
            return Ok(keeps);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

}
