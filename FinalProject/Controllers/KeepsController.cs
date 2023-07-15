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
            var keep = _keepsService.CreateKeep(keepData);
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

    public ActionResult<Keep> GetKeepById(int keepId)
    {
        try
        {
            Keep keep = _keepsService.GetKeepById(keepId);
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
            updateData.Id = keepId;
            Keep keep = _keepsService.UpdateKeep(updateData);
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
            string message = _keepsService.RemoveKeep(keepId);
            return Ok(message);
        }

        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}
