using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class HelperBLL
    {
        public static string Code(int char_count) =>
            Helper.Code(char_count);
    }
}
