using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class ListaPrecioController : Controller
    {
        //private readonly NetCoreContext _context;  //in memory context

        //public string Index()
        //{
        //    return "This is my default cliente...";
        //}


        private DataProductos _data;

        private readonly MyOptions _options;

        public ListaPrecioController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }        

        [HttpGet]
        public JsonResult Get(int pedid)
        {

            var constr = _options.constr;

            _data = new DataProductos(constr);

            var productos = _data.GetProductos(pedid).OrderBy(x=>x.pro_nom);

            return Json(productos);
        }

    }
}