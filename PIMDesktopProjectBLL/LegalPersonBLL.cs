using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PIMDesktopProjectDAO;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectBLL
{
    public class LegalPersonBLL
    {
        public static bool RegisterUser(LegalPerson user) =>
            LegalPersonDAO.RegisterUser(user);

        public static List<LegalPerson> ListAll(string clause = "") =>
            LegalPersonDAO.ListAll(clause);

        public static LegalPerson GetUserByCNPJ(string cnpj)
        {
            var user = ListAll($" WHERE p.cd_cnpj = '{cnpj}'");
            return user.Count > 0 ? user.FirstOrDefault() : new LegalPerson { UserID = "null" };
        }
        public static LegalPerson ListAllByUserId(string id)
        {
            var user = ListAll($" WHERE u.cd_usuario = '{id}'");
            return user.Count > 0 ? user.FirstOrDefault() : new LegalPerson { UserID = "null" };
        }

        public static bool HasCNPJ(string cnpj) =>
            ListAll($" WHERE p.cd_cnpj = '{cnpj}'").Any(x => x.CNPJ == cnpj);


        public static bool HasEmail(string email) =>
            UserDAO.ListAll($" WHERE ds_email = '{email}'").Any(x => x.Email.ToUpper() == email.ToUpper());

        public static bool UpdateUser(LegalPerson person) =>
            LegalPersonDAO.UpdateUser(person);

        public static bool UpdatePass(LegalPerson person) =>
            LegalPersonDAO.UpdatePass(person);
    }
}
