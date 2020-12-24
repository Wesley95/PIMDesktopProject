using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIMDesktopProjectDTO;
using PIMDesktopProjectDAO;

namespace PIMDesktopProjectBLL
{
    public class PhraseBLL
    {
        public static PhraseDTO GetPhrase(string id) =>
            PhraseDAO.GetPhrase($" WHERE cd_usuario = '{id}'");
        public static bool Update(PhraseDTO phrase) =>
            PhraseDAO.Update(phrase);

        public static bool Insert(PhraseDTO phrase) =>
            PhraseDAO.Insert(phrase);

    }
}
