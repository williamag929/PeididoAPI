using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using System.Linq;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]

    public class VendedorController : Controller
    {

        private readonly MyOptions _options;

        public VendedorController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataVendedores _data;


        public JsonResult Index()
        {
             var constr = _options.constr;

            _data = new DataVendedores(constr);

            return Json(_data.GetVendedores());
        }

        [HttpGet("{id}")]
        public JsonResult GetVendedor(int id)
        {
            var constr = _options.constr;

            _data = new DataVendedores(constr);

            var vendedores = _data.GetVendedores();


            var item = vendedores.Where(x=>x.vend_id == id).First();

            //var usuario = _data.GetVendedor(user);

            return Json(item);
        }

    }
}