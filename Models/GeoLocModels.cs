using System;

namespace PedidoApi.Models
{

    public class GeoLoc
    {
        public int geolocid {get;set;}
        public string tiporeg {get;set;}
        public int regid {get;set;}
        public DateTime fecha {get;set;}
        public string geolocpos {get;set;}
        public int vend_id {get;set;}
        public int cli_id {get;set;}
    }

}