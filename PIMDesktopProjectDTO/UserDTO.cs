using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class UserDTO : AddressDTO
    {
        public string UserID { get; set; }
        public List<Contacts> Contatos;
        public string Senha { get; set; }
        public string Email { get; set; }
        public string PalavraSecreta { get; set; }
        public bool Admin { get; set; }
    }

    public class Contacts
    {
        public string ID { get; set; }
        public string Contact { get; set; }
    }
}
