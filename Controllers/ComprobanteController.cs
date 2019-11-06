using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class ComprobanteController : Controller
    {
        private readonly MyOptions _options;

        public ComprobanteController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        private DataCartera _data;
        
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var constr = _options.constr;

            _data = new DataCartera(constr);

            var cartera = _data.GetCarterabyId(id);

            return Json(cartera);
        }

        [HttpPost]
        public IActionResult SetCartera([FromBody]  cart_enc model)
        {
            var constr = _options.constr;
            
            _data = new DataCartera(constr);

            if (model.comprobanteid == 0)
            {
                model = _data.CreateCartera(model);
            }
            else
            {
                // model = _data.UpdateCartera(model);
            }
            return Json(model);
        }
    }
}