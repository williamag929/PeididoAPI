using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;



namespace PedidoApi.Models
{
    public class DataCotizacion : BaseDataAccess
    {
        public DataCotizacion(string connectionString) : base(connectionString)
        {
        }

        [HttpGet]
        public List<vcotizacion> GetCotizaciones(int vend_id)
        {
            List<vcotizacion> vcotizaciones = new List<vcotizacion>();
            vcotizacion ItemReg = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Cotizaciones", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ItemReg = new vcotizacion();
                        ItemReg.cot_id = (int)dataReader["COT_ID"];
                        if (dataReader["COT_TIPO"] != DBNull.Value)
                            ItemReg.cot_tipo = (string)dataReader["COT_TIPO"];
                        if (dataReader["COT_NUMERO"] != DBNull.Value)
                            ItemReg.cot_numero = (int)dataReader["COT_NUMERO"];
                        if (dataReader["CLI_ID"] != DBNull.Value)
                            ItemReg.cli_id = (int)dataReader["CLI_ID"];
                        if (dataReader["CLI_NOMBRE"] != DBNull.Value)
                            ItemReg.cli_nombre = (string)dataReader["CLI_NOMBRE"];
                        if (dataReader["CLI_SUC"] != DBNull.Value)
                            ItemReg.cli_suc = (int)dataReader["CLI_SUC"];
                        if (dataReader["CLI_DIRECCION"] != DBNull.Value)
                            ItemReg.cli_direccion = (string)dataReader["CLI_DIRECCION"];
                        if (dataReader["VEND_ID"] != DBNull.Value)
                            ItemReg.vend_id = (int)dataReader["VEND_ID"];
                        if (dataReader["VEND_NOMB"] != DBNull.Value)
                            ItemReg.vend_nomb = (string)dataReader["VEND_NOMB"];
                        if (dataReader["COT_FECHA"] != DBNull.Value)
                            ItemReg.cot_fecha = (DateTime)dataReader["COT_FECHA"];
                        if (dataReader["COT_FEC_ENT"] != DBNull.Value)
                            ItemReg.cot_fec_ent = (DateTime)dataReader["COT_FEC_ENT"];


                        if (dataReader["COT_DESC"] != DBNull.Value)
                            ItemReg.cot_desc = (decimal)dataReader["COT_DESC"];
                        else
                            ItemReg.cot_desc = 0;

                        
                        if (dataReader["COT_SUBTOTAL"] != DBNull.Value)
                            ItemReg.cot_subtotal = (decimal)dataReader["COT_SUBTOTAL"];
                        else
                            ItemReg.cot_subtotal = 0;

                        if (dataReader["COT_IMPUESTO"] != DBNull.Value)
                            ItemReg.cot_impuesto = (decimal)dataReader["COT_IMPUESTO"];
                        else
                            ItemReg.cot_impuesto = 0;

                        if (dataReader["COT_TOTAL"] != DBNull.Value)
                            ItemReg.cot_total = (decimal)dataReader["COT_TOTAL"];
                        else
                            ItemReg.cot_total = 0;

                        if (dataReader["CLI_CIUDAD"] != DBNull.Value)
                            ItemReg.cli_ciudad = (String)dataReader["CLI_CIUDAD"];
                        else
                            ItemReg.cli_ciudad = "";

                        if (dataReader["VEND_ZONA"] != DBNull.Value)
                            ItemReg.vend_zona = (string)dataReader["VEND_ZONA"];
                        else
                            ItemReg.vend_zona = "";

   
                        if (dataReader["COT_NOTE"] != DBNull.Value)
                            ItemReg.cot_note = (string)dataReader["COT_NOTE"];
                        else
                            ItemReg.cot_note = "";


                        //if (dataReader["PESO"] != DBNull.Value)  
                        //    productoItem.peso = (decimal)dataReader["PESO"];
                        //else
                        //    productoItem.peso = 0;


                        vcotizaciones.Add(ItemReg);

                        //Console.WriteLine(ItemReg.cot_id);
                    }
                }
            }
            return vcotizaciones;
        }

        public Config GetConfig () {
            var Model = new Config ();
            Console.WriteLine ("Leyendo");
            List<DbParameter> parameterList = new List<DbParameter> ();
            //parameterList.Add(base.GetParameter("option", 1));
            using (DbDataReader dataReader = base.GetDataReader ("Get_Config", parameterList, CommandType.StoredProcedure)) {
                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        Model.nit = (string) dataReader["NIT"];
                        Model.empresa = (string) dataReader["EMPRESA"];
                        Model.direccion = (string) dataReader["DIRECCION"];
                        Model.telefono = (string) dataReader["TELEFONO"];
                        Model.telefono2 = (string) dataReader["TELEFONO2"];
                        Model.texto1 = (string) dataReader["TEXTO1"];
                        Model.texto2 = (string) dataReader["TEXTO2"];
                        Model.texto3 = (string) dataReader["TEXTO3"];
                        Model.smtp = (string) dataReader["smtp"];
                        Model.usuario = (string) dataReader["usuario"];
                        Model.password = (string) dataReader["password"];
                        Model.port = (int) dataReader["port"];
                        Model.subject = (string) dataReader["subject"];
                        Model.body = (string) dataReader["body"];
                        
                    }
                    Console.WriteLine (Model.texto1);
                }
            }
            return Model;
        }

        public cot_enc GetCotizacionbyId(int cot_id)
        {
            //Console.WriteLine(cot_id.ToString());
            var Model = new cot_enc();
            List<DbParameter> parameterList = new List<DbParameter>();
            parameterList.Add(base.GetParameter("option", 0));
            parameterList.Add(base.GetParameter("cot_id", cot_id));
            parameterList.Add(base.GetParameter("cot_tipo", null));
            parameterList.Add(base.GetParameter("cot_numero", null));
            parameterList.Add(base.GetParameter("cli_id", null));
            parameterList.Add(base.GetParameter("cli_suc", null));
            parameterList.Add(base.GetParameter("vend_id", null));
            parameterList.Add(base.GetParameter("cot_fecha", null));
            parameterList.Add(base.GetParameter("cot_fec_ent", null));
            parameterList.Add(base.GetParameter("cot_subtotal", null));
            parameterList.Add(base.GetParameter("cot_impuesto", null));
            parameterList.Add(base.GetParameter("cot_total", null));
            parameterList.Add(base.GetParameter("cot_desc", null));
            parameterList.Add(base.GetParameter("cot_note", null));
            parameterList.Add(base.GetParameter("new_cot_id", null));

            var ItemReg = new cot_enc();

            using (DbDataReader dataReader = base.GetDataReader("sp_cotizacion", parameterList, CommandType.StoredProcedure))
            {

                //Console.WriteLine("Leyendo");

                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        ItemReg = new cot_enc();
                        ItemReg.cot_id = (int)dataReader["COT_ID"];
                        ItemReg.cot_tipo = (string)dataReader["COT_TIPO"];
                        if (dataReader["COT_NUMERO"] != DBNull.Value)
                            ItemReg.cot_numero = (int)dataReader["COT_NUMERO"];
                        ItemReg.cli_id = (int)dataReader["CLI_ID"];
                        ItemReg.cli_suc = (int)dataReader["CLI_SUC"];
                        ItemReg.vend_id = (int)dataReader["VEND_ID"];

                        if (dataReader["COT_FECHA"] != DBNull.Value)
                            ItemReg.cot_fecha = (DateTime)dataReader["COT_FECHA"];

                        if (dataReader["COT_FEC_ENT"] != DBNull.Value)
                            ItemReg.cot_fec_ent = (DateTime)dataReader["COT_FEC_ENT"];

                        if (dataReader["COT_DESC"] != DBNull.Value)
                            ItemReg.cot_desc = (decimal)dataReader["COT_DESC"];
                        else
                            ItemReg.cot_desc = 0;

                        if (dataReader["COT_SUBTOTAL"] != DBNull.Value)
                            ItemReg.cot_subtotal = (decimal)dataReader["COT_SUBTOTAL"];
                        else
                            ItemReg.cot_subtotal = 0;

                        if (dataReader["COT_IMPUESTO"] != DBNull.Value)
                            ItemReg.cot_impuesto = (decimal)dataReader["COT_IMPUESTO"];
                        else
                            ItemReg.cot_impuesto = 0;

                        if (dataReader["COT_TOTAL"] != DBNull.Value)
                            ItemReg.cot_total = (decimal)dataReader["COT_TOTAL"];
                        else
                            ItemReg.cot_total = 0;

                        if (dataReader["COT_NOTE"] != DBNull.Value)
                            ItemReg.cot_note = (string)dataReader["COT_NOTE"];
                        else
                            ItemReg.cot_note = "";

                        //if (dataReader["PESO"] != DBNull.Value)  
                        //    productoItem.peso = (decimal)dataReader["PESO"];
                        //else
                        //    productoItem.peso = 0;

                    }
                }
            }
            return ItemReg;

        }


        public cot_enc CreateCotizacion(cot_enc Model)
        {

            Console.WriteLine("Crea Cotizacion " + Model.cli_id);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_id", SqlDbType.Int, Model.cot_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("cot_tipo", Model.cot_tipo));
            parameterList.Add(base.GetParameter("cot_numero", Model.cot_numero));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("cli_suc", Model.cli_suc));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cot_fecha", Model.cot_fecha));
            parameterList.Add(base.GetParameter("cot_fec_ent", Model.cot_fec_ent));
            parameterList.Add(base.GetParameter("cot_subtotal", Model.cot_subtotal));
            parameterList.Add(base.GetParameter("cot_impuesto", Model.cot_impuesto));
            parameterList.Add(base.GetParameter("cot_total", Model.cot_total));
            parameterList.Add(base.GetParameter("cot_desc", Model.cot_desc));
            parameterList.Add(base.GetParameter("cot_note", Model.cot_note));
            parameterList.Add(base.GetParameter("option", 1));


            base.ExecuteNonQuery("sp_cotizacion", parameterList, CommandType.StoredProcedure);

            Model.cot_id = (int)IdParamter.Value;

            return Model;
        }

        public int cot_generarpedido(cot_enc Model)
        {

            Console.WriteLine("Actualiza Cotizacion " + Model.cot_id);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_ped_id", SqlDbType.Int, Model.cot_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("cot_tipo", Model.cot_tipo));
            parameterList.Add(base.GetParameter("cot_numero", Model.cot_numero));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("cli_suc", Model.cli_suc));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cot_fecha", Model.cot_fecha));
            parameterList.Add(base.GetParameter("cot_fec_ent", Model.cot_fec_ent));
            parameterList.Add(base.GetParameter("cot_subtotal", Model.cot_subtotal));
            parameterList.Add(base.GetParameter("cot_impuesto", Model.cot_impuesto));
            parameterList.Add(base.GetParameter("cot_total", Model.cot_total));
            parameterList.Add(base.GetParameter("cot_desc", Model.cot_desc));
            parameterList.Add(base.GetParameter("cot_note", Model.cot_note));


            base.ExecuteNonQuery("sp_Cot_Pedido", parameterList, CommandType.StoredProcedure);

            var ped_id = (int)IdParamter.Value;
            //Model.cot_id = (int)IdParamter.Value;

            return ped_id;

        }


        public cot_enc UpdateCotizacion(cot_enc Model)
        {


            Console.WriteLine("Actualiza Cotizacion " + Model.cot_id);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_id", SqlDbType.Int, Model.cot_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("cot_tipo", Model.cot_tipo));
            parameterList.Add(base.GetParameter("cot_numero", Model.cot_numero));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("cli_suc", Model.cli_suc));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cot_fecha", Model.cot_fecha));
            parameterList.Add(base.GetParameter("cot_fec_ent", Model.cot_fec_ent));
            parameterList.Add(base.GetParameter("cot_subtotal", Model.cot_subtotal));
            parameterList.Add(base.GetParameter("cot_impuesto", Model.cot_impuesto));
            parameterList.Add(base.GetParameter("cot_total", Model.cot_total));
            parameterList.Add(base.GetParameter("cot_desc", Model.cot_desc));
            parameterList.Add(base.GetParameter("cot_note", Model.cot_note));
            parameterList.Add(base.GetParameter("option", 2));


            base.ExecuteNonQuery("sp_cotizacion", parameterList, CommandType.StoredProcedure);

            //Model.cot_id = (int)IdParamter.Value;

            return Model;
        }



        public cot_enc DeleteCotizacion(cot_enc Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_id", SqlDbType.Int, Model.cot_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_id", Model.cot_tipo));
            parameterList.Add(base.GetParameter("cot_tipo", Model.cot_tipo));
            parameterList.Add(base.GetParameter("cot_numero", Model.cot_numero));
            parameterList.Add(base.GetParameter("cli_id", Model.cli_id));
            parameterList.Add(base.GetParameter("cli_suc", Model.cli_suc));
            parameterList.Add(base.GetParameter("vend_id", Model.vend_id));
            parameterList.Add(base.GetParameter("cot_fecha", Model.cot_fecha));
            parameterList.Add(base.GetParameter("cot_fec_ent", Model.cot_fec_ent));
            parameterList.Add(base.GetParameter("cot_subtotal", Model.cot_subtotal));
            parameterList.Add(base.GetParameter("cot_impuesto", Model.cot_impuesto));
            parameterList.Add(base.GetParameter("cot_total", Model.cot_total));
            parameterList.Add(base.GetParameter("cot_desc", Model.cot_desc));
            parameterList.Add(base.GetParameter("cot_lastupdate", Model.cot_lastupdate));
            parameterList.Add(base.GetParameter("cot_note", Model.cot_note));
            parameterList.Add(base.GetParameter("option", 3));


            base.ExecuteNonQuery("sp_cotizacion", parameterList, CommandType.StoredProcedure);

            //Model.cot_id = (int)IdParamter.Value;

            return Model;
        }

        public List<vcotizaciondet> GetCotizacionesdet(int cot_id)
        {
            List<vcotizaciondet> vpedidosdet = new List<vcotizaciondet>();

            vcotizaciondet vpedidodetItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("cot_id", cot_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_cotizaciondet", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        vpedidodetItem = new vcotizaciondet();
                        vpedidodetItem.cot_det_id = (int)dataReader["cot_det_id"];
                        vpedidodetItem.cot_id = (int)dataReader["cot_id"];
                        vpedidodetItem.codigo = (string)dataReader["codigo"];
                        vpedidodetItem.descripcion = (string)dataReader["desc_prod"];
                        vpedidodetItem.cant = (decimal)dataReader["cant"];

                        if (dataReader["precio"] != DBNull.Value)
                            vpedidodetItem.precio = (decimal)dataReader["precio"];
                        else
                            vpedidodetItem.precio = 0;

                        if (dataReader["desc"] != DBNull.Value)
                            vpedidodetItem.desc = (decimal)dataReader["desc"];
                        else
                            vpedidodetItem.desc = 0;

                        if (dataReader["imp"] != DBNull.Value)
                            vpedidodetItem.imp = (decimal)dataReader["imp"];
                        else
                            vpedidodetItem.imp = 0;

                        if (dataReader["subtotal"] != DBNull.Value)
                            vpedidodetItem.subtotal = (decimal)dataReader["subtotal"];
                        else
                            vpedidodetItem.subtotal = 0;

                        if (dataReader["totalped"] != DBNull.Value)
                            vpedidodetItem.totalped = (decimal)dataReader["totalped"];
                        else
                            vpedidodetItem.totalped = 0;

                        if (dataReader["pesotot"] != DBNull.Value)
                            vpedidodetItem.pesotot = (decimal)dataReader["pesotot"];
                        else
                            vpedidodetItem.pesotot = 0;

                        vpedidosdet.Add(vpedidodetItem);
                    }
                }
            }

            return vpedidosdet;
        }

        public cot_det GetCotizaciondetbyid(int cot_det_id)
        {

            //buscar pedido
            var Model = new cot_det();

            Console.WriteLine("detpedido: " + cot_det_id.ToString());
            Model.cot_det_id = cot_det_id;

            var PedItem = new cot_det();

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_det_id", SqlDbType.Int, Model.cot_det_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_det_id", Model.cot_det_id));
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("prod_id", Model.pro_id));
            parameterList.Add(base.GetParameter("cant", Model.cant));
            parameterList.Add(base.GetParameter("precio", Model.precio));
            parameterList.Add(base.GetParameter("porc_desc", Model.porc_desc));
            parameterList.Add(base.GetParameter("val_desc", Model.val_desc));
            parameterList.Add(base.GetParameter("porc_imp", Model.porc_imp));
            parameterList.Add(base.GetParameter("val_imp", Model.val_imp));
            parameterList.Add(base.GetParameter("subtotal", Model.subtotal));
            parameterList.Add(base.GetParameter("option", 0));


            using (DbDataReader dataReader = base.GetDataReader("sp_cotizaciondet", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        PedItem.cot_det_id = (int)dataReader["COT_DET_ID"];
                        PedItem.cot_id = (int)dataReader["COT_ID"];
                        PedItem.pro_id = (string)dataReader["PROD_ID"];
                        PedItem.cant = (decimal)dataReader["CANT"];

                        if (dataReader["precio"] != DBNull.Value)
                            PedItem.precio = (decimal)dataReader["precio"];
                        else
                            PedItem.precio = 0;

                        if (dataReader["porc_desc"] != DBNull.Value)
                            PedItem.porc_desc = (decimal)dataReader["porc_desc"];
                        else
                            PedItem.porc_desc = 0;

                        if (dataReader["val_desc"] != DBNull.Value)
                            PedItem.val_desc = (decimal)dataReader["val_desc"];
                        else
                            PedItem.val_desc = 0;

                        if (dataReader["porc_imp"] != DBNull.Value)
                            PedItem.porc_imp = Convert.ToDouble(dataReader["porc_imp"]);
                        else
                            PedItem.porc_imp = 0;

                        if (dataReader["val_imp"] != DBNull.Value)
                            PedItem.val_imp = (decimal)dataReader["val_imp"];
                        else
                            PedItem.val_imp = 0;

                        if (dataReader["subtotal"] != DBNull.Value)
                            PedItem.subtotal = (decimal)dataReader["subtotal"];
                        else
                            PedItem.subtotal = 0;

                    }
                }
            }

            Console.WriteLine("detalle encontrado: " + PedItem.subtotal.ToString());
            return PedItem;

        }


        public cot_det CreateCotizaciondet(cot_det Model)
        {
            Console.WriteLine("Guarda detalle");
            Console.WriteLine("cot_id " + Model.cot_id);

            Console.WriteLine("pro_id " + Model.pro_id);

            Console.WriteLine("cant " + Model.cant);

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_det_id", SqlDbType.Int, Model.cot_det_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_det_id", Model.cot_det_id));
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("prod_id", Model.pro_id));
            parameterList.Add(base.GetParameter("cant", Model.cant));
            parameterList.Add(base.GetParameter("precio", Model.precio));
            parameterList.Add(base.GetParameter("porc_desc", Model.porc_desc));
            parameterList.Add(base.GetParameter("val_desc", Model.val_desc));
            parameterList.Add(base.GetParameter("porc_imp", Model.porc_imp));
            parameterList.Add(base.GetParameter("val_imp", Model.val_imp));
            parameterList.Add(base.GetParameter("subtotal", Model.subtotal));
            parameterList.Add(base.GetParameter("option", 1));


            base.ExecuteNonQuery("sp_cotizaciondet", parameterList, CommandType.StoredProcedure);

            Model.cot_det_id = (int)IdParamter.Value;

            return Model;
        }

        public cot_det UpdateCotizaciondet(cot_det Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_det_id", SqlDbType.Int, Model.cot_det_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_det_id", Model.cot_det_id));
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("prod_id", Model.pro_id));
            parameterList.Add(base.GetParameter("cant", Model.cant));
            parameterList.Add(base.GetParameter("precio", Model.precio));
            parameterList.Add(base.GetParameter("porc_desc", Model.porc_desc));
            parameterList.Add(base.GetParameter("val_desc", Model.val_desc));
            parameterList.Add(base.GetParameter("porc_imp", Model.porc_imp));
            parameterList.Add(base.GetParameter("val_imp", Model.val_imp));
            parameterList.Add(base.GetParameter("subtotal", Model.subtotal));
            parameterList.Add(base.GetParameter("option", 2));


            base.ExecuteNonQuery("sp_cotizaciondet", parameterList, CommandType.StoredProcedure);

            //Model.cot_id = (int)IdParamter.Value;

            return Model;
        }



        public cot_det DeleteCotizaciondet(cot_det Model)
        {

            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter IdParamter = base.GetParameterOut("new_cot_det_id", SqlDbType.Int, Model.cot_det_id);
            parameterList.Add(IdParamter);
            parameterList.Add(base.GetParameter("cot_det_id", Model.cot_det_id));
            parameterList.Add(base.GetParameter("cot_id", Model.cot_id));
            parameterList.Add(base.GetParameter("prod_id", Model.pro_id));
            parameterList.Add(base.GetParameter("cant", Model.cant));
            parameterList.Add(base.GetParameter("precio", Model.precio));
            parameterList.Add(base.GetParameter("porc_desc", Model.porc_desc));
            parameterList.Add(base.GetParameter("val_desc", Model.val_desc));
            parameterList.Add(base.GetParameter("porc_imp", Model.porc_imp));
            parameterList.Add(base.GetParameter("val_imp", Model.val_imp));
            parameterList.Add(base.GetParameter("subtotal", Model.subtotal));
            parameterList.Add(base.GetParameter("option", 3));


            base.ExecuteNonQuery("sp_cotizaciondet", parameterList, CommandType.StoredProcedure);

            Model.cot_det_id = (int)IdParamter.Value;

            return Model;
            //Model.cot_id = (int)IdParamter.Value;


        }


    }

}