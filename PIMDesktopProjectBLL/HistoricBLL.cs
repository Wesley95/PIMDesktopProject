using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class HistoricBLL
    {
        public static bool RegisterHistoric(HistoricDTO hist) =>
            HistoricDAO.RegisterHistoric(hist);

        public static List<HistoricDTO> ListAll(string id, int init, int end) =>
            HistoricDAO.ListAll(id, init, end);

    }
}
