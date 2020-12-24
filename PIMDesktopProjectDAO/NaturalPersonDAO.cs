using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using BD;
using System.Data.SqlClient;
using System.Data;

namespace PIMDesktopProjectDAO
{
    public class NaturalPersonDAO
    {
        public static bool RegisterUser(NaturalPerson person)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Contatos");//ProductID

                foreach (var contact in person.Contatos)
                {
                    dt.Rows.Add(contact.Contact);
                }

                using (SqlConnection con = new Commands().Con())
                {
                    using (SqlCommand cmd = new SqlCommand("RegisterNaturalPerson", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Contatos", dt);
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = person.Nome;
                        cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = person.CPF;
                        cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = person.DataNascimento;
                        cmd.Parameters.Add("@ADMIN", SqlDbType.TinyInt).Value = person.Admin;
                        //cmd.Parameters.Add("@ContatoSecundario", SqlDbType.VarChar).Value = person.ContatoSecundario;
                        cmd.Parameters.Add("@Senha", SqlDbType.VarChar).Value = person.Senha;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = person.Email;
                        cmd.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = person.Rua;
                        cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = person.CEP;
                        cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = person.Bairro;
                        cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = person.Cidade;
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = person.Estado;
                        cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = person.Complemento;
                        cmd.Parameters.Add("@Numero", SqlDbType.VarChar).Value = person.Numero;

                        con.Open();
                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }

            }
            catch
            {
                return false;
            }

        }

        public static List<NaturalPerson> ListAll(string clause = "")
        {
            string query =
               "select p.cd_cpf as 'CPF', p.cd_pessoa_fisica as 'IDPessoaFisica', p.dt_nascimento as 'DataNascimento', p.nm_pessoa_fisica as 'Nome'," +
               "u.cd_usuario as 'IDUsuario', u.ds_senha as 'Senha', u.ds_email as 'Email', u.ds_frase as 'FraseSecreta', u.ds_admin as 'Admin'," +
               "e.cd_cep as 'CEP', e.cd_endereco as 'IDEndereco', e.ds_logradouro as 'Rua', e.ds_bairro as 'Bairro', e.ds_complemento as 'Complemento', " +
               "e.ds_cidade as 'Cidade', e.ds_estado as 'Estado', e.ds_numero as 'Numero' " +
               "from tb_pessoa_fisica as p inner join tb_usuario as u on p.cd_usuario = u.cd_usuario inner join tb_endereco as e on " +
               $"u.cd_endereco = e.cd_endereco {clause};";

            return GetAll(query);
        }

        private static List<NaturalPerson> GetAll(string query)
        {
            Commands bd = new Commands();

            var User = new List<NaturalPerson>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var this_user = new NaturalPerson
                {
                    UserID = datareader["IDUsuario"].ToString(),
                    NaturalPersonID = datareader["IDPessoaFisica"].ToString(),
                    AddressID = datareader["IDEndereco"].ToString(),
                    Nome = datareader["Nome"].ToString(),
                    CPF = datareader["CPF"].ToString(),
                    DataNascimento = (DateTime)datareader["DataNascimento"],
                    Senha = datareader["Senha"].ToString(),
                    Email = datareader["Email"].ToString(),
                    Rua = datareader["Rua"].ToString(),
                    CEP = datareader["CEP"].ToString(),
                    Bairro = datareader["Bairro"].ToString(),
                    Cidade = datareader["Cidade"].ToString(),
                    Estado = datareader["Estado"].ToString(),
                    Complemento = datareader["Complemento"].ToString(),
                    Numero = datareader["Numero"].ToString()
                };

                User.Add(this_user);
            }
            datareader.Close();

            return User;
        }

        /// <summary>
        /// UPDATE METHOD
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool UpdateUser(NaturalPerson person)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Contatos");
                dt.Columns.Add("ID");

                foreach (var contact in person.Contatos)
                {
                    dt.Rows.Add(contact.Contact, contact.ID);
                }

                using (SqlConnection con = new Commands().Con())
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateNaturalPerson", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Contatos", dt);
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = person.Nome;
                        cmd.Parameters.Add("@CPF", SqlDbType.VarChar).Value = person.CPF;
                        cmd.Parameters.Add("@DataNascimento", SqlDbType.DateTime).Value = person.DataNascimento;
                        //cmd.Parameters.Add("@ADMIN", SqlDbType.TinyInt).Value = person.Admin;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = person.Email;
                        cmd.Parameters.Add("@Logradouro", SqlDbType.VarChar).Value = person.Rua;
                        cmd.Parameters.Add("@CEP", SqlDbType.VarChar).Value = person.CEP;
                        cmd.Parameters.Add("@Bairro", SqlDbType.VarChar).Value = person.Bairro;
                        cmd.Parameters.Add("@Cidade", SqlDbType.VarChar).Value = person.Cidade;
                        cmd.Parameters.Add("@Estado", SqlDbType.VarChar).Value = person.Estado;
                        cmd.Parameters.Add("@Complemento", SqlDbType.VarChar).Value = person.Complemento;
                        cmd.Parameters.Add("@Numero", SqlDbType.VarChar).Value = person.Numero;

                        con.Open();
                        return cmd.ExecuteNonQuery() > 0 ? true : false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// UPDATE PASS
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public static bool UpdatePass(NaturalPerson person)
        {
            string query = $"update u set u.ds_senha = '{person.Senha}' from tb_usuario as u inner join tb_pessoa_fisica " +
                $"on tb_pessoa_fisica.cd_usuario = u.cd_usuario where tb_pessoa_fisica.cd_cpf = '{person.CPF}';";

            Commands bd = new Commands();

            string selectProducts = query;

            return bd.CommandExecute(selectProducts);
        }
    }
}
