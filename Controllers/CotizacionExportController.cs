using System;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PedidoApi.Models;

namespace PedidoApi.Controllers {
    [Route ("api/[controller]")]
    public class CotizacionExportController : Controller {

        private readonly MyOptions _options;

        public CotizacionExportController (IOptions<MyOptions> optionsAccessor) {
            _options = optionsAccessor.Value;
        }

        private DataCotizacion _data;
        private DataClientes _datacli;

        ///cambio envio
        [HttpGet ("{id}")]
        public IActionResult GetFile (int id) {

            var constr = _options.constr;

            _data = new DataCotizacion (constr);
            _datacli = new DataClientes (constr);

            var p = _data.GetCotizacionbyId (id);

            var cli = _datacli.GetCliente(p.cli_id);

            var det = _data.GetCotizacionesdet(id);

            Config config = _data.GetConfig ();

            StringBuilder sb = new StringBuilder ();

            sb.AppendLine ("pedtipo,numero,fecha,cliente,producto,cantidad,precio,descuento,subtotal,impuesto,peso,total");

            foreach (var item in det) {
                //dt.Rows.Add (item.codigo, item.descripcion, item.cant, item.precio.ToString ("c"), item.subtotal.ToString ("c"));
                sb.AppendLine ($"{p.cot_tipo},{p.cot_numero},{p.cot_fecha},{cli.cli_nombre},{item.descripcion.Replace(",","-")},{item.cant},{item.precio},{item.desc},{item.subtotal},{item.imp},{item.pesotot},{item.totalped}");

            }

            return File (Encoding.UTF8.GetBytes (sb.ToString ()), "text/csv", "pedido" + p.cot_numero + ".csv");

        }

    }

}