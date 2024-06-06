using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using VoloLearn.Models.Service;
using VoloLearn.Options;
using VoloLearn.Services.Interfaces;

namespace VoloLearn.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly JWTOptions _jwtoption;
    private readonly IUserService _userService;

    public UserController(IUserService userService, JWTOptions jwtoption)
    {
        _userService = userService;
        _jwtoption = jwtoption;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserModel model)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var result = await _userService.CreateNewUserAsync(model);
        return Ok(result);
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        await _userService.LoginAsync(model);
        var acsestoken = CreateAccessToken(_jwtoption, model.Email, TimeSpan.FromSeconds(_jwtoption.ExpirationSeconds));

        return Ok(acsestoken);
    }


    private static string CreateAccessToken(
        JWTOptions jwtOptions,
        string username,
        TimeSpan expiration)
    {
        var keyBytes = Encoding.UTF8.GetBytes(jwtOptions.SigningKey);
        var symmetricKey = new SymmetricSecurityKey(keyBytes);

        var signingCredentials = new SigningCredentials(
            symmetricKey,
            // 👇 one of the most popular. 
            SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new("sub", username),
            new("name", username),
            new("aud", jwtOptions.Audience)
        };

        var token = new JwtSecurityToken(
            jwtOptions.Issuer,
            jwtOptions.Audience,
            claims,
            expires: DateTime.Now.Add(expiration),
            signingCredentials: signingCredentials);

        var rawToken = new JwtSecurityTokenHandler().WriteToken(token);
        return rawToken;
    }
}