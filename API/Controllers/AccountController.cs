﻿using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class AccountController : BaseApiController
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<AppUser> userManager
                             , IMapper mapper
                             , ITokenService tokenService
        )
    {
        this._userManager = userManager;
        _mapper = mapper;
        _tokenService = tokenService;
    }


    ////////////////////////////////////////////////
    ////////////////////////////////////////////////
    // POST: api/Account/register
    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
    {
        if (await UserExists(registerDto.UserName)) return BadRequest("Nombre de usuario en uso.");

        var user = _mapper.Map<AppUser>(registerDto);

        user.UserName = registerDto.UserName.ToLower();

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        var userDto = new UserDto
        {
            UserName = user.UserName,
            KnownAs = user.KnownAs,
            Token = await _tokenService.CreateToken(user)
        };

        return Ok(userDto);
    }
    // ocupa AppUserStore->FindByNameAsync->GetUserWithMainFotoAsync de UserRepository

    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    // POST: api/Account/login
    [HttpPost("login")]
    public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        // .FindByNameAsync est[a en AppUserStore y usa GetUserWithMainFotoAsync de UserRepository

        if (user == null) return Unauthorized("Usuario invalido.");

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

        if (!result) return Unauthorized("Password invalido.");

        var userDto = new UserDto
        {
            UserName = user.UserName,
            KnownAs = user.KnownAs,
            PhotoUrl = user.Pictures.FirstOrDefault()?.Url, // manda null cuando no hay photo
            Token = await _tokenService.CreateToken(user)
        };

        return Ok(userDto);
    }

    ////////////////////////////////////////////////
    ///////////////////////////////////////////////////
    //
    private async Task<bool> UserExists(string username)
    {
        var userInDb = await _userManager.FindByEmailAsync(username.ToLower());

        return userInDb is not null;
    }
}
