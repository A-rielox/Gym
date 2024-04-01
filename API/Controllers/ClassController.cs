using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
public class ClassController : BaseApiController
{
    private readonly IClassRepository _classRepository;

    public ClassController(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }




    //////////////////////////////////////////
    /////////////////////////////////////////////
    /// GET: api/class
    [HttpGet]
    public async Task<ActionResult> GetUserClases()
    {
        var userId = User.GetUserId();

        if(userId == 0) return NotFound();

        var userClases = await _classRepository.UserClases(userId);

        //if(userClases.Count() == 0) return NoContent();// manda []

        return Ok(userClases);
    }


}
