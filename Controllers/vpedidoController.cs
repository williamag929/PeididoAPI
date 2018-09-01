using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vPedidoController : Controller
    {
        private DataPedidos _data;
        
        private readonly MyOptions _options;
        public vPedidoController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;

            _data = new DataPedidos(constr);

            List<vpedido> pedidos = _data.GetPedidos(id);

            return Json(pedidos);
        }
    }
}