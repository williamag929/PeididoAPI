using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PedidoApi.Models;

namespace PeididoAPI.Controllers {
    [Route ("api/[controller]")]
    public class MediopagoController : Controller {
        private readonly MyOptions _options;

        public MediopagoController (IOptions<MyOptions> optionsAccessor) {
            _options = optionsAccessor.Value;
        }

        private DataPedidos _data;

        ///cambio envio
        [HttpGet]
        public IActionResult Get () {
            try {
                var constr = _options.constr;

                _data = new DataPedidos (constr);

                return Json (_data.Getmediopagos ());

            } catch {
                return Json (HttpStatusCode.BadRequest);
            }
        }

    }
}