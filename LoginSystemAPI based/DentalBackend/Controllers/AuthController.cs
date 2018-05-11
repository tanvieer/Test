using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DentalBackend.Data;
using DentalBackend.Models;
using DentalBackend.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DentalBackend.Controllers
{




    [Produces("application/json")]
   
    public class AuthController : Controller
    {


        private readonly IAuthManagerService _authRepository;
        public AuthController(IAuthManagerService authRepository)
        {
            _authRepository = authRepository;
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel loginData)
        {
            var user = _authRepository.Login(loginData);
          
            if (user == null)
                return NotFound("email or password incorrect");
            User userEntiy = new User();
            return Ok(CreateJwtPacket(user));
        }
    

        [HttpPost]
        public JwtPacket Register(LoginViewModel user)
        {
            var registerUser= _authRepository.Register(user);
           
            return CreateJwtPacket(registerUser);
           
        }

        JwtPacket CreateJwtPacket(LoginViewModel user)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("Planteen asdf sadf asdf sdf" + DateTime.UtcNow.ToString()));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId == 7 ? "Administrator" : user.RoleName)
            };

            var jwt = new JwtSecurityToken(claims: claims, signingCredentials: signingCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new JwtPacket() {
                Token = encodedJwt,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.RoleName,
                RoleId = user.RoleId
            };

        }
    }
}
