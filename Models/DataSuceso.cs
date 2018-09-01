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
    public class DataSuceso : BaseDataAccess
    {
        public DataSuceso(string connectionString) : base(connectionString)
        {
        }


        
        public ped_det CreateSuceso(ped_det Model)
        {
            Console.WriteLine("Guarda detalle");
            Console.WriteLine("ped_id "+Model.ped_id);

            Console.WriteLine("pro_id "+Model.pro_id);
            
            Console.WriteLine("cant "+Model.cant);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_ped_det_id", SqlDbType.Int, Model.ped_det_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("ped_det_id", Model.ped_det_id));
            parameterList.Add(base.GetParameter("ped_id", Model.ped_id));
            parameterList.Add(base.GetParameter("prod_id", Model.pro_id));
            parameterList.Add(base.GetParameter("cant", Model.cant));
            parameterList.Add(base.GetParameter("precio", Model.precio));
            parameterList.Add(base.GetParameter("porc_desc", Model.porc_desc));
            parameterList.Add(base.GetParameter("val_desc", Model.val_desc));
            parameterList.Add(base.GetParameter("porc_imp", Model.porc_imp));
            parameterList.Add(base.GetParameter("val_imp", Model.val_imp));
            parameterList.Add(base.GetParameter("subtotal", Model.subtotal));
            parameterList.Add(base.GetParameter("option", 1));


            base.ExecuteNonQuery("sp_pedidodet", parameterList, CommandType.StoredProcedure);

            Model.ped_det_id = (int)IdParamter.Value;

            return Model;
        }

    }
}