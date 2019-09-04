using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductoItemController : Controller
    {
        //private readonly NetCoreContext _context;  //in memory context

        //public string Index()
        //{
        //    return "This is my default cliente...";
        //}


        private DataProductos _data;

        private readonly MyOptions _options;

        public ProductoItemController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }  


        public class dataget 
        {
            public int ped_id {get;set;}
            public string pro_id {get;set;}
        }

        [HttpGet]
        public IActionResult Get(int ped_id, string pro_id)
        {

            var constr = _options.constr;

            _data = new DataProductos(constr);

            var productos = _data.GetProducto(ped_id,pro_id).OrderBy(x=>x.pro_nom);

            //var producto = productos.Where(c=>c.pro_id == pro_id).First();
            
            return Json(productos.First());

        }
    }
}