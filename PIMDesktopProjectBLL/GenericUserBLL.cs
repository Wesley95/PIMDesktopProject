using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class GenericUserBLL
    {
        public static GenericUserDTO GetUserById(string id) =>
            GenericUserDAO.GetUserById(id);

    }
}
