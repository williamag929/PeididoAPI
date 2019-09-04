using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PedidoApi.Models
{
    public class DataGeoLoc : BaseDataAccess
    {
        public DataGeoLoc(string connectionString) : base(connectionString)
        {
        }


        [HttpGet]
        public List<GeoLocRep> GetGeoLocRep(int vend_id,DateTime fechaini, DateTime fechafin)
        {
            List<GeoLocRep> geolocs = new List<GeoLocRep>();
            GeoLocRep geolocitem = null;

            List<DbParameter> parameterList = new List<DbParameter>();


		//@vend_id = 2765,
		//@fechaini = N'2019/07/01',
		//@fechafin = N'2019/07/30'

            parameterList.Add(base.GetParameter("vend_id", vend_id));
            parameterList.Add(base.GetParameter("fechaini", fechaini));
            parameterList.Add(base.GetParameter("fechafin", fechafin));                        

            using (DbDataReader dataReader = base.GetDataReader("Get_geolocrep", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        geolocitem = new GeoLocRep();
                        geolocitem.tiporeg = (string)dataReader["tiporeg"];
                        geolocitem.regid = (int)dataReader["regid"];
                        geolocitem.fecha = (DateTime)dataReader["fecha"];
                        geolocitem.geolocpos = (string)dataReader["geolocpos"];
                        geolocitem.vend_id = (int)dataReader["vend_id"];
                        if (dataReader["cli_id"] != DBNull.Value)
                            geolocitem.cli_id = (int)dataReader["cli_id"];
                        else
                            geolocitem.cli_id = 0;

                        geolocitem.cli_nombre = (string)dataReader["cli_nombre"];
                        geolocitem.vend_nombre = (string)dataReader["vend_nombre"];
                        geolocitem.numero = (int)dataReader["numero"];
                        geolocitem.procesado = (int)dataReader["procesado"];
                        geolocitem.total = (decimal)dataReader["total"];


                        geolocs.Add(geolocitem);

                    }
                }
            }
            return geolocs;
        }

        [HttpGet]
        public List<GeoLoc> GetGeoLoc()
        {
            List<GeoLoc> geolocs = new List<GeoLoc>();
            GeoLoc geolocitem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("option", 0));

            using (DbDataReader dataReader = base.GetDataReader("sp_geoloc", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        geolocitem = new GeoLoc();
                        geolocitem.geolocid = (int)dataReader["geolocid"];
                        geolocitem.tiporeg = (string)dataReader["tiporeg"];
                        geolocitem.regid = (int)dataReader["regid"];
                        geolocitem.fecha = (DateTime)dataReader["fecha"];
                        geolocitem.geolocpos = (string)dataReader["geolocpos"];
                        geolocitem.vend_id = (int)dataReader["vend_id"];
                        if (dataReader["cli_id"] != DBNull.Value)
                            geolocitem.cli_id = (int)dataReader["cli_id"];
                        else
                            geolocitem.cli_id = 0;

                        geolocs.Add(geolocitem);

                    }
                }
            }
            return geolocs;
        }


        
        public GeoLoc CreateGeoLoc(GeoLoc Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_geolocid", SqlDbType.Int, Model.geolocid);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("tiporeg", Model.tiporeg));
            parameterList.Add(base.GetParameter("regid", Model.regid));
            parameterList.Add(base.GetParameter("fecha", Model.fecha));
            parameterList.Add(base.GetParameter("geolocpos", Model.geolocpos));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("option", 1));

            base.ExecuteNonQuery("sp_geoloc", parameterList, CommandType.StoredProcedure);

            Model.geolocid = (int)IdParamter.Value;

            return Model;
        }

    }
}