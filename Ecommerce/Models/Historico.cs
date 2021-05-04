using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Historico
    {
        public int NumLanc { get; set; }
        public int CodFunc { get; set; }
        public DateTime DataHist { get; set; }
        public decimal SalAnt { get; set; }
        public decimal SalAtual { get; set; }

        public virtual Funcionario CodFuncNavigation { get; set; }
    }
}
