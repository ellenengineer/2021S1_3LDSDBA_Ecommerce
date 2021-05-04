using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Pai
    {
        public Pai()
        {
            Estados = new HashSet<Estado>();
        }

        public int CodPais { get; set; }
        public string NomePais { get; set; }

        public virtual ICollection<Estado> Estados { get; set; }
    }
}
