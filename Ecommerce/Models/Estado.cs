using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Cidades = new HashSet<Cidade>();
        }

        public int CodEst { get; set; }
        public string SiglaEst { get; set; }
        public string NomeEst { get; set; }
        public int CodPais { get; set; }

        public virtual Pai CodPaisNavigation { get; set; }
        public virtual ICollection<Cidade> Cidades { get; set; }
    }
}
