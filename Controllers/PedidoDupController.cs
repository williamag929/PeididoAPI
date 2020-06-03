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
        public IActionResult duplica([FromBody]  ped_enc model)
        {
            Console.WriteLine("id: " + model.ped_id.ToString());

            var constr = _options.constr;

           _data = new DataPedidos(constr);

            
            var ped_id = _data.ped_duplica(model.ped_id);

            //todo: actualizar con modelo recibido para enviar notas
            //_data.UpdateCotizacion(model);

            try
            {
                creaPdf(model);
            }
            catch{}

            Console.WriteLine("id" + ped_id);

            return Json(ped_id);
        }

    }
}