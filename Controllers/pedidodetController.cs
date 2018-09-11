using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class PedidodetController : Controller
    {
        private DataPedidos _data;
        private DataClientes _datacli;

        private readonly MyOptions _options;

        public PedidodetController(IOptions<MyOptions> optionsAccessor)
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
        public IActionResult SetPedidodet([FromBody]  ped_det model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var constr = _options.constr;

            
            _data = new DataPedidos(constr);
            _datacli = new DataClientes(constr);

            //buscar el cliente
            var ped = _data.GetPedidobyId(model.ped_id);

            var cli = _datacli.GetCliente(ped.cli_id);

            //tomar el descuento
            //tomar la lista de precio
            model.porc_desc = cli.descuento;

            //model = _data.CreatePedidodet(model);

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

        [HttpDelete]
          public IActionResult DeleteDet(int id)
        {
            var constr = _options.constr;

            _data = new DataPedidos(constr);

            Console.WriteLine(id.ToString());

            var pedido = _data.GetPedidodetbyid(id);

            var del = _data.DeletePedidodet(pedido);

            return Json(pedido);
        }
    }
}