using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class GenericReturnBLL
    {
        public static List<string> AllValues(string query, string field) =>
            GenericReturnDAO.AllValues(query, field);
    }
}
