using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectDAO
{
    public class WordDAO
    {
        public static List<WordDTO> ListAll()
        {
            string query = "SELECT cd_palavra as 'Id', ds_palavra as 'Palavra' from tb_palavra";

            Commands bd = new Commands();

            var Word = new List<WordDTO>();

            SqlDataReader datareader = bd.ExecuteCommandReader(query);

            while (datareader.Read())
            {
                var word = new WordDTO
                {
                    Id = datareader["Id"].ToString(),
                    Word = datareader["Palavra"].ToString()
                };

                Word.Add(word);
            }
            datareader.Close();

            return Word;
        }
    }
}
