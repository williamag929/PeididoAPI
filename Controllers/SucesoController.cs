using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class SucesoController : Controller
    {
        private DataPedidos _data;

        private readonly MyOptions _options;

        public SucesoController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }        
        
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var constr = _options.constr;

            _data = new DataPedidos(constr);

            var pedido = _data.GetPedidodetbyid(id);

            return Json(pedido);
        }

        [HttpPost]
        public IActionResult SetSuceso([FromBody]  ped_det model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var constr = _options.constr;

            
            _data = new DataPedidos(constr);

            
            model = _data.CreatePedidodet(model);

            if (model.ped_det_id == 0)
            {
                model = _data.CreatePedidodet(model);
            }
            else
            {
                model = _data.UpdatePedidodet(model);
            }

            return Json(model);

            //return CreatedAtRoute("GetById", new {id = model.ped_det_id},model);
        }
    }
}