using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Denver._Model.UserModel;
using Denver.Core.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Denver.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repo;

        public AuthController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserModel user)
        {
            user.Username = user.Username.ToLower();


            var UserRegist = new UserModel
            {
                Username = user.Username,
                Password = user.Password
            };

            var UserCreated = await _repo.Regist(UserRegist);

            return Ok("Woow... Anda telah berhasil membuat akun");
        }

        [HttpPost, Route("Login")]
        public async Task<IActionResult> Login(UserModel login)
        {
            var users = await _repo.Login(login.Username.ToLower(), login.Password);

            if (users == null)
            {
                return BadRequest("Aduh.... Mungkin Username dan Password anda salah :(");
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenRahasiauntukpemasanganjwt"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: "http://localhost:56651",
                audience: "http://localhost:56651",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString, Expired = tokeOptions.ValidTo });

        }

    }

}