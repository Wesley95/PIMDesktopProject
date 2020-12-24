using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using BD;

namespace PIMDesktopProjectDAO
{
    public class TradeDAO
    {
        public static bool Insert(TradeDTO person)
        {
            try
            {
                string query = "INSERT INTO tb_troca(ds_tipo, vl_compra, ds_moeda_compra, " +
                "vl_venda, ds_moeda_venda, vl_taxa, ds_moeda_taxa, ds_comentario, dt_troca, cd_usuario) VALUES " +
                $"('{person.Tipo}','{person.ValorCompra}','{person.MoedaCompra}','{person.ValorVenda}','{person.MoedaVenda}'," +
                $"'{person.ValorTaxa}','{person.MoedaTaxa}','{person.Comentario}','{person.DataTroca.Date}','{person.UserId}')";

                new Commands().ExecuteCommand(query);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Remove(TradeDTO[] trade)
        {
            try
            {
                var dt = new DataTable();
                dt.Columns.Add("Id");
                dt.Columns.Add("UserId");

                foreach (var t in trade)
                    dt.Rows.Add(t.Id, t.UserId);


                using (SqlConnection con = new Commands().Con())
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteTrades", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Trades", dt);
                        
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

        public static List<TradeDTO>ListAllByIdLimited(int init, int end, string id)
        {
            return ListAll($" WHERE cd_usuario = '{id}' order by cd_usuario OFFSET {init} ROWS FETCH NEXT {end} ROWS ONLY");
        }

        public static List<TradeDTO> ListAllById(string id)
        {
            return ListAll($"WHERE cd_usuario = {id}");
        }

        public static List<TradeDTO> ListAll(string clause = "")
        {
            string query = "select cd_troca as 'Id', ds_tipo as 'Tipo', vl_compra as 'ValorCompra', ds_moeda_compra as 'MoedaCompra', vl_venda as 'ValorVenda', " +
            "ds_moeda_venda as 'MoedaVenda', vl_taxa as 'ValorTaxa', ds_moeda_taxa as 'MoedaTaxa', ds_comentario as 'Comentario', dt_troca as 'Data', " +
            $"cd_usuario as 'UsuarioId' from tb_troca {clause}";

            Commands bd = new Commands();

            var Trade = new List<TradeDTO>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var trade = new TradeDTO
                {
                    Id = datareader["Id"].ToString(),
                    Tipo = datareader["Tipo"].ToString(),
                    ValorCompra = datareader["ValorCompra"].ToString(),
                    MoedaCompra = datareader["MoedaCompra"].ToString(),
                    ValorVenda = datareader["ValorVenda"].ToString(),
                    MoedaVenda = datareader["MoedaVenda"].ToString(),
                    ValorTaxa = datareader["ValorTaxa"].ToString(),
                    MoedaTaxa = datareader["MoedaTaxa"].ToString(),
                    Comentario = datareader["Comentario"].ToString(),
                    DataTroca = (DateTime)datareader["Data"],
                    UserId = datareader["UsuarioId"].ToString()
                };

                Trade.Add(trade);
            }
            datareader.Close();

            return Trade;
        }

    }
}
