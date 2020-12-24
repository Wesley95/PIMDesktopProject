using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectBLL
{
    public class UserBLL
    {
        public static List<UserDTO> ListAll(string clause = "") =>
            UserDAO.ListAll(clause);

        public static UserDTO GetUserById(string id)
        {
            var user = UserDAO.ListAll($" WHERE cd_usuario = {id}");
            return user.Count > 0 ? user.FirstOrDefault() : new UserDTO { UserID = "null" };
        }

        public static UserDTO ListAllByEmail(string email = "")
        {
            var user = UserDAO.ListAll($" WHERE ds_email = '{email}'");

            return user.Count > 0 ? user.FirstOrDefault() : new UserDTO { Email = "null" };
        }

        public static List<Contacts> ListContacts(string id) =>
            UserDAO.ListContacts($" WHERE cd_usuario = '{id}'");

        public static bool UpdatePassword(string id, string pass) =>
            UserDAO.UpdatePassword(id, pass);
    }
}
