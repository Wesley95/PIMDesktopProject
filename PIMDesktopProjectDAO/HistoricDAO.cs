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
    public class HistoricDAO
    {
        public static bool RegisterHistoric(HistoricDTO hist)
        {
            try
            {
                string query = "INSERT INTO tb_acontecimento(ds_acontecimento, dt_acontecimento, cd_usuario) VALUES " +
                $"('{hist.Descricao}','{DateTime.Now.Date}','{hist.UserId}')";

                new Commands().ExecuteCommand(query);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static List<HistoricDTO> ListAll(string id, int init, int end)
        {
            string query = "select cd_linha_tempo as 'Id', ds_acontecimento as 'Acontecimento', " +
                $"dt_acontecimento as 'Data', cd_usuario as 'UserId' from tb_acontecimento where cd_usuario = '{id}' " +
                $"order by  dt_acontecimento desc OFFSET {init} ROWS FETCH NEXT {end} ROWS ONLY";

            Commands bd = new Commands();

            List<HistoricDTO> Historic = new List<HistoricDTO>();
            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var this_user = new HistoricDTO
                {
                    Id = datareader["Id"].ToString(),
                    Data = (DateTime)datareader["Data"],
                    Descricao = datareader["Acontecimento"].ToString(),
                    UserId = datareader["UserId"].ToString()
                };

                Historic.Add(this_user);
            }
            datareader.Close();

            return Historic;
        }
    }
}
