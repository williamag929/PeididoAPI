using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vComprobanteController : Controller
    {
        private DataCartera _data;
        
        private readonly MyOptions _options;

        public vComprobanteController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;
            
            _data = new DataCartera(constr);

            List<Cartera> listado = _data.GetComprobantes(id);

            return Json(listado);
        }
    }
}