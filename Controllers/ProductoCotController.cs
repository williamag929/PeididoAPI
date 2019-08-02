using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductoCotController : Controller
    {
        //private readonly NetCoreContext _context;  //in memory context

        //public string Index()
        //{
        //    return "This is my default cliente...";
        //}


        private DataProductos _data;

        private readonly MyOptions _options;

        public ProductoCotController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }   
        
             

        [HttpGet("{id}")]
        public IEnumerable<vproducto>  Get(int id)
        {

            var constr = _options.constr;

            _data = new DataProductos(constr);

            var productos = _data.GetListProductosCot(id).OrderBy(x=>x.pro_nom);
            
            return(productos);

        }

        public producto Get(int id,string pro_id)
        {

            var constr = _options.constr;

            _data = new DataProductos(constr);

            var productos = _data.GetProductoCot(id,pro_id).OrderBy(x=>x.pro_nom);

            //var producto = productos.Where(c=>c.pro_id == pro_id).First();
            
            return(productos.First());

        }
    }
}