using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System.Net;


namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class ConfigController : Controller
    {

        private readonly MyOptions _options;

        public ConfigController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataPedidos _data;

        ///cambio envio
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var constr = _options.constr;

                _data = new DataPedidos(constr);

                Config config = _data.GetConfig();

                return Json(config);

            }
            catch
            {
                return Json(HttpStatusCode.BadRequest);
            }
        }

    }
}