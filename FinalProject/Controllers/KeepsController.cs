namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth;

    public KeepsController(KeepsService keepsService, Auth0Provider auth)
    {
        _keepsService = keepsService;
        _auth = auth;
    }




    [HttpPost]
    [Authorize]

    public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            keepData.CreatorId = userInfo.Id;
            Keep keep = _keepsService.CreateKeep(keepData);
            keep.Creator = userInfo;
            return Ok(keep);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }



    [HttpGet]
    public ActionResult<List<Keep>> GetAllKeep()
    {
        try
        {
            List<Keep> keep = _keepsService.GetAllKeep();
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{keepId}")]

    public async Task<ActionResult<Keep>> GetKeepById(int keepId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            Keep keep = _keepsService.GetKeepById(keepId, userInfo?.Id);
            return Ok(keep);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPut("{keepId}")]
    [Authorize]

    public async Task<ActionResult<Keep>> UpdateKeep(int keepId, [FromBody] Keep updateData)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            // updateData.Id = keepId;
            Keep keep = _keepsService.UpdateKeep(keepId, updateData, userInfo.Id);
            return Ok(keep);



        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{keepId}")]
    [Authorize]

    public async Task<ActionResult<string>> DeleteKeep(int keepId)
    {
        try
        {
            Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
            string message = _keepsService.RemoveKeep(keepId, userInfo.Id);
            return Ok(message);
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }

}
