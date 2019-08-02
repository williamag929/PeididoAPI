using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
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