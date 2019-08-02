using System;

namespace PedidoApi.Models
{
    public class vcotizacion
    {
        public int cot_id { get; set; }
        public string cot_tipo { get; set; }
        public int cot_numero { get; set; }
        public int cli_id { get; set; }
        public string cli_nombre { get; set; }
        public int cli_suc { get; set; }
        public string cli_direccion { get; set; }
        public int vend_id { get; set; }
        public string vend_nomb { get; set; }
        public DateTime cot_fecha { get; set; }
        public DateTime cot_fec_ent { get; set; }

        public decimal cot_desc { get; set; }
        public decimal cot_subtotal { get; set; }
        public decimal cot_impuesto { get; set; }
        public decimal cot_total { get; set; }
        public string cli_ciudad { get; set; }
        public string vend_zona { get; set; }
        public string cot_note {get;set;}

    }

    public class cot_enc
    {
        public int cot_id { get; set; }
        public string cot_tipo { get; set; }
        public int cot_numero { get; set; }
        public int cli_id { get; set; }
        public int cli_suc { get; set; }
        public int vend_id { get; set; }
        public DateTime cot_fecha { get; set; }
        public DateTime cot_fec_ent { get; set; }
        public decimal cot_subtotal { get; set; }
        public decimal cot_impuesto { get; set; }
        public decimal cot_total { get; set; }
        public decimal cot_desc { get; set; }
       public DateTime cot_lastupdate { get; set; }
        public string cot_note { get; set; }

    }

    public class cot_det
    {
        public int cot_det_id { get; set; }
        public int cot_id { get; set; }
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

    public class vcotizaciondet
    {
        public int cot_id { get; set; }
        public int cot_det_id { get; set; }
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