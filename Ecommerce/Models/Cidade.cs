using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Cidade
    {
        public Cidade()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public int CodCid { get; set; }
        public int CodEst { get; set; }
        public string NomeCid { get; set; }

        public virtual Estado CodEstNavigation { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
