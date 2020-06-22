using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PedidoApi.Models;

namespace PedidoApi.Controllers {
    [Route ("api/[controller]")]

    public class ProductoImgController : Controller {

        private readonly MyOptions _options;

        public ProductoImgController (IOptions<MyOptions> optionsAccessor) {
            _options = optionsAccessor.Value;
        }

        private DataProductos _data;

        [HttpGet ("{id}")]
        public JsonResult GetById (string id) {
        
            var constr = _options.constr;

            _data = new DataProductos (constr);

            var productoimg = _data.GetProductoimg (id);

            return Json (productoimg);
        }
    }
}