namespace FinalProject.Controllers;

[ApiController]
[Route("api/profiles")]
public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;
    private readonly Auth0Provider _auth;
    private readonly KeepsService _keepService;
    private readonly VaultsService _vaultService;
    public ProfileController(ProfileService profileService, Auth0Provider auth, KeepsService keepService, VaultsService vaultService)
    {
        _profileService = profileService;
        _auth = auth;
        _keepService = keepService;
        _vaultService = vaultService;
    }

    [HttpGet("{profileId}")]
    public ActionResult<profile> GetProfileById(string profileId)
    {
        try
        {
            profile pro = _profileService.GetProfileById(profileId);
            return Ok(pro);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/keeps")]


    public ActionResult<List<Keep>> GetUsersKeep(string profileId)
    {
        try
        {
            List<Keep> usersKeep = _keepService.GetUsersKeep(profileId);
            return Ok(usersKeep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetUsersVault(string profileId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            List<Vault> usersVault = _vaultService.GetUsersVault(profileId, userInfo?.Id);

            return Ok(usersVault);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
