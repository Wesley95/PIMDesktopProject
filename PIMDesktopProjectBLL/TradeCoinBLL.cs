using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;
using PIMDesktopProjectDTO;


namespace PIMDesktopProjectBLL
{
    public class TradeCoinBLL
    {
        public static List<TradeCoinDTO> ListAll() =>
             TradeCoinDAO.ListAll();
    }
}
