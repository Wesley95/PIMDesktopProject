using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDAO;
using PIMDesktopProjectDTO;

namespace PIMDesktopProjectBLL
{
    public class NaturalPersonBLL
    {
        public static bool RegisterUser(NaturalPerson person) =>
            NaturalPersonDAO.RegisterUser(person);

        public static List<NaturalPerson> ListAll(string clause) =>
            NaturalPersonDAO.ListAll(clause);

        public static NaturalPerson GetUserByCPF(string cpf)
        {
            var user = ListAll($" WHERE p.cd_cpf = '{cpf}'");
            return user.Count > 0 ? user.FirstOrDefault() : new NaturalPerson { UserID = "null" };
        }

        public static NaturalPerson ListAllByUserId(string id)
        {
            var user = ListAll($" WHERE u.cd_usuario = '{id}'");
            return user.Count > 0 ? user.FirstOrDefault() : new NaturalPerson { UserID = "null" };
        }

        public static bool HasCPF(string cpf) =>
            ListAll($" WHERE p.cd_cpf = '{cpf}'").Any(x => x.CPF == cpf);

        public static bool HasEmail(string email) =>
            UserDAO.ListAll($" WHERE ds_email = '{email}'").Any(x => x.Email.ToUpper() == email.ToUpper());

        public static bool UpdateUser(NaturalPerson person) =>
            NaturalPersonDAO.UpdateUser(person);

        public static bool UpdatePass(NaturalPerson person) =>
            NaturalPersonDAO.UpdatePass(person);

    }
}
