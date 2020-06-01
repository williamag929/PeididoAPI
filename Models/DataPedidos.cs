using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace PedidoApi.Models {
    public class DataPedidos : BaseDataAccess {
        public DataPedidos (string connectionString) : base (connectionString) { }

        [HttpGet]
        public List<vpedido> GetPedidos (int vend_id) {
            List<vpedido> vpedidos = new List<vpedido> ();
            vpedido vpedidoItem = null;

            List<DbParameter> parameterList = new List<DbParameter> ();

            parameterList.Add (base.GetParameter ("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader ("Get_Pedidos", parameterList, CommandType.StoredProcedure)) {
                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        vpedidoItem = new vpedido ();
                        vpedidoItem.ped_id = (int) dataReader["PED_ID"];
                        if (dataReader["PED_TIPO"] != DBNull.Value)
                            vpedidoItem.ped_tipo = (string) dataReader["PED_TIPO"];
                        if (dataReader["PED_NUMERO"] != DBNull.Value)
                            vpedidoItem.ped_numero = (int) dataReader["PED_NUMERO"];
                        if (dataReader["CLI_ID"] != DBNull.Value)
                            vpedidoItem.cli_id = (int) dataReader["CLI_ID"];
                        if (dataReader["CLI_NOMBRE"] != DBNull.Value)
                            vpedidoItem.cli_nombre = (string) dataReader["CLI_NOMBRE"];
                        if (dataReader["CLI_SUC"] != DBNull.Value)
                            vpedidoItem.cli_suc = (int) dataReader["CLI_SUC"];
                        if (dataReader["CLI_DIRECCION"] != DBNull.Value)
                            vpedidoItem.cli_direccion = (string) dataReader["CLI_DIRECCION"];
                        if (dataReader["VEND_ID"] != DBNull.Value)
                            vpedidoItem.vend_id = (int) dataReader["VEND_ID"];
                        if (dataReader["VEND_NOMB"] != DBNull.Value)
                            vpedidoItem.vend_nomb = (string) dataReader["VEND_NOMB"];
                        if (dataReader["PED_FECHA"] != DBNull.Value)
                            vpedidoItem.ped_fecha = (DateTime) dataReader["PED_FECHA"];
                        if (dataReader["PED_FEC_ENT"] != DBNull.Value)
                            vpedidoItem.ped_fec_ent = (DateTime) dataReader["PED_FEC_ENT"];

                        if (dataReader["PED_DESC"] != DBNull.Value)
                            vpedidoItem.ped_desc = (decimal) dataReader["PED_DESC"];
                        else
                            vpedidoItem.ped_desc = 0;

                        if (dataReader["DESCUENTO"] != DBNull.Value)
                            vpedidoItem.descuento = (decimal) dataReader["DESCUENTO"];
                        else
                            vpedidoItem.descuento = 0;

                        if (dataReader["PED_SUBTOTAL"] != DBNull.Value)
                            vpedidoItem.ped_subtotal = (decimal) dataReader["PED_SUBTOTAL"];
                        else
                            vpedidoItem.ped_subtotal = 0;

                        if (dataReader["PED_IMPUESTO"] != DBNull.Value)
                            vpedidoItem.ped_impuesto = (decimal) dataReader["PED_IMPUESTO"];
                        else
                            vpedidoItem.ped_impuesto = 0;

                        if (dataReader["PED_TOTAL"] != DBNull.Value)
                            vpedidoItem.ped_total = (decimal) dataReader["PED_TOTAL"];
                        else
                            vpedidoItem.ped_total = 0;

                        if (dataReader["CLI_CIUDAD"] != DBNull.Value)
                            vpedidoItem.cli_ciudad = (String) dataReader["CLI_CIUDAD"];
                        else
                            vpedidoItem.cli_ciudad = "";

                        if (dataReader["VEND_ZONA"] != DBNull.Value)
                            vpedidoItem.vend_zona = (string) dataReader["VEND_ZONA"];
                        else
                            vpedidoItem.vend_zona = "";

                        if (dataReader["FORMAPAGO"] != DBNull.Value)
                            vpedidoItem.formapago = (string) dataReader["FORMAPAGO"];
                        else
                            vpedidoItem.formapago = "";

                        if (dataReader["PLAZO"] != DBNull.Value)
                            vpedidoItem.plazo = (int) dataReader["PLAZO"];
                        else
                            vpedidoItem.plazo = 0;

                        vpedidoItem.ped_procesado = (bool) dataReader["PED_PROCESADO"];

                        if (dataReader["PED_CLOSED"] != DBNull.Value)
                            vpedidoItem.ped_closed = (bool) dataReader["PED_CLOSED"];
                        else
                            vpedidoItem.ped_closed = false;

                        if (dataReader["PED_NOTE"] != DBNull.Value)
                            vpedidoItem.ped_note = (string) dataReader["PED_NOTE"];
                        else
                            vpedidoItem.ped_note = "";

                        if (dataReader["DIRECCIONENTR"] != DBNull.Value)
                            vpedidoItem.direccionentr = (string) dataReader["DIRECCIONENTR"];
                        else
                            vpedidoItem.direccionentr = "";

                        //if (dataReader["PESO"] != DBNull.Value)  
                        //    productoItem.peso = (decimal)dataReader["PESO"];
                        //else
                        //    productoItem.peso = 0;

                        vpedidos.Add (vpedidoItem);

                        //Console.WriteLine(vpedidoItem.ped_id);
                    }
                }
            }
            return vpedidos;
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

        public List<mediopago> Getmediopagos () {
            var Listado = new List<mediopago> ();
            
            Console.WriteLine ("Leyendo");
            List<DbParameter> parameterList = new List<DbParameter> ();
            //parameterList.Add(base.GetParameter("option", 1));
            using (DbDataReader dataReader = base.GetDataReader ("Get_Mediopago", parameterList, CommandType.StoredProcedure)) {
                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        var Model = new mediopago ();
                        Model.mediopagoid = (int) dataReader["mediopagoid"];
                        Model.concepto = (string) dataReader["concepto"];
                        Model.descripcion = (string) dataReader["descripcion"];
                        Model.tipopago = (string) dataReader["tipopago"];
                        Model.aplicadescuento = (bool) dataReader["aplicadescuento"];
                        Model.aplicaplazo = (bool) dataReader["aplicaplazo"];
                        Model.plazos = (string) dataReader["plazos"];
                        Model.descuentos = (string) dataReader["descuentos"];

                        Listado.Add(Model);
                    }
                }
            }
            return Listado;
        }


        ///traer pedido por id
        public ped_enc GetPedidobyId (int ped_id) {
            //Console.WriteLine(ped_id.ToString());
            var Model = new ped_enc ();
            List<DbParameter> parameterList = new List<DbParameter> ();
            parameterList.Add (base.GetParameter ("option", 0));
            parameterList.Add (base.GetParameter ("ped_id", ped_id));
            parameterList.Add (base.GetParameter ("ped_tipo", null));
            parameterList.Add (base.GetParameter ("ped_numero", null));
            parameterList.Add (base.GetParameter ("cli_id", null));
            parameterList.Add (base.GetParameter ("cli_suc", null));
            parameterList.Add (base.GetParameter ("vend_id", null));
            parameterList.Add (base.GetParameter ("ped_fecha", null));
            parameterList.Add (base.GetParameter ("ped_fec_ent", null));
            parameterList.Add (base.GetParameter ("ped_subtotal", null));
            parameterList.Add (base.GetParameter ("ped_impuesto", null));
            parameterList.Add (base.GetParameter ("ped_total", null));
            parameterList.Add (base.GetParameter ("ped_desc", null));
            parameterList.Add (base.GetParameter ("descuento", null));
            parameterList.Add (base.GetParameter ("ped_procesado", null));
            parameterList.Add (base.GetParameter ("ped_closed", null));
            parameterList.Add (base.GetParameter ("ped_note", null));
            parameterList.Add (base.GetParameter ("formapago", null));
            parameterList.Add (base.GetParameter ("plazo", null));
            parameterList.Add (base.GetParameter ("direccionentr", null));

            parameterList.Add (base.GetParameter ("new_ped_id", null));

            var vpedidoItem = new ped_enc ();

            using (DbDataReader dataReader = base.GetDataReader ("sp_pedido", parameterList, CommandType.StoredProcedure)) {

                //Console.WriteLine("Leyendo");

                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        vpedidoItem = new ped_enc ();
                        vpedidoItem.ped_id = (int) dataReader["PED_ID"];
                        vpedidoItem.ped_tipo = (string) dataReader["PED_TIPO"];
                        vpedidoItem.ped_numero = (int) dataReader["PED_NUMERO"];
                        vpedidoItem.cli_id = (int) dataReader["CLI_ID"];
                        vpedidoItem.cli_suc = (int) dataReader["CLI_SUC"];
                        vpedidoItem.vend_id = (int) dataReader["VEND_ID"];
                        vpedidoItem.ped_fecha = (DateTime) dataReader["PED_FECHA"];

                        if (dataReader["PED_FECHA"] != DBNull.Value)
                            vpedidoItem.ped_fecha = (DateTime) dataReader["PED_FECHA"];

                        if (dataReader["PED_FEC_ENT"] != DBNull.Value)
                            vpedidoItem.ped_fec_ent = (DateTime) dataReader["PED_FEC_ENT"];

                        if (dataReader["PED_DESC"] != DBNull.Value)
                            vpedidoItem.ped_desc = (decimal) dataReader["PED_DESC"];
                        else
                            vpedidoItem.ped_desc = 0;

                        if (dataReader["DESCUENTO"] != DBNull.Value)
                            vpedidoItem.descuento = (decimal) dataReader["DESCUENTO"];
                        else
                            vpedidoItem.descuento = 0;

                        if (dataReader["PED_SUBTOTAL"] != DBNull.Value)
                            vpedidoItem.ped_subtotal = (decimal) dataReader["PED_SUBTOTAL"];
                        else
                            vpedidoItem.ped_subtotal = 0;

                        if (dataReader["PED_IMPUESTO"] != DBNull.Value)
                            vpedidoItem.ped_impuesto = (decimal) dataReader["PED_IMPUESTO"];
                        else
                            vpedidoItem.ped_impuesto = 0;

                        if (dataReader["PED_TOTAL"] != DBNull.Value)
                            vpedidoItem.ped_total = (decimal) dataReader["PED_TOTAL"];
                        else
                            vpedidoItem.ped_total = 0;

                        vpedidoItem.ped_procesado = (bool) dataReader["PED_PROCESADO"];

                        if (dataReader["PED_CLOSED"] != DBNull.Value)
                            vpedidoItem.ped_closed = (bool) dataReader["PED_CLOSED"];
                        else
                            vpedidoItem.ped_closed = false;

                        if (dataReader["PED_NOTE"] != DBNull.Value)
                            vpedidoItem.ped_note = (string) dataReader["PED_NOTE"];
                        else
                            vpedidoItem.ped_note = "";

                        if (dataReader["FORMAPAGO"] != DBNull.Value)
                            vpedidoItem.formapago = (string) dataReader["FORMAPAGO"];
                        else
                            vpedidoItem.formapago = "";

                        if (dataReader["PLAZO"] != DBNull.Value)
                            vpedidoItem.plazo = (int) dataReader["PLAZO"];
                        else
                            vpedidoItem.plazo = 0;

                        if (dataReader["DIRECCIONENTR"] != DBNull.Value)
                            vpedidoItem.direccionentr = (string) dataReader["DIRECCIONENTR"];
                        else
                            vpedidoItem.direccionentr = "";

                        //si el cliente no maneja peso
                        try {

                            if (dataReader["PESO"] != DBNull.Value)
                                vpedidoItem.peso = (decimal) dataReader["PESO"];
                            else
                                vpedidoItem.peso = 0;
                        } catch { }

                    }
                }
            }
            return vpedidoItem;

        }

        ///Crea encabezado Pedido
        public ped_enc CreatePedido (ped_enc Model) {

            Console.WriteLine ("Crea Pedido " + Model.cli_id);

            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_id", SqlDbType.Int, Model.ped_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("ped_tipo", Model.ped_tipo));
            parameterList.Add (base.GetParameter ("ped_numero", Model.ped_numero));
            parameterList.Add (base.GetParameter ("cli_id", Model.cli_id));
            parameterList.Add (base.GetParameter ("cli_suc", Model.cli_suc));
            parameterList.Add (base.GetParameter ("vend_id", Model.vend_id));
            parameterList.Add (base.GetParameter ("ped_fecha", Model.ped_fecha));
            parameterList.Add (base.GetParameter ("ped_fec_ent", Model.ped_fec_ent));
            parameterList.Add (base.GetParameter ("ped_subtotal", Model.ped_subtotal));
            parameterList.Add (base.GetParameter ("ped_impuesto", Model.ped_impuesto));
            parameterList.Add (base.GetParameter ("ped_total", Model.ped_total));
            parameterList.Add (base.GetParameter ("ped_desc", Model.ped_desc));
            parameterList.Add (base.GetParameter ("descuento", Model.descuento));
            parameterList.Add (base.GetParameter ("ped_procesado", 0));
            parameterList.Add (base.GetParameter ("ped_closed", 0));
            parameterList.Add (base.GetParameter ("ped_note", Model.ped_note));
            parameterList.Add (base.GetParameter ("formapago", Model.formapago));
            parameterList.Add (base.GetParameter ("plazo", Model.plazo));
            parameterList.Add (base.GetParameter ("direccionentr", Model.direccionentr));
            parameterList.Add (base.GetParameter ("option", 1));

            base.ExecuteNonQuery ("sp_pedido", parameterList, CommandType.StoredProcedure);

            Model.ped_id = (int) IdParamter.Value;

            return Model;
        }

        public ped_enc UpdatePedido (ped_enc Model) {

            Console.WriteLine ("Actualiza Pedido " + Model.ped_id);

            Console.WriteLine ("pedido cerado " + Model.ped_closed);

            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_id", SqlDbType.Int, Model.ped_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("ped_tipo", Model.ped_tipo));
            parameterList.Add (base.GetParameter ("ped_numero", Model.ped_numero));
            parameterList.Add (base.GetParameter ("cli_id", Model.cli_id));
            parameterList.Add (base.GetParameter ("cli_suc", Model.cli_suc));
            parameterList.Add (base.GetParameter ("vend_id", Model.vend_id));
            parameterList.Add (base.GetParameter ("ped_fecha", Model.ped_fecha));
            parameterList.Add (base.GetParameter ("ped_fec_ent", Model.ped_fec_ent));
            parameterList.Add (base.GetParameter ("ped_subtotal", Model.ped_subtotal));
            parameterList.Add (base.GetParameter ("ped_impuesto", Model.ped_impuesto));
            parameterList.Add (base.GetParameter ("ped_total", Model.ped_total));
            parameterList.Add (base.GetParameter ("descuento", Model.descuento));
            parameterList.Add (base.GetParameter ("ped_desc", Model.ped_desc));
            parameterList.Add (base.GetParameter ("ped_procesado", Model.ped_procesado));
            parameterList.Add (base.GetParameter ("ped_closed", Model.ped_closed));
            parameterList.Add (base.GetParameter ("ped_note", Model.ped_note));
            parameterList.Add (base.GetParameter ("formapago", Model.formapago));
            parameterList.Add (base.GetParameter ("plazo", Model.plazo));
            parameterList.Add (base.GetParameter ("direccionentr", Model.direccionentr));
            parameterList.Add (base.GetParameter ("option", 2));

            base.ExecuteNonQuery ("sp_pedido", parameterList, CommandType.StoredProcedure);

            //Model.ped_id = (int)IdParamter.Value;

            return Model;
        }

        public ped_enc DeletePedido (ped_enc Model) {
            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_id", SqlDbType.Int, Model.ped_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_tipo));
            parameterList.Add (base.GetParameter ("ped_tipo", Model.ped_tipo));
            parameterList.Add (base.GetParameter ("ped_numero", Model.ped_numero));
            parameterList.Add (base.GetParameter ("cli_id", Model.cli_id));
            parameterList.Add (base.GetParameter ("cli_suc", Model.cli_suc));
            parameterList.Add (base.GetParameter ("vend_id", Model.vend_id));
            parameterList.Add (base.GetParameter ("ped_fecha", Model.ped_fecha));
            parameterList.Add (base.GetParameter ("ped_fec_ent", Model.ped_fec_ent));
            parameterList.Add (base.GetParameter ("ped_subtotal", Model.ped_subtotal));
            parameterList.Add (base.GetParameter ("ped_impuesto", Model.ped_impuesto));
            parameterList.Add (base.GetParameter ("ped_total", Model.ped_total));
            parameterList.Add (base.GetParameter ("ped_desc", Model.ped_desc));
            parameterList.Add (base.GetParameter ("ped_proceesado", Model.ped_procesado));
            parameterList.Add (base.GetParameter ("ped_lastupdate", Model.ped_lastupdate));
            parameterList.Add (base.GetParameter ("ped_closed", Model.ped_closed));
            parameterList.Add (base.GetParameter ("ped_note", Model.ped_note));
            parameterList.Add (base.GetParameter ("descuento", Model.descuento));
            parameterList.Add (base.GetParameter ("formapago", Model.formapago));
            parameterList.Add (base.GetParameter ("plazo", Model.plazo));
            parameterList.Add (base.GetParameter ("direccionentr", Model.direccionentr));
            parameterList.Add (base.GetParameter ("option", 3));

            base.ExecuteNonQuery ("sp_pedido", parameterList, CommandType.StoredProcedure);

            //Model.ped_id = (int)IdParamter.Value;

            return Model;
        }

        public List<vpedidodet> GetPedidosdet (int ped_id) {
            List<vpedidodet> vpedidosdet = new List<vpedidodet> ();

            vpedidodet vpedidodetItem = null;

            List<DbParameter> parameterList = new List<DbParameter> ();

            parameterList.Add (base.GetParameter ("ped_id", ped_id));

            using (DbDataReader dataReader = base.GetDataReader ("Get_pedidosdet", parameterList, CommandType.StoredProcedure)) {
                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {
                        vpedidodetItem = new vpedidodet ();
                        vpedidodetItem.ped_det_id = (int) dataReader["ped_det_id"];
                        vpedidodetItem.ped_id = (int) dataReader["ped_id"];
                        vpedidodetItem.codigo = (string) dataReader["codigo"];
                        vpedidodetItem.descripcion = (string) dataReader["desc_prod"];
                        vpedidodetItem.cant = (decimal) dataReader["cant"];

                        if (dataReader["precio"] != DBNull.Value)
                            vpedidodetItem.precio = (decimal) dataReader["precio"];
                        else
                            vpedidodetItem.precio = 0;

                        if (dataReader["desc"] != DBNull.Value)
                            vpedidodetItem.desc = (decimal) dataReader["desc"];
                        else
                            vpedidodetItem.desc = 0;

                        if (dataReader["imp"] != DBNull.Value)
                            vpedidodetItem.imp = (decimal) dataReader["imp"];
                        else
                            vpedidodetItem.imp = 0;

                        if (dataReader["subtotal"] != DBNull.Value)
                            vpedidodetItem.subtotal = (decimal) dataReader["subtotal"];
                        else
                            vpedidodetItem.subtotal = 0;

                        if (dataReader["totalped"] != DBNull.Value)
                            vpedidodetItem.totalped = (decimal) dataReader["totalped"];
                        else
                            vpedidodetItem.totalped = 0;

                        if (dataReader["pesotot"] != DBNull.Value)
                            vpedidodetItem.pesotot = (decimal) dataReader["pesotot"];
                        else
                            vpedidodetItem.pesotot = 0;

                        vpedidosdet.Add (vpedidodetItem);
                    }
                }
            }

            return vpedidosdet;
        }

        public ped_det GetPedidodetbyid (int ped_det_id) {

            //buscar pedido
            var Model = new ped_det ();

            Console.WriteLine ("detpedido: " + ped_det_id.ToString ());
            Model.ped_det_id = ped_det_id;

            var PedItem = new ped_det ();

            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_det_id", SqlDbType.Int, Model.ped_det_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_det_id", Model.ped_det_id));
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("prod_id", Model.pro_id));
            parameterList.Add (base.GetParameter ("cant", Model.cant));
            parameterList.Add (base.GetParameter ("precio", Model.precio));
            parameterList.Add (base.GetParameter ("porc_desc", Model.porc_desc));
            parameterList.Add (base.GetParameter ("val_desc", Model.val_desc));
            parameterList.Add (base.GetParameter ("porc_imp", Model.porc_imp));
            parameterList.Add (base.GetParameter ("val_imp", Model.val_imp));
            parameterList.Add (base.GetParameter ("subtotal", Model.subtotal));
            parameterList.Add (base.GetParameter ("option", 0));

            using (DbDataReader dataReader = base.GetDataReader ("sp_pedidodet", parameterList, CommandType.StoredProcedure)) {
                if (dataReader != null && dataReader.HasRows) {
                    while (dataReader.Read ()) {

                        PedItem.ped_det_id = (int) dataReader["PED_DET_ID"];
                        PedItem.ped_id = (int) dataReader["PED_ID"];
                        PedItem.pro_id = (string) dataReader["PROD_ID"];
                        PedItem.cant = (decimal) dataReader["CANT"];

                        if (dataReader["precio"] != DBNull.Value)
                            PedItem.precio = (decimal) dataReader["precio"];
                        else
                            PedItem.precio = 0;

                        if (dataReader["porc_desc"] != DBNull.Value)
                            PedItem.porc_desc = (decimal) dataReader["porc_desc"];
                        else
                            PedItem.porc_desc = 0;

                        if (dataReader["val_desc"] != DBNull.Value)
                            PedItem.val_desc = (decimal) dataReader["val_desc"];
                        else
                            PedItem.val_desc = 0;

                        if (dataReader["porc_imp"] != DBNull.Value)
                            PedItem.porc_imp = Convert.ToDouble (dataReader["porc_imp"]);
                        else
                            PedItem.porc_imp = 0;

                        if (dataReader["val_imp"] != DBNull.Value)
                            PedItem.val_imp = (decimal) dataReader["val_imp"];
                        else
                            PedItem.val_imp = 0;

                        if (dataReader["subtotal"] != DBNull.Value)
                            PedItem.subtotal = (decimal) dataReader["subtotal"];
                        else
                            PedItem.subtotal = 0;

                    }
                }
            }

            Console.WriteLine ("detalle encontrado: " + PedItem.subtotal.ToString ());
            return PedItem;

        }

        public ped_det CreatePedidodet (ped_det Model) {
            Console.WriteLine ("Guarda detalle");
            Console.WriteLine ("ped_id " + Model.ped_id);

            Console.WriteLine ("pro_id " + Model.pro_id);

            Console.WriteLine ("cant " + Model.cant);

            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_det_id", SqlDbType.Int, Model.ped_det_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_det_id", Model.ped_det_id));
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("prod_id", Model.pro_id));
            parameterList.Add (base.GetParameter ("cant", Model.cant));
            parameterList.Add (base.GetParameter ("precio", Model.precio));
            parameterList.Add (base.GetParameter ("porc_desc", Model.porc_desc));
            parameterList.Add (base.GetParameter ("val_desc", Model.val_desc));
            parameterList.Add (base.GetParameter ("porc_imp", Model.porc_imp));
            parameterList.Add (base.GetParameter ("val_imp", Model.val_imp));
            parameterList.Add (base.GetParameter ("subtotal", Model.subtotal));
            parameterList.Add (base.GetParameter ("option", 1));

            base.ExecuteNonQuery ("sp_pedidodet", parameterList, CommandType.StoredProcedure);

            Model.ped_det_id = (int) IdParamter.Value;

            return Model;
        }

        public ped_det UpdatePedidodet (ped_det Model) {
            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_det_id", SqlDbType.Int, Model.ped_det_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_det_id", Model.ped_det_id));
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("prod_id", Model.pro_id));
            parameterList.Add (base.GetParameter ("cant", Model.cant));
            parameterList.Add (base.GetParameter ("precio", Model.precio));
            parameterList.Add (base.GetParameter ("porc_desc", Model.porc_desc));
            parameterList.Add (base.GetParameter ("val_desc", Model.val_desc));
            parameterList.Add (base.GetParameter ("porc_imp", Model.porc_imp));
            parameterList.Add (base.GetParameter ("val_imp", Model.val_imp));
            parameterList.Add (base.GetParameter ("subtotal", Model.subtotal));
            parameterList.Add (base.GetParameter ("option", 2));

            base.ExecuteNonQuery ("sp_pedidodet", parameterList, CommandType.StoredProcedure);

            //Model.ped_id = (int)IdParamter.Value;

            return Model;
        }

        public ped_det DeletePedidodet (ped_det Model) {

            List<DbParameter> parameterList = new List<DbParameter> ();

            DbParameter IdParamter = base.GetParameterOut ("new_ped_det_id", SqlDbType.Int, Model.ped_det_id);
            parameterList.Add (IdParamter);
            parameterList.Add (base.GetParameter ("ped_det_id", Model.ped_det_id));
            parameterList.Add (base.GetParameter ("ped_id", Model.ped_id));
            parameterList.Add (base.GetParameter ("prod_id", Model.pro_id));
            parameterList.Add (base.GetParameter ("cant", Model.cant));
            parameterList.Add (base.GetParameter ("precio", Model.precio));
            parameterList.Add (base.GetParameter ("porc_desc", Model.porc_desc));
            parameterList.Add (base.GetParameter ("val_desc", Model.val_desc));
            parameterList.Add (base.GetParameter ("porc_imp", Model.porc_imp));
            parameterList.Add (base.GetParameter ("val_imp", Model.val_imp));
            parameterList.Add (base.GetParameter ("subtotal", Model.subtotal));
            parameterList.Add (base.GetParameter ("option", 3));

            base.ExecuteNonQuery ("sp_pedidodet", parameterList, CommandType.StoredProcedure);

            Model.ped_det_id = (int) IdParamter.Value;

            return Model;
            //Model.ped_id = (int)IdParamter.Value;

        }

    }

}