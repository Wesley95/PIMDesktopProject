using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class OperationBLL
    {
        public static List<OperationDTO> ListAll() =>
            OperationDAO.ListAll();
    }
}
