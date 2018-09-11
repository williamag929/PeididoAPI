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

       public List<Suceso> GetSucesos(int vend_id)
        {
            List<Suceso> lista = new List<Suceso>();
            Suceso model = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_sucesos", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        model = new Suceso();
                        model.sucesoid = (int)dataReader["suceso_id"];
                        model.vend_id = (int)dataReader["vend_id"];
                        model.cli_id = (int)dataReader["cli_id"];
                        model.fecha = (DateTime)dataReader["fecha"];

                        if (dataReader["tiempo"] != DBNull.Value)
                            model.tiempo = (decimal)dataReader["tiempo"];

                        model.cadena = (string)dataReader["cadena"];
                        model.nota = (string)dataReader["nota"];
                        model.tipo = (string)dataReader["tipo"]; 

                        lista.Add(model);

                    }
                }
            }
            return lista;
        }


        
        public Suceso CreateSuceso(Suceso Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_sucesoid", SqlDbType.Int, Model.sucesoid);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("sucesoid", Model.sucesoid));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("fecha", Model.fecha));
            parameterList.Add(base.GetParameter("tiempo", Model.tiempo));
            parameterList.Add(base.GetParameter("cadena", Model.cadena));
            parameterList.Add(base.GetParameter("nota", Model.nota));
            parameterList.Add(base.GetParameter("tipo", Model.tipo));
            parameterList.Add(base.GetParameter("option", 1));


            base.ExecuteNonQuery("sp_suceso", parameterList, CommandType.StoredProcedure);

            Model.sucesoid = (int)IdParamter.Value;

            return Model;
        }


        public Suceso GetSucesobyId(int sucesoid)
        {
            //Console.WriteLine(ped_id.ToString());

            var Model = new Suceso();
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(base.GetParameter("sucesoid", Model.sucesoid));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("fecha", Model.fecha));
            parameterList.Add(base.GetParameter("tiempo", Model.tiempo));
            parameterList.Add(base.GetParameter("cadena", Model.cadena));
            parameterList.Add(base.GetParameter("nota", Model.nota));
            parameterList.Add(base.GetParameter("tipo", Model.tipo));
            parameterList.Add(base.GetParameter("option", 1));

            parameterList.Add(base.GetParameter("new_sucesoid", null));

            var model = new Suceso();

            using (DbDataReader dataReader = base.GetDataReader("sp_suceso", parameterList, CommandType.StoredProcedure))
            {

                //Console.WriteLine("Leyendo");

                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        model = new Suceso();
                        model.sucesoid = (int)dataReader["suceso_id"];
                        model.vend_id = (int)dataReader["vend_id"];
                        model.cli_id = (int)dataReader["cli_id"];
                        model.fecha = (DateTime)dataReader["fecha"];

                        if (dataReader["tiempo"] != DBNull.Value)
                            model.tiempo = (decimal)dataReader["tiempo"];

                        model.cadena = (string)dataReader["cadena"];
                        model.nota = (string)dataReader["nota"];
                        model.tipo = (string)dataReader["tipo"];                                                

                        //if (dataReader["PESO"] != DBNull.Value)  
                        //    productoItem.peso = (decimal)dataReader["PESO"];
                        //else
                        //    productoItem.peso = 0;

                    }
                }
            }
            return model;

        }


        public Suceso DeleteSuceso(Suceso Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_sucesoid", SqlDbType.Int, Model.sucesoid);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("sucesoid", Model.sucesoid));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("fecha", Model.fecha));
            parameterList.Add(base.GetParameter("tiempo", Model.tiempo));
            parameterList.Add(base.GetParameter("cadena", Model.cadena));
            parameterList.Add(base.GetParameter("nota", Model.nota));
            parameterList.Add(base.GetParameter("tipo", Model.tipo));
            parameterList.Add(base.GetParameter("option", 3));


            base.ExecuteNonQuery("sp_pedido", parameterList, CommandType.StoredProcedure);

            //Model.sucesoid = (int)IdParamter.Value;

            return Model;
        }
    }
}