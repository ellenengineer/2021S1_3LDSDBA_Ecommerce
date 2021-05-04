using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Pedido
    {
        public Pedido()
        {
            Itens = new HashSet<Iten>();
            Parcelas = new HashSet<Parcela>();
        }

        public int NumPed { get; set; }
        public int CodCli { get; set; }
        public int CodFunc { get; set; }
        public short CodSta { get; set; }
        public DateTime DataPed { get; set; }
        public decimal ValPed { get; set; }

        public virtual Cliente CodCliNavigation { get; set; }
        public virtual Funcionario CodFuncNavigation { get; set; }
        public virtual StatusPedido CodStaNavigation { get; set; }
        public virtual ICollection<Iten> Itens { get; set; }
        public virtual ICollection<Parcela> Parcelas { get; set; }
    }
}
