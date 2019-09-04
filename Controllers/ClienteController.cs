using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class ClienteController : Controller
    {
        private readonly MyOptions _options;

        public ClienteController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public string Index()
        {
            return "This is my default cliente...";
        }


        private DataClientes _data;



        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            //var constr = "Server=sistemas-PC\\sqlexpress;Database=lincepedidos;user id=sa;password=12345;MultipleActiveResultSets=true";

            var constr = _options.constr;

            Console.WriteLine(constr);

            //var constr = "data source=localhost\\sqlexpress;initial catalog=lincepedidos;user id=sa;password=12345;multipleactiveresultsets=True;application name=EntityFramework";

            _data = new DataClientes(constr);

            var clientes = _data.GetCliente(id);

            return Json(clientes);
        }

    }
}