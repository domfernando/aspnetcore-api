using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Core;
using Core.Models;
using Core.Repository;
using Core.Services;

namespace Core.Controllers
{
    [Route("v1/account")]
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {
            var user = UserRepo.Get(model.UserName, model.Password);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado" });
            }

            var token = TokenService.GenerateToken(user);
            user.Password="";

            return new
            {
                user = user,
                token = token
            };
        }

        [HttpGet]
        [Route("/inicio")]
        [AllowAnonymous]
        public string Inicio() => "Página Inicial";

        [HttpGet]
        [Route("firma")]
        [Authorize]
        public string Firma() => string.Format("Olá {0}", User.Identity.Name);

        [HttpGet]
        [Route("chefia")]
        [Authorize(Roles = "Gerente")]
        public string Chefia() => string.Format("Olá gerente {0}", User.Identity.Name);
    }
}