using System;

namespace PedidoApi.Models
{

    public class Config
    {
        public string smtp { get; internal set; }

        public string nit { get; set; }
        public string empresa { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string telefono2 { get; set; }
        public string texto1 { get; set; }
        public string texto2 { get; set; }
        public string texto3 { get; set; }
        public string usuario { get; internal set; }
        public string password { get; internal set; }
        public int port { get; internal set; }
        public string subject { get; internal set; }
        public string body { get; internal set; }
    }

    public class vpedido
    {
        public int ped_id { get; set; }
        public string ped_tipo { get; set; }
        public int ped_numero { get; set; }
        public int cli_id { get; set; }
        public string cli_nombre { get; set; }
        public int cli_suc { get; set; }
        public string cli_direccion { get; set; }
        public int vend_id { get; set; }
        public string vend_nomb { get; set; }
        public DateTime ped_fecha { get; set; }
        public DateTime ped_fec_ent { get; set; }

        public decimal ped_desc { get; set; }
        public decimal descuento {get;set;}
        public decimal ped_subtotal { get; set; }
        public decimal ped_impuesto { get; set; }
        public decimal ped_total { get; set; }
        public string cli_ciudad { get; set; }
        public string vend_zona { get; set; }
        public bool ped_procesado { get; set; }
        public bool ped_closed { get; set; }


    }

    public class ped_enc
    {
        public int ped_id { get; set; }
        public string ped_tipo { get; set; }
        public int ped_numero { get; set; }
        public int cli_id { get; set; }
        public int cli_suc { get; set; }
        public int vend_id { get; set; }
        public DateTime ped_fecha { get; set; }
        public DateTime ped_fec_ent { get; set; }
        public decimal ped_subtotal { get; set; }
        public decimal ped_impuesto { get; set; }
        public decimal ped_total { get; set; }
        public decimal ped_desc { get; set; }
        public decimal descuento {get;set;}
        public bool ped_procesado { get; set; }
        public DateTime ped_lastupdate { get; set; }
        public bool ped_closed { get; set; }
        public string ped_note { get; set; }
    }

    public class ped_det
    {
        public int ped_det_id { get; set; }
        public int ped_id { get; set; }
        public string pro_id { get; set; }
        public string pro_nom { get; set; }
        public decimal cant { get; set; }
        public decimal precio { get; set; }
        public decimal porc_desc { get; set; }
        public decimal val_desc { get; set; }
        public double porc_imp { get; set; }
        public decimal val_imp { get; set; }
        public decimal subtotal { get; set; }

    }

    public class vpedidodet
    {
        public int ped_id { get; set; }
        public int ped_det_id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal cant { get; set; }
        public decimal precio { get; set; }
        public decimal desc { get; set; }
        public decimal imp { get; set; }
        public decimal subtotal { get; set; }
        public decimal totalped { get; set; }
        public decimal pesotot { get; set; }

    }

}