using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class CotizacionController : Controller
    {

        private readonly MyOptions _options;

        public CotizacionController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataCotizacion _data;

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            //var constr = "Server=sistemas-PC\\sqlexpress;Database=lincecotizacions;user id=sa;password=12345;MultipleActiveResultSets=true";
            var constr = _options.constr;

            _data = new DataCotizacion(constr);

            try
            {

            var cotizacion = _data.GetCotizacionbyId(id);

            return Json(cotizacion);
            }
            catch
            {
                 return Json("No data");
            }
        }

        [HttpPost]
        public IActionResult SetCotizacion([FromBody]  cot_enc model)
        {
            var constr = _options.constr;
            
            _data = new DataCotizacion(constr);


            if (model.cot_id == 0)
            {
                model = _data.CreateCotizacion(model);
            }
            else
            {
                model = _data.UpdateCotizacion(model);
            }

            return Json(model);
        }
    }
}