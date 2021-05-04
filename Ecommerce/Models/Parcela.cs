using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Parcela
    {
        public short NumPar { get; set; }
        public int NumPed { get; set; }
        public DateTime DataVenc { get; set; }
        public decimal ValVenc { get; set; }
        public DateTime? DataPgto { get; set; }
        public decimal? ValPgto { get; set; }

        public virtual Pedido NumPedNavigation { get; set; }
    }
}
