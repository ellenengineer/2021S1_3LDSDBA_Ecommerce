using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Fone
    {
        public int NumLanc { get; set; }
        public int CodCli { get; set; }
        public string NumFone { get; set; }
        public string NumDdd { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
    }
}
