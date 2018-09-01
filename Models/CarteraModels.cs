using System;

namespace PedidoApi.Models
{
    public class Cartera
    {
        public string cli_nit {get;set;}
        public int cli_suc {get;set;}
        public string cli_nombre {get;set;}
        public string tipo {get;set;}
        public int numero {get;set;}
        public DateTime fecha {get;set;}
        public DateTime fechaven {get;set;}
        public string rango {get;set;}
        public decimal saldo {get;set;}
        public int ven_id {get;set;}
        public string estado {get;set;}
        public int dias {get;set;}
    }

}