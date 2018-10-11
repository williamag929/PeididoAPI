namespace PedidoApi.Models
{
    public class vendedor
    {
        public int vend_id { get; set; }
        public string vend_nomb { get; set; }
        public string vend_telefono { get; set; }
        public string vend_zona { get; set; }
        public string vend_estado { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string vend_email { get; set; }

    }


    public class user{
        public string empresa {get;set;}
        public string usuario {get;set;}
        public string clave {get;set;}
        public string urlapi {get;set;}

        public string md5 {get;set;}
        public int vend_id {get;set;}
        public string email {get; set;}
    }

}