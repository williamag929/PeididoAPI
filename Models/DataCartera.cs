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

        //consulta cartera
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


        #region crud
        ///traer pedido por id
        public cart_enc GetCarterabyId(int comprobanteid)
        {
            var Model = new cart_enc();
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(base.GetParameter("option", 0));
            parameterList.Add(base.GetParameter("comprobanteid", comprobanteid));
            parameterList.Add(base.GetParameter("tipodocid ", null));
            parameterList.Add(base.GetParameter("numero", null));
            parameterList.Add(base.GetParameter("prefijo", null));
            parameterList.Add(base.GetParameter("fecha", null));
            parameterList.Add(base.GetParameter("clienteid", null));
            parameterList.Add(base.GetParameter("sucursalid", null));
            parameterList.Add(base.GetParameter("fechains", null));
            parameterList.Add(base.GetParameter("fechamod", null));
            parameterList.Add(base.GetParameter("vendid", null));
            parameterList.Add(base.GetParameter("totalrecibido", null));
            parameterList.Add(base.GetParameter("estado", null));
            parameterList.Add(base.GetParameter("new_comprobanteid", null));

            var vcarteraItem = new cart_enc();

            using (DbDataReader dataReader = base.GetDataReader("sp_comprobante", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        vcarteraItem = new cart_enc();
                        vcarteraItem.comprobanteid = (int)dataReader["COMPROBANTEID"];
                        vcarteraItem.tipodocid = (int)dataReader["TIPODOCID"];
                        vcarteraItem.numero = (int)dataReader["NUMERO"];
                        vcarteraItem.prefijo = (var)dataReader["PREFIJO"];
                        vcarteraItem.fecha = (DateTime)dataReader["FECHA"];
                        vcarteraItem.clienteid = (int)dataReader["CLIENTEID"];
                        vcarteraItem.sucursalid = (int)dataReader["SUCURSALID"];
                        vcarteraItem.fechains = (DateTime)dataReader["FECHAINS"];
                        vcarteraItem.fechamod = (DateTime)dataReader["FECHAMOD"];
                        vcarteraItem.vendid = (int)dataReader["VENDID"];
                        vcarteraItem.totalrecibido = (float)dataReader["TOTALRECIBIDO"];
                        vcarteraItem.estado = (char)dataReader["ESTADO"];
                    }
                }
            }
            return vcarteraItem;
        }

        ///Crea encabezado comprobante
        public cart_enc CreateCartera(cart_enc Model)
        {

            Console.WriteLine("Crea Comprobante " + Model.prefijo);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_comprobanteid", SqlDbType.Int, Model.comprobanteid);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("comprobanteid", Model.comprobanteid));
            parameterList.Add(base.GetParameter("tipodocid", Model.tipodocid));
            parameterList.Add(base.GetParameter("numero", Model.numero));
            parameterList.Add(base.GetParameter("prefijo", Model.prefijo));
            parameterList.Add(base.GetParameter("fecha", Model.fecha));
            parameterList.Add(base.GetParameter("clienteid", Model.clienteid));
            parameterList.Add(base.GetParameter("sucursalid", Model.sucursalid));
            parameterList.Add(base.GetParameter("fechains", Model.fechains));
            parameterList.Add(base.GetParameter("fechamod", Model.fechamod));
            parameterList.Add(base.GetParameter("vendid ", Model.vendid ));
            parameterList.Add(base.GetParameter("totalrecibido ", Model.totalrecibido ));
            parameterList.Add(base.GetParameter("estado", Model.estado));           
            parameterList.Add(base.GetParameter("option", 1));


            base.ExecuteNonQuery("sp_comprobante", parameterList, CommandType.StoredProcedure);

            Model.comprobanteid = (int)IdParamter.Value;

            return Model;
        }

        #endregion
    }
}