using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class GeoLocController : Controller
    {

        private readonly MyOptions _options;

        public GeoLocController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        private DataGeoLoc _data;

        [HttpGet]
        public JsonResult Get()
        {
            var constr = _options.constr;

            _data = new DataGeoLoc(constr);

            var result = _data.GetGeoLoc();

            return Json(result);
        }

        [HttpPost]
        public IActionResult SetGeoloc([FromBody] GeoLoc model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var constr = _options.constr;

            _data = new DataGeoLoc(constr);

            model.fecha = DateTime.Now;

            if (model.geolocid == 0)
            {
                model = _data.CreateGeoLoc(model);
            }

            return Json(model);

            //return CreatedAtRoute("GetById", new {id = model.ped_det_id},model);
        }
    }

}