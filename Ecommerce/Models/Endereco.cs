using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Endereco
    {
        public int CodEnd { get; set; }
        public int CodTipoEnd { get; set; }
        public int CodCid { get; set; }
        public int CodCli { get; set; }
        public string NomeRua { get; set; }
        public string NomeBairro { get; set; }
        public string ComplEnd { get; set; }

        public virtual Cidade CodC { get; set; }
        public virtual Cliente CodCliNavigation { get; set; }
        public virtual TipoEnd CodTipoEndNavigation { get; set; }
    }
}
