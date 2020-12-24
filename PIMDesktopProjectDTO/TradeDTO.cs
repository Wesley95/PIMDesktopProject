using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMDesktopProjectDTO
{
    public class TradeDTO
    {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string ValorCompra { get; set; }
        public string MoedaCompra { get; set; }
        public string ValorVenda { get; set; }
        public string MoedaVenda { get; set; }
        public string ValorTaxa { get; set; }
        public string MoedaTaxa { get; set; }
        public string Comentario { get; set; }
        public DateTime DataTroca { get; set; }
        public string UserId { get; set; }
    }
}
