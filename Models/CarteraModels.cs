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

    public class cart_enc
    {
        public int comprobanteid {get;set;}
        public int tipodocid {get;set;}
        public int numero {get;set;}
        public string prefijo {get;set;}
        public DateTime fecha {get;set;}
        public int clienteid {get;set;}
        public int sucursalid {get;set;}
        public DateTime fechains {get;set;}
        public DateTime fechamod {get;set;}
        public int vendid {get;set;}
        public float totalrecibido {get;set;}
        public char estado {get;set;}
    }

 public class cart_det
    {
        public int comprobantedetid {get;set;}
        public int comprobanteid {get;set;}
        public int conceptoid {get;set;}
        public string cruce {get;set;}
        public int numero {get;set;}
        public int cuota {get;set;}
        public float valor {get;set;}
        public float clienteid {get;set;}
        public int sucursalid {get;set;}
        public float saldo {get;set;}
        public int vendifact {get;set;}
    }

}