using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Login
    {
        public int CodCli { get; set; }
        public string Login1 { get; set; }
        public string Senha { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
    }
}
