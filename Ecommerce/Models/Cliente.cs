using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Creditos = new HashSet<Credito>();
            Emails = new HashSet<Email>();
            Enderecos = new HashSet<Endereco>();
            Fones = new HashSet<Fone>();
            Pedidos = new HashSet<Pedido>();
        }

        public int CodCli { get; set; }
        public int CodTipoCli { get; set; }
        public string NomeCli { get; set; }
        public DateTime DataCadCli { get; set; }
        public decimal RendaCli { get; set; }
        public string SexoCli { get; set; }

        public virtual TipoCli CodTipoCliNavigation { get; set; }
        public virtual Conjuge Conjuge { get; set; }
        public virtual ICollection<Credito> Creditos { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
        public virtual ICollection<Fone> Fones { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
