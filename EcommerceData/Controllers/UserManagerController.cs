using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using System.Web.Http;
using EcommerceData.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace EcommerceData.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signinManager;
        public UserManagerController(UserManager<IdentityUser> userManager,
         SignInManager<IdentityUser> signinManager)
        {
            this._userManager = userManager;
            this._signinManager = signinManager;

        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        //[Route("api/register")]
        public async Task<Object> PostRegister(ApplicationUserVModel s)
        {
            var user = new IdentityUser
            {
               
                UserName = s.Email,
                Email = s.Email


            };
            try
            {
                var result = await _userManager.CreateAsync(user, s.Password);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);

                    }

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                //return BadRequest();
                throw ex;
            }
            return BadRequest(user);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("login")]
        public async Task<Object> Login(LoginVModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                         new Claim("UserId",user.Id)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                                                                (Encoding.UTF8.GetBytes("1234567887456321")),
                                                                 SecurityAlgorithms.HmacSha256Signature),

                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var secToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(secToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username  or password does mot match" });
            }
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Authorize]
        //GET : /api/UserProfile
        //[System.Web.Http.Route("profile")]
        public async Task<Object> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return new
            {
               // user.Fullname,
                user.Email,
                user.UserName
            };
        }
    }
}