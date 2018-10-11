using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vSucesoController : Controller
    {
        private DataSuceso _data;
        
        private readonly MyOptions _options;
        public vSucesoController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;

            _data = new DataSuceso(constr);

            List<Suceso> modal = _data.GetSucesos(id);

            return Json(modal);
        }
    }
}