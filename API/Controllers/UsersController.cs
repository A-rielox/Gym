using API.DTOs;
using API.Extensions;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

//[Authorize]
public class UsersController : BaseApiController
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UsersController( IUserRepository userRepository
                           , IMapper mapper 
                          )
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }



    //////////////////////////////////////////
    /////////////////////////////////////////////
    [HttpGet]
    //[Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
    {
        var users = await _userRepository.GetUsersAsync();
        var members = _mapper.Map<IEnumerable<MemberDto>>(users);

        return Ok(members);
    }

    
    //////////////////////////////////////////
    /////////////////////////////////////////////
    //[Authorize(Roles = "Member")]
    [HttpGet("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser(string username)
    {
        var user = await _userRepository.GetUserByUserNameAsync(username); // trae todas las fotos

        // si no hay con este nombre tengo null
        if (user is null) return Ok("Este usuario no existe.");

        var member = _mapper.Map<MemberDto>(user);

        return Ok(member);
    }


    //////////////////////////////////////////////
    /////////////////////////////////////////////////
    // PUT api/Users
    [HttpPut]
    public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
    {// estoy cambiando en knownAs
        var userId = User.GetUserId();

        var user = await _userRepository.GetUserByIdAsync(userId);
        
        if (user == null) return NotFound();

        // lo q esta em memberUpdateDto lo mete a user
        //                |---------->
        _mapper.Map(memberUpdateDto, user);

        // aùn y si no hay cambios me sobreescribe todo
        if (await _userRepository.UpdateUserAsync(user)) return NoContent();

        return BadRequest("Error al actualizar el usuario.");
    }    
}
