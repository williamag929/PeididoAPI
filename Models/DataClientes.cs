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
    public class DataClientes : BaseDataAccess
    {
        public DataClientes(string connectionString) : base(connectionString)
        {
        }

        public List<Cliente> GetClientes(int vend_id)
        {
            List<Cliente> clientes = new List<Cliente>();
            Cliente ClienteItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Clientes", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ClienteItem = new Cliente();
                        ClienteItem.cli_id = (int)dataReader["CLI_ID"];
                        if (dataReader["CLI_SUC"] != DBNull.Value)
                            ClienteItem.cli_suc = (int)dataReader["CLI_SUC"];
                        else 
                            ClienteItem.cli_suc = 0;

                        if (dataReader["CLI_NIT"] != DBNull.Value)    
                            ClienteItem.cli_nit = (string)dataReader["CLI_NIT"];
                        if (dataReader["CLI_NOMBRE"] != DBNull.Value)
                            ClienteItem.cli_nombre = (string)dataReader["CLI_NOMBRE"];
                        if (dataReader["CLI_DIRECCION"] != DBNull.Value)
                            ClienteItem.cli_direccion = (string)dataReader["CLI_DIRECCION"];
                        if (dataReader["CLI_CIUDAD"] != DBNull.Value)
                            ClienteItem.cli_ciudad = (string)dataReader["CLI_CIUDAD"];
                        if (dataReader["CLI_DEPTO"] != DBNull.Value)
                            ClienteItem.cli_depto = (string)dataReader["CLI_DEPTO"];
                        if (dataReader["CLI_PAIS"] != DBNull.Value)
                            ClienteItem.cli_pais = (string)dataReader["CLI_PAIS"];
                        if (dataReader["CLI_PHONE1"] != DBNull.Value)
                            ClienteItem.cli_phone1 = (string)dataReader["CLI_PHONE1"];
                        if (dataReader["CLI_PHONE2"] != DBNull.Value)
                            ClienteItem.cli_phone2 = (string)dataReader["CLI_PHONE2"];


                        try
                        {
                            ClienteItem.cli_cupo = (decimal)dataReader["CLI_CUPO"];
                        }
                        catch
                        {
                            ClienteItem.cli_cupo = 0;
                        }

                        ClienteItem.cli_estado = (string)dataReader["CLI_ESTADO"];

                        try
                        {
                            ClienteItem.cli_orden = (int)dataReader["CLI_ORDEN"];
                        }
                        catch
                        {
                            ClienteItem.cli_orden = 0;
                        }

                        if (dataReader["CLI_EMAIL"] != DBNull.Value)
                            ClienteItem.cli_email = (string)dataReader["CLI_EMAIL"];

                        if (dataReader["CLI_EMAIL"] != DBNull.Value) 
                            ClienteItem.lista_id = (string)dataReader["LISTA_ID"];
                        else
                            ClienteItem.lista_id = "1";

                        try
                        {
                            ClienteItem.vend_id = (int)dataReader["VEND_ID"];
                        }
                        catch { }
                        if (dataReader["CLI_EMAIL"] != DBNull.Value) 
                            ClienteItem.nivel = (string)dataReader["NIVEL"];

                        if (dataReader["COD_NIVEL"] != DBNull.Value)
                            ClienteItem.cod_nivel = (string)dataReader["COD_NIVEL"];

                        if (dataReader["DESCUENTO"] != DBNull.Value)
                            ClienteItem.descuento = (decimal)dataReader["DESCUENTO"];

                        clientes.Add(ClienteItem);
                    }
                }
            }
            return clientes;
        }


        public Cliente GetCliente(int cli_id)
        {
            //List<Cliente> clientes = new List<Cliente>();
            Cliente ClienteItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("cli_id", cli_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Cliente", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ClienteItem = new Cliente();
                       
                          ClienteItem = new Cliente();
                        ClienteItem.cli_id = (int)dataReader["CLI_ID"];
                        if (dataReader["CLI_SUC"] != DBNull.Value)
                            ClienteItem.cli_suc = (int)dataReader["CLI_SUC"];
                        else 
                            ClienteItem.cli_suc = 0;

                        if (dataReader["CLI_NIT"] != DBNull.Value)    
                            ClienteItem.cli_nit = (string)dataReader["CLI_NIT"];
                        if (dataReader["CLI_NOMBRE"] != DBNull.Value)
                            ClienteItem.cli_nombre = (string)dataReader["CLI_NOMBRE"];
                        if (dataReader["CLI_DIRECCION"] != DBNull.Value)
                            ClienteItem.cli_direccion = (string)dataReader["CLI_DIRECCION"];
                        if (dataReader["CLI_CIUDAD"] != DBNull.Value)
                            ClienteItem.cli_ciudad = (string)dataReader["CLI_CIUDAD"];
                        if (dataReader["CLI_DEPTO"] != DBNull.Value)
                            ClienteItem.cli_depto = (string)dataReader["CLI_DEPTO"];
                        if (dataReader["CLI_PAIS"] != DBNull.Value)
                            ClienteItem.cli_pais = (string)dataReader["CLI_PAIS"];
                        if (dataReader["CLI_PHONE1"] != DBNull.Value)
                            ClienteItem.cli_phone1 = (string)dataReader["CLI_PHONE1"];
                        if (dataReader["CLI_PHONE2"] != DBNull.Value)
                            ClienteItem.cli_phone2 = (string)dataReader["CLI_PHONE2"];


                        try
                        {
                            ClienteItem.cli_cupo = (decimal)dataReader["CLI_CUPO"];
                        }
                        catch
                        {
                            ClienteItem.cli_cupo = 0;
                        }

                        ClienteItem.cli_estado = (string)dataReader["CLI_ESTADO"];

                        try
                        {
                            ClienteItem.cli_orden = (int)dataReader["CLI_ORDEN"];
                        }
                        catch
                        {
                            ClienteItem.cli_orden = 0;
                        }

                        if (dataReader["CLI_EMAIL"] != DBNull.Value)
                            ClienteItem.cli_email = (string)dataReader["CLI_EMAIL"];

                        if (dataReader["CLI_EMAIL"] != DBNull.Value) 
                            ClienteItem.lista_id = (string)dataReader["LISTA_ID"];
                        else
                            ClienteItem.lista_id = "1";

                        try
                        {
                            ClienteItem.vend_id = (int)dataReader["VEND_ID"];
                        }
                        catch { }
                        if (dataReader["CLI_EMAIL"] != DBNull.Value) 
                            ClienteItem.nivel = (string)dataReader["NIVEL"];

                        if (dataReader["COD_NIVEL"] != DBNull.Value)
                            ClienteItem.cod_nivel = (string)dataReader["COD_NIVEL"];
                            
                        if (dataReader["DESCUENTO"] != DBNull.Value)
                            ClienteItem.descuento = (decimal)dataReader["DESCUENTO"];

                        try
                        {
                            ClienteItem.pedidos = (int)dataReader["pedidos"];
                        }
                        catch { }

                        try
                        {
                            ClienteItem.visitas = (int)dataReader["visitas"];
                        }
                        catch { }

                        try
                        {
                            ClienteItem.cartera = (int)dataReader["cartera"];
                        }
                        catch { }

                        try
                        {
                            ClienteItem.cotizaciones = (int)dataReader["cotizaciones"];
                        }
                        catch { }

                        //clientes.Add(ClienteItem);
                    }
                }
            }
            return ClienteItem;
        }

        public Cliente CreateCliente(Cliente Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter TestIdParamter = base.GetParameterOut("TestId", SqlDbType.Int, Model.cli_id);
            parameterList.Add(TestIdParamter);
            parameterList.Add(base.GetParameter("Name", Model.cli_nombre));

            base.ExecuteNonQuery("Cliente_Create", parameterList, CommandType.StoredProcedure);

            Model.cli_id = (int)TestIdParamter.Value;

            return Model;
        }
    }

}