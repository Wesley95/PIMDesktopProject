using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using BD;

namespace PIMDesktopProjectDAO
{
    public class PhraseDAO
    {
        public static bool Insert(PhraseDTO person)
        {
            try
            {
                string query = "INSERT INTO tb_frase(ds_frase, dt_frase_alterada,cd_usuario) " +
                    $"VALUES('{person.Frase}','{person.DataAlteracao}','{person.UserId}')";

                new Commands().ExecuteCommand(query);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(PhraseDTO person)
        {
            try
            {
                string query = $"UPDATE tb_frase SET ds_frase = '{person.Frase}', " +
                    $"dt_frase_alterada = '{person.DataAlteracao}' WHERE cd_usuario = '{person.UserId}'";

                new Commands().ExecuteCommand(query);

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static PhraseDTO GetPhrase(string clause = "")
        {
            string query = $"SELECT cd_frase as 'Id', ds_frase as 'Frase', dt_frase_alterada as 'DataAlteracao', " +
                $"cd_usuario as 'UserId' from tb_frase {clause}";

            Commands bd = new Commands();

            var Phrase = new PhraseDTO { Id = "null" };

            var datareader = bd.ExecuteCommandReader(query);

            while (datareader.Read())
            {
                Phrase.Id = datareader["Id"].ToString();
                Phrase.Frase = datareader["Frase"].ToString();
                Phrase.DataAlteracao = (DateTime)datareader["DataAlteracao"];
                Phrase.UserId = datareader["UserId"].ToString();
            }
            datareader.Close();

            return Phrase;
        }
    }
}
