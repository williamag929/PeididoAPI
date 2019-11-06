using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class ComprobantedetController : Controller
    {
        private DataCartera _data;
        private DataClientes _datacli;
        private readonly MyOptions _options;

        public ComprobantedetController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var constr = _options.constr;

            _data = new DataCartera(constr);

            var cartera = _data.GetCarterabyId(id);

            return Json(cartera);
        }

         [HttpPost]
        public IActionResult SetCarteradet([FromBody]  cart_det model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            var constr = _options.constr;

            _data = new DataCartera(constr);
            _datacli = new DataClientes(constr);

            if (model.comprobantedetid == 0)
            {
                model = _data.CreateCarteradet(model);
            }
            else
            {
                // model = _data.UpdateCarteradet(model);
            }

            return Json(model);
        }

        
        [HttpDelete]
          public IActionResult DeleteDet(int id)
        {
            var constr = _options.constr;

            _data = new DataCartera(constr);

            Console.WriteLine(id.ToString());

            var cartera = _data.GetCarteradetbyId(id);

            var del = _data.DeleteCarteradet(cartera);

            return Json(cartera);
        }
    }
}