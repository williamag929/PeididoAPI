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
    public class DataCartera : BaseDataAccess
    {
        public DataCartera(string connectionString) : base(connectionString)
        {
        }

        public List<Cartera> GetCartera(int cli_nit)
        {
            List<Cartera> carteras = new List<Cartera>();

            Cartera CarteraItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("cli_nit", cli_nit));

            using (DbDataReader dataReader = base.GetDataReader("Get_Cartera", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        CarteraItem = new Cartera();
                        CarteraItem.cli_nit = (string)dataReader["CLI_NIT"];
                        if (dataReader["CLI_SUC"] != DBNull.Value)
                            CarteraItem.cli_suc = (int)dataReader["CLI_SUC"];
                        CarteraItem.cli_nombre = (string)dataReader["CLI_NOMBRE"];
                        CarteraItem.tipo = (string)dataReader["TIPO"];
                        CarteraItem.numero = (Int32)dataReader["NUMERO"];
                        CarteraItem.fecha = (DateTime)dataReader["FECHA"];
                        CarteraItem.fechaven = (DateTime)dataReader["FECHAVEN"];
                        CarteraItem.rango = (string)dataReader["RANGO"];
                        if (dataReader["SALDO"] != DBNull.Value)
                            CarteraItem.saldo = (decimal)dataReader["SALDO"];
                        if (dataReader["VEND_ID"] != DBNull.Value)
                            CarteraItem.ven_id = (Int32)dataReader["VEND_ID"];
                        if (dataReader["ESTADO"] != DBNull.Value)
                            CarteraItem.estado = (string)dataReader["ESTADO"];
                        if (dataReader["DIAS"] != DBNull.Value)
                            CarteraItem.dias = (Int32)dataReader["DIAS"];
                        carteras.Add(CarteraItem);
                    }
                }
            }
            return carteras;
        }
    }
}