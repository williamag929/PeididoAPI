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
    public class DataDocumentos : BaseDataAccess
    {
        public DataDocumentos(string connectionString) : base(connectionString)
        {
        }

        public List<documento> GetDocumentos()
        {
            List<documento> Documentos = new List<documento>();
            documento DocumentoItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            //parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_Clientes", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DocumentoItem  = new documento();
                        DocumentoItem.documentoid = (int)dataReader["documentoid"];
                        DocumentoItem.tipo = (string)dataReader["tipo"];
                        DocumentoItem.descripcion = (string)dataReader["descripcion"];
                        DocumentoItem.numero = (int)dataReader["numero"];

                        Documentos.Add(DocumentoItem);
                    }
                }
            }
            return Documentos;
        }

        public documento UpdateDocumento(documento Model)
        {
            List<DbParameter> parameterList = new List<DbParameter>();

            DbParameter numeroParameter = base.GetParameterOut("numero", SqlDbType.Int, Model.numero);
            parameterList.Add(numeroParameter);
            parameterList.Add(base.GetParameter("documentoid", Model.documentoid));

            base.ExecuteNonQuery("documento_update", parameterList, CommandType.StoredProcedure);

            Model.numero = (int)numeroParameter.Value;

            return Model;
        }
    }

}