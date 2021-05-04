using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Bonu
    {
        public int NumLanc { get; set; }
        public int CodFunc { get; set; }
        public DateTime DataBonus { get; set; }
        public decimal ValBonus { get; set; }

        public virtual Funcionario CodFuncNavigation { get; set; }
    }
}
