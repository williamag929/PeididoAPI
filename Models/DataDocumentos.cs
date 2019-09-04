using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace PedidoApi.Models
{
    public class DataDocumentos : BaseDataAccess
    {
        public DataDocumentos(string connectionString) : base(connectionString)
        {
        }

        public List<documento> GetDocumentos(string clase)
        {
            List<documento> Documentos = new List<documento>();
            documento DocumentoItem = null;

            List<DbParameter> parameterList = new List<DbParameter>();

            parameterList.Add(base.GetParameter("clase", clase));

            using (DbDataReader dataReader = base.GetDataReader("Get_Documentos", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        DocumentoItem  = new documento();
                        DocumentoItem.documentoid = (int)dataReader["documentoid"];
                        DocumentoItem.clase = (string)dataReader["clase"];
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