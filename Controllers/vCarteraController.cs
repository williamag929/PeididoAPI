using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vCarteraController : Controller
    {
        private DataCartera _data;
        
        private readonly MyOptions _options;

        public vCarteraController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;
            
            _data = new DataCartera(constr);

            List<Cartera> listado = _data.GetCartera(id);

            return Json(listado);
        }
    }
}