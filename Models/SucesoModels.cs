using System;

namespace PedidoApi.Models
{

    public class Suceso
    {
        public int sucesoid {get;set;}
        public int vend_id {get;set;}
        public int cli_id {get;set;}
        public DateTime fecha {get;set;}
        public decimal tiempo {get;set;}
        public string cadena {get;set;}
        public string nota {get;set;}
        public string tipo {get;set;}

    }

}