using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidoApi.Models;

namespace PedidoApi.Models
{

    public class DataReporte : BaseDataAccess
    {
        public DataReporte(string connectionString) : base(connectionString)
        {
        }

        public class reporte
        {
            public string texto { get; set; }
            public decimal valor { get; set; }
        }


        public List<reporte> GetReporte(int vend_id, int clase)
        {
            List<reporte> Data = new List<reporte>();
            reporte DataItem = null;

            var procedure = "Get_TopProductos";

            if (clase == 1)
            {
                procedure = "Get_TopCliente";
            }


            if (clase == 2)
            {
                procedure = "Get_topcategoria";
            }

            //0. Get_topproductos
            //1. Get_topcliente
            //2. Get_topcategoria

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader(procedure, parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DataItem = new reporte();
                        DataItem.texto = (string)dataReader["texto"];
                        DataItem.valor = (decimal)dataReader["valor"];
                        Data.Add(DataItem);
                    }
                }
            }
            return Data;
        }



    }
}