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
    public class DataUser : BaseDataAccess
    {
        public DataUser(string connectionString) : base(connectionString)
        {
        }


        public user GetUser(string user)
        {

            List<user> lista = GetUsers();
            
            user Item = new user();

            try
            {
                Item = lista.Where(c => c.usuario == user).First();

                Console.WriteLine(Item.usuario);                
            }
            catch (System.Exception)
            {
                throw;
            }

            return Item;
        }

        public List<user> GetUsers()
        {
            List<user> usuarios = new List<user>();

            List<DbParameter> parameterList = new List<DbParameter>();

            //parameterList.Add(base.GetParameter("vend_id", vend_id));

            using (DbDataReader dataReader = base.GetDataReader("Get_users", parameterList, CommandType.StoredProcedure))
            {
                if (dataReader != null && dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {

                        user Item = new user();

                        Item.vend_id = (int)dataReader["VEND_ID"];
                        if (dataReader["usuario"] != DBNull.Value)
                            Item.usuario = (string)dataReader["usuario"];
                        else
                            Item.usuario = "";

                        if (dataReader["clave"] != DBNull.Value)
                            Item.clave = (string)dataReader["clave"];

                        if (dataReader["empresa"] != DBNull.Value)
                            Item.empresa = (string)dataReader["empresa"];
                        else
                            Item.empresa = "";

                        if (dataReader["urlapi"] != DBNull.Value)
                            Item.urlapi = (string)dataReader["urlapi"];
                        else
                            Item.urlapi = "";

                        if (dataReader["md5"] != DBNull.Value)
                            Item.md5 = (string)dataReader["md5"];
                        else
                            Item.md5 = "";

                        if (dataReader["email"] != DBNull.Value)
                            Item.email = (string)dataReader["email"];
                        else
                            Item.email = "";    
                                                        

                        usuarios.Add(Item);
                    }
                }
            }

/*
            foreach (var item in usuarios)
            {
                Console.WriteLine(item.usuario);
            }
 */
            return usuarios;

        }
    }
}