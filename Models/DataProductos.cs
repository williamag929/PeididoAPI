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
    public class DataProductos : BaseDataAccess
    {
        public DataProductos(string connectionString) : base(connectionString)
        {
        }

        
        public List<producto> GetProductos(int ped_id)
        {
            List<producto> productos = new List<producto>();
            producto productoItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();


            parameterList.Add(base.GetParameter("pedid", ped_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Productos", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        productoItem  = new producto();
                        productoItem.pro_id = (string)dataReader["PRO_ID"];
                        productoItem.pro_nom = (string)dataReader["PRO_NOM"];
                        productoItem.pro_ref = (string)dataReader["PRO_REF"];
                        productoItem.pro_und = (string)dataReader["PRO_UND"];
                        productoItem.pro_grupo1 = (string)dataReader["PRO_GRUPO1"];
                        productoItem.pro_grupo2 = (string)dataReader["PRO_GRUPO2"];
                        productoItem.pro_grupo3 = (string)dataReader["PRO_GRUPO3"];
                        productoItem.imp_cod = (int)dataReader["IMP_COD"];
                        productoItem.imp_porc = (decimal)dataReader["IMP_PORC"];
                        productoItem.precio1 = (decimal)dataReader["PRECIO1"];
                        productoItem.precio2 = (decimal)dataReader["PRECIO2"];
                        productoItem.precio3 = (decimal)dataReader["PRECIO3"];
                        productoItem.precio4 = (decimal)dataReader["PRECIO4"];
                        productoItem.precio5 = (decimal)dataReader["PRECIO5"];
                        productoItem.precio6 = (decimal)dataReader["PRECIO6"];
                        productoItem.estado = (string)dataReader["ESTADO"];

                        if (dataReader["PRECIO"] != DBNull.Value)  
                            productoItem.precio = (decimal)dataReader["PRECIO"];
                        else
                            productoItem.precio = 0;

                        if (dataReader["PESO"] != DBNull.Value)  
                            productoItem.peso = (decimal)dataReader["PESO"];
                        else
                            productoItem.peso = 0;

                        if (dataReader["ORDENADO"] != DBNull.Value)  
                            productoItem.ordenado = (decimal)dataReader["ORDENADO"];
                        else
                            productoItem.ordenado = 0;

                        if (dataReader["EXISTENCIA"] != DBNull.Value)  
                            productoItem.existencia = (decimal)dataReader["EXISTENCIA"];
                        else
                            productoItem.existencia = 0;    


                        if (dataReader["CANTPROM"] != DBNull.Value)  
                            productoItem.cantprom = (int)dataReader["CANTPROM"];
                        else
                            productoItem.cantprom = 0;

                        if (dataReader["PORC_DESCPROM"] != DBNull.Value)  
                            productoItem.porc_descprom = (decimal)dataReader["PORC_DESCPROM"];
                        else
                            productoItem.porc_descprom = 0;

                        productos.Add(productoItem);
                    }
                }
            }
            return productos;
        }


        
        public List<producto> GetProducto(int ped_id, string pro_id)
        {
            List<producto> productos = new List<producto>();
            producto productoItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();


            parameterList.Add(base.GetParameter("pedid", ped_id));
            parameterList.Add(base.GetParameter("pro_id", pro_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Producto", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        productoItem  = new producto();
                        productoItem.pro_id = (string)dataReader["PRO_ID"];
                        productoItem.pro_nom = (string)dataReader["PRO_NOM"];
                        productoItem.pro_ref = (string)dataReader["PRO_REF"];
                        productoItem.pro_und = (string)dataReader["PRO_UND"];
                        productoItem.pro_grupo1 = (string)dataReader["PRO_GRUPO1"];
                        productoItem.pro_grupo2 = (string)dataReader["PRO_GRUPO2"];
                        productoItem.pro_grupo3 = (string)dataReader["PRO_GRUPO3"];
                        productoItem.imp_cod = (int)dataReader["IMP_COD"];
                        productoItem.imp_porc = (decimal)dataReader["IMP_PORC"];
                        productoItem.precio1 = (decimal)dataReader["PRECIO1"];
                        productoItem.precio2 = (decimal)dataReader["PRECIO2"];
                        productoItem.precio3 = (decimal)dataReader["PRECIO3"];
                        productoItem.precio4 = (decimal)dataReader["PRECIO4"];
                        productoItem.precio5 = (decimal)dataReader["PRECIO5"];
                        productoItem.precio6 = (decimal)dataReader["PRECIO6"];
                        productoItem.estado = (string)dataReader["ESTADO"];

                        if (dataReader["PRECIO"] != DBNull.Value)  
                            productoItem.precio = (decimal)dataReader["PRECIO"];
                        else
                            productoItem.precio = 0;

                        if (dataReader["PESO"] != DBNull.Value)  
                            productoItem.peso = (decimal)dataReader["PESO"];
                        else
                            productoItem.peso = 0;

                        if (dataReader["ORDENADO"] != DBNull.Value)  
                            productoItem.ordenado = (decimal)dataReader["ORDENADO"];
                        else
                            productoItem.ordenado = 0;

                        if (dataReader["EXISTENCIA"] != DBNull.Value)  
                            productoItem.existencia = (decimal)dataReader["EXISTENCIA"];
                        else
                            productoItem.existencia = 0;    


                        if (dataReader["CANTPROM"] != DBNull.Value)  
                            productoItem.cantprom = (int)dataReader["CANTPROM"];
                        else
                            productoItem.cantprom = 0;

                        if (dataReader["PORC_DESCPROM"] != DBNull.Value)  
                            productoItem.porc_descprom = (decimal)dataReader["PORC_DESCPROM"];
                        else
                            productoItem.porc_descprom = 0;

                        productos.Add(productoItem);
                    }
                }
            }
            return productos;
        }

        public List<vproducto> GetListProductos(int ped_id)
        {
            List<vproducto> productos = new List<vproducto>();
            vproducto productoItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();


            parameterList.Add(base.GetParameter("pedid", ped_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_ListProductos", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        productoItem  = new vproducto();
                        productoItem.pro_id = (string)dataReader["PRO_ID"];
                        productoItem.pro_nom = (string)dataReader["PRO_NOM"];
                        productoItem.pro_und = (string)dataReader["PRO_UND"];

                        if (dataReader["PRECIO"] != DBNull.Value)  
                            productoItem.precio = (decimal)dataReader["PRECIO"];
                        else
                            productoItem.precio = 0;

                        if (dataReader["ORDENADO"] != DBNull.Value)  
                            productoItem.ordenado = (decimal)dataReader["ORDENADO"];
                        else
                            productoItem.ordenado = 0;

                        if (dataReader["EXISTENCIA"] != DBNull.Value)  
                            productoItem.existencia = (decimal)dataReader["EXISTENCIA"];
                        else
                            productoItem.existencia = 0;    

                        productos.Add(productoItem);
                    }
                }
            }
            return productos;
        }


    }

}