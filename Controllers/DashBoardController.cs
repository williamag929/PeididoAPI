using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class DashBoardController : Controller
    {

       private DataReporte _data;

        
        private readonly MyOptions _options;

  
        public DashBoardController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

         public IActionResult Get(int vend_id, int clase= 0)
        {
            //var constr = "Server=sistemas-PC\\sqlexpress;Database=lincepedidos;user id=sa;password=12345;MultipleActiveResultSets=true";
            var constr = _options.constr;

            _data = new DataReporte(constr);

            var result = _data.GetReporte(vend_id,clase);

            return Json(result);

        }

    }
}
