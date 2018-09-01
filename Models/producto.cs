namespace PedidoApi.Models
{

    public class producto
    {
        public string pro_id { get; set; }
        public string pro_nom { get; set; }
        public string pro_ref { get; set; }
        public string pro_und { get; set; }
        public string pro_grupo1 { get; set; }
        public string pro_grupo2 { get; set; }
        public string pro_grupo3 { get; set; }
        public int imp_cod { get; set; }
        public decimal imp_porc { get; set; }
        public decimal precio {get; set;}
        public decimal precio1 { get; set; }
        public decimal precio2 { get; set; }
        public decimal precio3 { get; set; }
        public decimal precio4 { get; set; }
        public decimal precio5 { get; set; }
        public decimal precio6 { get; set; }
        public string estado { get; set; }
        public decimal? peso { get; set; }

    }
}