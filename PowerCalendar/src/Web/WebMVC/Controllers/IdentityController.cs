using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using WebMVC.Contract;
using WebMVC.DTO;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    [AllowAnonymous]
    public class IdentityController : Controller
    {

        private readonly ISecurityUserService _securityUserService;
        public IdentityController(ISecurityUserService securityUserService)
        {
            _securityUserService = securityUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Login(IdentityLoginUserViewModel identityLoginUserViewModel)
        {
            UserGetDTQ userGet = new UserGetDTQ();
            userGet.Email = identityLoginUserViewModel.Email;
            userGet.Password = identityLoginUserViewModel.Password;
            
            AnswerDTO<UserVO> answerUser = await this._securityUserService.Get(userGet);

            if (!string.IsNullOrEmpty(answerUser.Message))
            {
                ModelState.AddModelError(string.Empty, answerUser.Message);
                return View("Index", identityLoginUserViewModel);
                
            }
            if (answerUser.Data == null)
            {
                ModelState.AddModelError(string.Empty, "Usuario ou senha invalido");
                return View("Index", identityLoginUserViewModel);
            }
            UserVO user = answerUser.Data;

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal();
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));

            foreach (RoleVO role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Description));
            }

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            claimsPrincipal.AddIdentity(identity);
            AuthenticationProperties authenticationProperties = new AuthenticationProperties() { IsPersistent = false, ExpiresUtc = DateTimeOffset.MaxValue };
            await this.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);

            return RedirectToAction("Dashboard", "Home");
        }
    }
}
