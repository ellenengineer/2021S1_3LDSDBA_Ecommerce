using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Credito
    {
        public int NumLanc { get; set; }
        public int CodCli { get; set; }
        public decimal CredCli { get; set; }
        public DateTime DataCredCli { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
    }
}
