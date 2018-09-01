using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {

        private readonly MyOptions _options;

        public PedidoController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataPedidos _data;

        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            //var constr = "Server=sistemas-PC\\sqlexpress;Database=lincepedidos;user id=sa;password=12345;MultipleActiveResultSets=true";
            var constr = _options.constr;

            _data = new DataPedidos(constr);

            var pedido = _data.GetPedidobyId(id);

            return Json(pedido);
        }

        [HttpPost]
        public IActionResult SetPedido([FromBody]  ped_enc model)
        {
            var constr = _options.constr;
            
            _data = new DataPedidos(constr);


            if (model.ped_id == 0)
            {
                model = _data.CreatePedido(model);
            }
            else
            {
                model = _data.UpdatePedido(model);
            }

            return Json(model);
        }
    }
}