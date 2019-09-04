using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class DocumentosController : Controller
    {


        private DataDocumentos _data;

        
        private readonly MyOptions _options;

        public DocumentosController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        [HttpGet]
        public JsonResult GetDocumentos(string clase)
        {

            //var constr = "Server=sistemas-PC\\sqlexpress;Database=lincepedidos;user id=sa;password=12345;MultipleActiveResultSets=true";
            var constr = _options.constr;

            _data = new DataDocumentos(constr);

            var result = _data.GetDocumentos(clase);

            return Json(result);

        }

    }
}
