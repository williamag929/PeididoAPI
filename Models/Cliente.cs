namespace PedidoApi.Models
{
    public class Cliente
    {
        public int cli_id { get; set; }
        public int cli_suc { get; set; }
        public string cli_nit { get; set; }
        public string cli_nombre { get; set; }
        public string cli_direccion { get; set; }
        public string cli_ciudad { get; set; }
        public string cli_depto { get; set; }
        public string cli_pais { get; set; }

        public string cli_phone1 { get; set; }
        public string cli_phone2 { get; set; }
        public decimal cli_cupo { get; set; }
        public string cli_estado { get; set; }
        public int? cli_orden { get; set; }
        public string cli_email { get; set; }
        public string lista_id { get; set; }
        public int? vend_id { get; set; }

        public string nivel { get; set; }
        public string cod_nivel { get; set; }

        public decimal descuento { get; set; }
    }

}