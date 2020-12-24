using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class GenericUserDTO : UserDTO
    {
        public string Nome { get; set; }
        public string Id { get; set; }
        public string Doc { get; set; }
        public DateTime Data { get; set; }
    }
}
