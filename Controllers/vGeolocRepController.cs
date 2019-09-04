using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vGeoLocRepController : Controller
    {
        private DataGeoLoc _data;
        
        private readonly MyOptions _options;
        public vGeoLocRepController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet]
        public JsonResult Get(int id, DateTime fechaini, DateTime fechafin)
        {
            var constr = _options.constr;

            _data = new DataGeoLoc(constr);

            List<GeoLocRep> reporte = _data.GetGeoLocRep(id,fechaini,fechafin);

            return Json(reporte);
        }
    }
}