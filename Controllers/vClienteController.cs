using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class vClienteController : Controller
    {
        private DataClientes _data;

        private readonly MyOptions _options;
        public vClienteController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
           var constr = _options.constr;

            _data = new DataClientes(constr);

            var clientes = _data.GetClientes(id);

            return Json(clientes);
        }

    }
}