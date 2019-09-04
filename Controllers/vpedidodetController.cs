using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vPedidodetController : Controller
    {
        private DataPedidos _data;

        private readonly MyOptions _options;
        public vPedidodetController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var constr = _options.constr;

            var pedidos = new List<vpedidodet>();

            try
            {
                _data = new DataPedidos(constr);
                pedidos = _data.GetPedidosdet(id);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }

            return Json(pedidos);
        }
    }
}