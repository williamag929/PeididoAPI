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
    public class CotizaciondetController : Controller
    {
        private DataCotizacion _data;
        private DataClientes _datacli;

        private readonly MyOptions _options;

        public CotizaciondetController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }        
        
        [HttpGet("{id}")]
        public JsonResult GetById(int id)
        {
            var constr = _options.constr;

            _data = new DataCotizacion(constr);

            var cotizacion = _data.GetCotizaciondetbyid(id);

            return Json(cotizacion);
        }

        [HttpPost]
        public IActionResult SetCotizaciondet([FromBody]  cot_det model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            var constr = _options.constr;

            
            _data = new DataCotizacion(constr);
            _datacli = new DataClientes(constr);

            //buscar el cliente
            //var ped = _data.GetCotizacionbyId(model.cot_id);

            //var cli = _datacli.GetCliente(ped.cli_id);

            //busca si el mismo producto ya se selecciono
            //para remplazarlo

            //tomar el descuento
            //tomar la lista de precio
            //model.porc_desc = cli.descuento;

            //model = _data.CreateCotizaciondet(model);

            if (model.cot_det_id == 0)
            {
                model = _data.CreateCotizaciondet(model);
            }
            else
            {
                model = _data.UpdateCotizaciondet(model);
            }

            return Json(model);

            //return CreatedAtRoute("GetById", new {id = model.cot_det_id},model);
        }

        [HttpDelete]
          public IActionResult DeleteDet(int id)
        {
            var constr = _options.constr;

            _data = new DataCotizacion(constr);

            Console.WriteLine(id.ToString());

            var cotizacion = _data.GetCotizaciondetbyid(id);

            var del = _data.DeleteCotizaciondet(cotizacion);

            return Json(cotizacion);
        }
    }
}