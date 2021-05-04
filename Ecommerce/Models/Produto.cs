using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Produto
    {
        public Produto()
        {
            Itens = new HashSet<Iten>();
        }

        public int CodProd { get; set; }
        public int CodTipoProd { get; set; }
        public string NomeProd { get; set; }
        public int QtdEstqProd { get; set; }
        public decimal ValUnitProd { get; set; }
        public decimal? ValTotal { get; set; }

        public virtual TipoProd CodTipoProdNavigation { get; set; }
        public virtual ICollection<Iten> Itens { get; set; }
    }
}
