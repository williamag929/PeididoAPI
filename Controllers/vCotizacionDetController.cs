using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vCotizaciondetController : Controller
    {
        private DataCotizacion _data;

        private readonly MyOptions _options;
        public vCotizaciondetController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;

            var cotizaciones = new List<vcotizaciondet>();

            try
            {
                _data = new DataCotizacion(constr);
                cotizaciones = _data.GetCotizacionesdet(id);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return Json(cotizaciones);
        }
    }
}