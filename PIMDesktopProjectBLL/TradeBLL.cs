using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectBLL
{
    public class TradeBLL
    {
        public static bool RegisterUser(TradeDTO person) =>
            TradeDAO.Insert(person);

        public static List<TradeDTO> ListAll(string userid) =>
            TradeDAO.ListAllById(userid);

        public static List<TradeDTO> ListAllByIdLimited(int init, int end, string id) =>
            TradeDAO.ListAllByIdLimited(init, end, id);

        public static bool Remove(TradeDTO[] trade) =>
            TradeDAO.Remove(trade);
    }
}
