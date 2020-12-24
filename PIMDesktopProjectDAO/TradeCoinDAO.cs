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
    public class TradeCoinDAO
    {
        public static List<TradeCoinDTO> ListAll()
        {
            string query = "select cd_tipo_moeda as 'Id', " +
                "nm_moeda_tipo as 'Nome', sg_moeda_tipo as 'Sigla' " +
                $"from tb_tipo_moeda order by sg_moeda_tipo";

            return GetAll(query);
        }

        private static List<TradeCoinDTO> GetAll(string query)
        {
            Commands bd = new Commands();

            var Coin = new List<TradeCoinDTO>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var coin = new TradeCoinDTO
                {
                    Id = datareader["Id"].ToString(),
                    Nome = datareader["Nome"].ToString(),
                    Sigla = datareader["Sigla"].ToString()
                };

                Coin.Add(coin);
            }
            datareader.Close();

            return Coin;
        }
    }
}
