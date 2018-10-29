using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Comanda.Domain.Models;
using Comanda.Infra.Cross.Identity.Models;
using Comanda.Service.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Comanda.Service.API.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }



        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    // VERIFICA SE EMAIL ESTA CONFIRMADO                    
                    var appUser = await _userManager.FindByNameAsync(model.Email);
                    if (appUser != null)
                    {

                        if (!await _userManager.IsEmailConfirmedAsync(appUser))
                        {
                            return new
                            {
                                authenticated = false,
                                message = "Not email confirmed async"
                            };
                        }
                        else
                        {
                            var tokenUser = await GenerateJwtToken(model.Email, appUser);
                            var returnUser = new UserApp() { Id = appUser.Id, Name = appUser.Name, Avatar= appUser.AvatarURL, Email= appUser.Email, UserName = appUser.UserName };
                            var returnToken = new Token() { Validate = tokenUser.ValidTo, Value = new JwtSecurityTokenHandler().WriteToken(tokenUser), Create = tokenUser.RawData };
                            
                            return new
                            {
                                authenticated = true,
                                message = "Autenticado com sucesso",
                                user = returnUser,
                                token = returnToken                                
                            };                            
                        }

                    }

                }
                if (result.RequiresTwoFactor)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar. Requires two factor"
                    };
                }
                if (result.IsLockedOut)
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar. Is locked out"
                    };
                }
                else
                {
                    return new
                    {
                        authenticated = false,
                        message = "Falha ao autenticar. Tentativa de login inválida."
                    };

                }

            }
            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<object> Register([FromBody] RegisterViewModel model)
        {
            try { 

            if (model == null)
            {
                return BadRequest(new
                {                    
                    message = "Objeto vazio",                    
                });
            }

                var date = DateTime.Now;

                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    AvatarURL = "images/avatar/default.png",
                    Name = model.Name,
                    FirstName = model.Name,
                    LastName = "",
                    DateRegistered = date,
                    Control = date,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);      
                    return await Login(new LoginViewModel(){Email = model.Email, Password = model.Password });                    
                }
                else
                {
                    return new
                    {
                        message = result.Errors.FirstOrDefault().Description                    
                    };

                }

            }
            catch (Exception e) { 
                return new
                {        
                    message = e.Message
                };

            }
        }

        [HttpGet]
        public async Task<bool> Validate()
        {
            return true;
        }

        private async Task<JwtSecurityToken> GenerateJwtToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt")["Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration.GetSection("Jwt")["ExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration.GetSection("Jwt")["Issuer"],
                _configuration.GetSection("Jwt")["Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return token;
        }


    }
}