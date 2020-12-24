using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using BD;
using System.Data.SqlClient;

namespace PIMDesktopProjectDAO
{
    public class UserDAO
    {
        public bool Login()
        {
            return true;
        }

        public static List<UserDTO> ListAll(string clause)
        {
            string query =
                $"select cd_usuario as 'IDUsuario', ds_senha as 'Senha', ds_email as 'Email', ds_frase as 'Frase', " +
                $"ds_admin as 'Admin' from tb_usuario {clause}";

            return GetAll(query);
        }

        private static List<UserDTO> GetAll(string query)
        {
            Commands bd = new Commands();

            var User = new List<UserDTO>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var this_user = new UserDTO
                {
                    UserID = datareader["IDUsuario"].ToString(),
                    Senha = datareader["Senha"].ToString(),
                    Email = datareader["Email"].ToString(),
                    PalavraSecreta = datareader["Frase"].ToString(),
                    Admin = (datareader["Admin"].ToString() == "0") ? false : true
                };

                User.Add(this_user);
            }
            datareader.Close();

            return User;
        }

        public static List<Contacts>ListContacts(string clause)
        {
            string query = $"select ds_contato as 'Contato', cd_contato as 'IDContato' from tb_contato {clause}";

            return GetContacts(query);
        }

        private static List<Contacts> GetContacts(string query)
        {
            Commands bd = new Commands();

            var User = new List<Contacts>();

            string selectContacts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectContacts);

            while (datareader.Read())
            {
                var this_user = new Contacts
                {
                    ID= datareader["IDContato"].ToString(),
                    Contact = datareader["Contato"].ToString()
                };

                User.Add(this_user);
            }
            datareader.Close();

            return User;
        }

        public static bool UpdatePassword(string id, string pass)
        {
            try
            {
                string query = $"UPDATE tb_usuario SET ds_senha = '{pass}' WHERE cd_usuario = '{id}'";

                new Commands().ExecuteCommand(query);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
