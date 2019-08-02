using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vCotizacionController : Controller
    {
        private DataCotizacion _data;
        
        private readonly MyOptions _options;
        public vCotizacionController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;

            _data = new DataCotizacion(constr);

            List<vcotizacion> listado = _data.GetCotizaciones(id);

            return Json(listado);
        }
    }
}