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
    public class DataVendedores : BaseDataAccess
    {
        public DataVendedores(string connectionString) : base(connectionString)
        {
        }


        public vendedor GetVendedor(string user)
        {

            List<vendedor> lista = GetVendedores();
            
            vendedor vendedorItem = new vendedor();

            try
            {
                vendedorItem = lista.Where(c => c.usuario == user).First();

                Console.WriteLine(vendedorItem.vend_nomb);                
            }
            catch (System.Exception)
            {
                throw;
            }

            return vendedorItem;
        }

        public List<vendedor> GetVendedores()
        {
            List<vendedor> vendedores = new List<vendedor>();

            List<DbParameter> parameterList = new List<DbParameter>();

            //parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Vendedores", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        vendedor vendedorItem = new vendedor();

                        vendedorItem.vend_id = (int)dataReader["VEND_ID"];
                        if (dataReader["VEND_NOMB"] != DBNull.Value)
                            vendedorItem.vend_nomb = (string)dataReader["VEND_NOMB"];
                        else
                            vendedorItem.vend_nomb = "";
                        if (dataReader["VEND_TELEFONO"] != DBNull.Value)
                            vendedorItem.vend_telefono = (string)dataReader["VEND_TELEFONO"];
                        else
                            vendedorItem.vend_telefono = "";

                        if (dataReader["VEND_ZONA"] != DBNull.Value)
                            vendedorItem.vend_zona = (string)dataReader["VEND_ZONA"];
                        else
                            vendedorItem.vend_zona = "";

                        if (dataReader["VEND_ESTADO"] != DBNull.Value)
                            vendedorItem.vend_estado = (string)dataReader["VEND_ESTADO"];
                        else
                            vendedorItem.vend_estado = "";

                        if (dataReader["USUARIO"] != DBNull.Value)
                            vendedorItem.usuario = (string)dataReader["USUARIO"];

                        if (dataReader["PASSWORD"] != DBNull.Value)
                            vendedorItem.password = (string)dataReader["PASSWORD"];

                        if (dataReader["EMAIL"] != DBNull.Value)
                            vendedorItem.email = (string)dataReader["EMAIL"];
                        else
                            vendedorItem.email = "";

                        if (dataReader["VEND_EMAIL"] != DBNull.Value)
                            vendedorItem.vend_email = (string)dataReader["VEND_EMAIL"];
                        else
                            vendedorItem.vend_email = "";

                        if (dataReader["MODPRECIO"] != DBNull.Value)
                            vendedorItem.modprecio = (bool)dataReader["MODPRECIO"];
                        else
                            vendedorItem.modprecio = false;

                        if (dataReader["VEREXISTENCIA"] != DBNull.Value)
                            vendedorItem.verexistencia = (bool)dataReader["VEREXISTENCIA"];
                        else
                            vendedorItem.verexistencia = false;


                        vendedores.Add(vendedorItem);
                    }
                }
            }

            foreach (var item in vendedores)
            {
                Console.WriteLine(item.vend_nomb);
            }

            return vendedores;

        }
    }
}