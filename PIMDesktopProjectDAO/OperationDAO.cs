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
    public class OperationDAO
    {
        public static OperationDTO SelectById(string id)
        {
            string query = "select cd_operacao as 'Id', ds_tipo_operacao as 'Operacao' " +
                $"from tb_operacao where cd_operacao = '{id}' order by ds_tipo_operacao";

            var item = GetAll(query);

            return item.Count > 0 ? item.FirstOrDefault() : new OperationDTO { Id = "null" };
        }

        public static List<OperationDTO> ListAll()
        {
            string query = "select cd_operacao as 'Id', ds_tipo_operacao as 'Operacao' " +
                "from tb_operacao order by ds_tipo_operacao";

            return GetAll(query);
        }

        private static List<OperationDTO> GetAll(string query)
        {
            Commands bd = new Commands();

            var Operation = new List<OperationDTO>();

            string selectProducts = query;

            SqlDataReader datareader = bd.ExecuteCommandReader(selectProducts);

            while (datareader.Read())
            {
                var op = new OperationDTO
                {
                    Id = datareader["Id"].ToString(),
                    Tipo = datareader["Operacao"].ToString()
                };

                Operation.Add(op);
            }
            datareader.Close();

            return Operation;
        }
    }
}
