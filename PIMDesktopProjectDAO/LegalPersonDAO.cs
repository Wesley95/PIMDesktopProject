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
    public class LegalPersonDAO
    {
        public static bool RegisterUser(LegalPerson person)
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
                    using (SqlCommand cmd = new SqlCommand("RegisterLegalPerson", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Contatos", dt);
                        cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = person.NomeFantasia;
                        cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = person.CNPJ;
                        cmd.Parameters.Add("@DataFundacao", SqlDbType.DateTime).Value = person.DataFundacao;
                        //cmd.Parameters.Add("@Contato", SqlDbType.VarChar).Value = person.Contato;
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

        public static List<LegalPerson> ListAll(string clause = "")
        {
            string query =
                "select p.cd_cnpj as 'CNPJ', p.cd_pessoa_juridica as 'IDPessoaJuridica', p.dt_fundacao as 'DataFundacao', p.nm_fantasia as 'NomeFantasia'," +
                "u.cd_usuario as 'IDUsuario', u.ds_senha as 'Senha', u.ds_email as 'Email', u.ds_frase as 'FraseSecreta', u.ds_admin as 'Admin'," +
                "e.cd_cep as 'CEP', e.cd_endereco as 'IDEndereco', e.ds_logradouro as 'Rua', e.ds_bairro as 'Bairro', e.ds_complemento as 'Complemento', " +
                "e.ds_cidade as 'Cidade', e.ds_estado as 'Estado', e.ds_numero as 'Numero' " +
                "from tb_pessoa_juridica as p inner join tb_usuario as u on p.cd_usuario = u.cd_usuario inner join tb_endereco as e on " +
                $"u.cd_endereco = e.cd_endereco {clause}";

            Commands bd = new Commands();

            var User = new List<LegalPerson>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var this_user = new LegalPerson
                {
                    UserID = datareader["IDUsuario"].ToString(),
                    LegalPersonID = datareader["IDPessoaJuridica"].ToString(),
                    AddressID = datareader["IDEndereco"].ToString(),
                    NomeFantasia = datareader["NomeFantasia"].ToString(),
                    CNPJ = datareader["CNPJ"].ToString(),
                    DataFundacao = (DateTime)datareader["DataFundacao"],
                    //Contato = "",
                    //ContatoSecundario = "",
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
        public static bool UpdateUser(LegalPerson person)
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
                    using (SqlCommand cmd = new SqlCommand("UpdateLegalPerson", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Contatos", dt);
                        cmd.Parameters.Add("@NomeFantasia", SqlDbType.VarChar).Value = person.NomeFantasia;
                        cmd.Parameters.Add("@CNPJ", SqlDbType.VarChar).Value = person.CNPJ;
                        cmd.Parameters.Add("@DataFundacao", SqlDbType.DateTime).Value = person.DataFundacao;
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
        public static bool UpdatePass(LegalPerson person)
        {
            string query = $"update u set u.ds_senha = '{person.Senha}' from tb_usuario as u inner join tb_pessoa_juridica " +
                $"on tb_pessoa_juridica.cd_usuario = u.cd_usuario where tb_pessoa_juridica.cd_cnpj = '{person.CNPJ}';";

            Commands bd = new Commands();

            string selectProducts = query;

            return bd.CommandExecute(selectProducts);
        }
    }
}
