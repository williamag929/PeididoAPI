using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class LogUserController : Controller
    {

        private DataUser _data;

        private readonly MyOptions _options;

        public LogUserController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet]
        public IActionResult Autentificar(string user, string password)
        {

            var usuario = new user();
            try
            {
                var constr = _options.constr;

                _data = new DataUser(constr);

                var usuarios = _data.GetUsers();

                usuario = usuarios.First(x => x.usuario == user);
                //var usuario = _data.GetVendedor(user);

                if (usuario.clave == password)
                {
                    return Json(usuario);
                }
                else
                {
                    return Json(new user());
                    //return BadRequest(new {message = "bad Request"});
                }
            }
            catch
            {
                return Json(usuario);
            }
            //return Json(usuario);
        }

    }
}