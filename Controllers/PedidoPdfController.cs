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
    public class PedidoPdfController : Controller
    {

        private readonly MyOptions _options;

        public PedidoPdfController(IOptions<MyOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }


        private DataPedidos _data;
        private DataClientes _datacli;

        ///cambio envio
        [HttpGet("{id}")]
        public IActionResult GetPdf(int id)
        {

            var constr = _options.constr;

            _data = new DataPedidos(constr);

            var p = _data.GetPedidobyId(id);

            var pdet = _data.GetPedidosdet(id);

            Config config = _data.GetConfig();

            //int numero = pedido.PED_NUMERO.Value;
            //string tipo = pedido.PED_TIPO;


            using (StringWriter sw = new StringWriter())
            {


                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("Ref."),
                            new DataColumn("Producto"),
                            new DataColumn("Cantidad"),
                            new DataColumn("Precio"),
                            new DataColumn("Subtotal")});


                foreach (var item in pdet)
                {
                    dt.Rows.Add(item.codigo, item.descripcion, item.cant, item.precio.ToString("c"), item.subtotal.ToString("c"));
                }

                double vlrbruto = Convert.ToDouble(p.ped_subtotal + p.ped_desc);
                double descuento = Convert.ToDouble(p.ped_desc);
                double subtotal = Convert.ToDouble(p.ped_subtotal);
                double impuesto = Convert.ToDouble(p.ped_impuesto);
                double total = Convert.ToDouble(p.ped_total);

                //string cliente = data.CLIENTEs.First(c => c.CLI_ID == p.CLI_ID).CLI_NIT;
                _datacli = new DataClientes(constr);

                var cli = _datacli.GetCliente(p.cli_id);

                string companyName = cli.cli_nit + "-" + cli.cli_nombre;

                if (cli.cli_email.Length > 0)
                {

                    int orderNo = Convert.ToInt32(p.ped_numero);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>"+ config.empresa + "</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Pedido No:</b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td><b>Fecha: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Tercero :</b> ");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table border = '1'>");

                    sb.Append ("<tr>");
                    sb.Append ("<th width='15%' style= 'font-size:11;'>");
                    sb.Append ("Ref.");
                    sb.Append ("</th>");
                    sb.Append ("<th colspan = '2' style= 'font-size:11;'>");
                    sb.Append ("Producto");
                    sb.Append ("</th>");
                    sb.Append ("<th width='15%' style= 'font-size:11;'>");
                    sb.Append ("Cantidad");
                    sb.Append ("</th>");
                    sb.Append ("<th width='15%' style= 'font-size:11;'>");
                    sb.Append ("Precio");
                    sb.Append ("</th>");
                    sb.Append ("<th width='15%' style= 'font-size:11;'>");
                    sb.Append ("Subtotal");
                    sb.Append ("</th>");
                    sb.Append ("</tr>");



                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName == "Producto")
                            {
                                sb.Append("<td colspan='2' style= 'font-size:10;'>");
                                sb.Append(row[column]);
                                sb.Append("</td>");

                            }
                            else
                            {
                                sb.Append("<td style= 'font-size:10;'>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }

                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' border = '1'>");
                    sb.Append("<tr><td width='15%'>Valor Bruto</td><td width='40%'>Descuento</td><td width='15%'>Subtotal</td><td width='15%'>Impuesto</td><td width='15%'>Total</td></tr>");
                    sb.Append("<tr><td>" + vlrbruto.ToString("c") + "</td><td>" + descuento.ToString("c") + "</td><td>" + subtotal.ToString("c") + "</td><td>" + impuesto.ToString("c") + "</td><td>" + total.ToString("c") + "</td></tr>");
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HtmlWorker htmlparser = new HtmlWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);


                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);



                        string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

                        FileStream Fs = System.IO.File.Create(fileName);
                        Fs.Write(bytes, 0, (int)bytes.Length);
                        Fs.Close();
                        
                        return File(bytes, "application/pdf", "pedido" + p.ped_numero + ".pdf");

                        //return File (Encoding.UTF8.GetBytes (Fs), "text/csv", "pedido" + p.ped_numero + ".csv");

                        //return File(new MemoryStream(bytes)

                        //result.Content = new StreamContent(memoryStream);

                        //result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");//octet-stream
                        //Console.WriteLine("Pdf procesado");


                        //return result;
                        //mm.Attachments.Add(new Attachment, "pedidoventa" + orderNo + ".pdf"));
                    }
                }

            }



            Console.WriteLine("Pdf bad");

            return BadRequest("request is incorrect");

            //return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }

        ///marca el pedido como cerrado
        ///validacion de descuento
        [HttpPost]
        public IActionResult SendPdf([FromBody]  ped_enc model)
        {
            Console.WriteLine("id: " + model.ped_id.ToString());

            var constr = _options.constr;

            _data = new DataPedidos(constr);

            //var p = _data.GetPedidobyId(id);

            var p = _data.GetPedidobyId(model.ped_id);

            model.ped_closed = true;

            //todo: actualizar con modelo recibido para enviar notas
            _data.UpdatePedido(model);

            try
            {
                creaPdf(model);
            }
            catch{}

            Console.WriteLine("numero" + model.ped_numero);

            return Json(model);
        }

        
	private void creaPdf(ped_enc model)
	{
            var constr = _options.constr;

            _data = new DataPedidos(constr);

            Config config = _data.GetConfig();

            var p = _data.GetPedidobyId(model.ped_id);

            var pdet = _data.GetPedidosdet(model.ped_id);

            using (StringWriter sw = new StringWriter())
            {


                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5] {
                            new DataColumn("Ref."),
                            new DataColumn("Producto"),
                            new DataColumn("Cantidad"),
                            new DataColumn("Precio"),
                            new DataColumn("Subtotal")});


                foreach (var item in pdet)
                {
                    dt.Rows.Add(item.codigo, item.descripcion, item.cant, item.precio.ToString("c"), item.subtotal.ToString("c"));
                }

                double vlrbruto = Convert.ToDouble(p.ped_subtotal + p.ped_desc);
                double descuento = Convert.ToDouble(p.ped_desc);
                double subtotal = Convert.ToDouble(p.ped_subtotal);
                double impuesto = Convert.ToDouble(p.ped_impuesto);
                double total = Convert.ToDouble(p.ped_total);

                //string cliente = data.CLIENTEs.First(c => c.CLI_ID == p.CLI_ID).CLI_NIT;
                _datacli = new DataClientes(constr);

                var cli = _datacli.GetCliente(p.cli_id);

                Console.WriteLine(p.cli_id.ToString());

                string companyName = cli.cli_nit.ToString() + "-" + cli.cli_nombre.ToString();

                if (cli.cli_email.Length > 0)
                {

                    int orderNo = Convert.ToInt32(p.ped_numero);
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Pedido de Venta</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Pedido No:</b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td><b>Fecha: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Tercero :</b> ");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    sb.Append("<th width='15%' style = 'background-color: #D20B0C;color:#ffffff'>");
                    sb.Append("Ref.");
                    sb.Append("</th>");
                    sb.Append("<th colspan = '2' style = 'background-color: #D20B0C;color:#ffffff;'>");
                    sb.Append("Producto");
                    sb.Append("</th>");
                    sb.Append("<th width='15%' style = 'background-color: #D20B0C;color:#ffffff'>");
                    sb.Append("Cantidad");
                    sb.Append("</th>");
                    sb.Append("<th width='15%' style = 'background-color: #D20B0C;color:#ffffff;width:50px'>");
                    sb.Append("Precio");
                    sb.Append("</th>");
                    sb.Append("<th width='15%' style = 'background-color: #D20B0C;color:#ffffff'>");
                    sb.Append("Subtotal");
                    sb.Append("</th>");
                    sb.Append("</tr>");


                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (column.ColumnName == "Producto")
                            {
                                sb.Append("<td colspan='2' style= 'font-size:10;'>");
                                sb.Append(row[column]);
                                sb.Append("</td>");

                            }
                            else
                            {
                                sb.Append("<td style= 'font-size:10;'>");
                                sb.Append(row[column]);
                                sb.Append("</td>");
                            }

                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2' border = '1'>");
                    sb.Append("<tr><td width='15%'>Valor Bruto</td><td width='40%'>Descuento</td><td width='15%'>Subtotal</td><td width='15%'>Impuesto</td><td width='15%'>Total</td></tr>");
                    sb.Append("<tr><td>" + vlrbruto.ToString("c") + "</td><td>" + descuento.ToString("c") + "</td><td>" + subtotal.ToString("c") + "</td><td>" + impuesto.ToString("c") + "</td><td>" + total.ToString("c") + "</td></tr>");
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HtmlWorker htmlparser = new HtmlWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);


                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        System.Net.Mail.MailAddress from = new System.Net.Mail.MailAddress(config.usuario);
                        System.Net.Mail.MailAddress to = new System.Net.Mail.MailAddress(cli.cli_email);


                        MailMessage mm = new MailMessage(from, to); //"pedidosindustriasyilop@gmail.com"
                        mm.Subject = config.subject + " " + config.empresa + " Numero: " + orderNo;  //"pedido de venta
                        mm.Body = "Adjunto a este correo, el pedido de venta numero: " + orderNo + " en formato PDF";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "pedidoventa" + orderNo + ".pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = config.smtp;//"smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = config.usuario;//"pedidosindustriasyilop@gmail.com";
                        NetworkCred.Password = config.password;// "agosto2018";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = config.port;
                        smtp.Send(mm);
                    }
                }

            }
		}



    }
}