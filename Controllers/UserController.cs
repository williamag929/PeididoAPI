using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class UserController : Controller
    {

        private DataVendedores _data;

        private readonly MyOptions _options;

        public UserController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet]
        public IActionResult Autentificar(string user, string password)
        {

            var usuario = new vendedor();
            try
            {
                var constr = _options.constr;

                _data = new DataVendedores(constr);

                var usuarios = _data.GetVendedores();

                usuario = usuarios.First(x => x.usuario == user);
                //var usuario = _data.GetVendedor(user);

                if (usuario.password == password)
                {
                    return Json(usuario);
                }
                else
                {
                    //return Json(usuario);
                    return BadRequest(new {message = "bad Request"});
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