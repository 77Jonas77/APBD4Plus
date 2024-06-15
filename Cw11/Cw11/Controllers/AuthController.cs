using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Cw11.Exceptions;
using Cw11.Helpers;
using Cw11.Models;
using Cw11.Models.DbModels;
using Cw11.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Cw11.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IAppUserService _appUserService;

    public AuthController(IConfiguration configuration, IAppUserService appUserService)
    {
        _configuration = configuration;
        _appUserService = appUserService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(RegisterUserRequest userRequest)
    {
        var hashedPasswordWithSalt = SecurityHelpers.GetHashedPasswordWithSalt(userRequest.password);
        try
        {
            await _appUserService.RegisterNewUserAsync(
                userRequest.username,
                hashedPasswordWithSalt.Item1,
                hashedPasswordWithSalt.Item2);
        }
        catch (BadRequestException)
        {
            return BadRequest("Invalid data provided ;(");
        }

        return Ok();
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(LoginUserRequest loginRequest)
    {
        try
        {
            var user = await _appUserService.GetUserByUsernameAsync(loginRequest.Login);
            if (!await _appUserService.IsUserLoginPasswordCompatible(user, loginRequest.Password))
            {
                return Unauthorized("Wrong password");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["JWT:RefIssuer"],
                audience: _configuration["JWT:RefAudience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            var jwtTokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refToken = new JwtSecurityToken(
                issuer: _configuration["JWT:RefIssuer"],
                audience: _configuration["JWT:RefAudience"],
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: creds);

            var refTokenString = new JwtSecurityTokenHandler().WriteToken(refToken);

            await _appUserService.AddNewRefreshToken(user, refTokenString);

            return Ok(new
            {
                accessToken = jwtTokenString,
                refreshToken = refTokenString
            });
        }
        catch (BadRequestException)
        {
            return NotFound("Invalid data to login!");
        }
    }

    [Authorize(AuthenticationSchemes = "IgnoreTokenExpirationScheme")]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken(RefreshTokenRequest requestToken)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            AppUser user;
            try
            {
                user = await _appUserService.GetUserByIdAsync(userId);
            }
            catch (UnauthorizedException)
            {
                return Unauthorized("Invalid data in Token (id?)");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(requestToken.RefreshToken, new TokenValidationParameters
            {
                ValidIssuer = _configuration["JWT:RefIssuer"],
                ValidAudience = _configuration["JWT:RefAudience"],
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!))
            }, out _);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                issuer: _configuration["JWT:RefIssuer"],
                audience: _configuration["JWT:RefAudience"],
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            var jwtTokenString = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            var refToken = new JwtSecurityToken(
                issuer: _configuration["JWT:RefIssuer"],
                audience: _configuration["JWT:RefAudience"],
                expires: DateTime.UtcNow.AddDays(5),
                signingCredentials: creds);

            var refTokenString = new JwtSecurityTokenHandler().WriteToken(refToken);

            await _appUserService.AddNewRefreshToken(user, refTokenString);

            return Ok(new
            {
                accessToken = jwtTokenString,
                refreshToken = refTokenString
            });
        }
        catch (UnauthorizedException)
        {
            return StatusCode(401);
        }
    }

    [Authorize]
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _appUserService.GetUsers();
        return Ok(users);
    }
}
