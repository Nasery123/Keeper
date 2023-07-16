namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ProfileService _profileService;
    private readonly Auth0Provider _auth;
    public ProfileController(ProfileService profileService, Auth0Provider auth)
    {
        _profileService = profileService;
        _auth = auth;
    }

    [HttpGet("{profileId}")]
    public ActionResult<profile> GetProfileById(string profileId)
    {
        try
        {
            profile pro = _profileService.GetProfileById(profileId);
            return pro;
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
