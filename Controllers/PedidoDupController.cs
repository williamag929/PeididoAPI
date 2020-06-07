using Microsoft.AspNetCore.Mvc;
using PedidoApi.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Data;
using System;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Net.Http;

namespace PedidoApi.Controllers
{
    [Route("api/[controller]")]
    public class PedidoDupController : Controller
    {

        private readonly MyOptions _options;

        public PedidoDupController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataPedidos _data;

        [HttpPost]
        public IActionResult duplica([FromBody] ped_enc model)
        {
            Console.WriteLine("id: " + model.ped_id.ToString());

            var constr = _options.constr;

            _data = new DataPedidos(constr);
            //todo: actualizar con modelo recibido para enviar notas
            //_data.UpdateCotizacion(model);

            try
            {
                var new_ped_id = _data.ped_duplica(model.ped_id);
                Console.WriteLine("id" + new_ped_id);

                return Json(new_ped_id);
            }
            catch { }

            return Json(404);

        }

    }
}