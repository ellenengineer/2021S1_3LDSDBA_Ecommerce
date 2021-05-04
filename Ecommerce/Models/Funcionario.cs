using System;
using System.Collections.Generic;

#nullable disable

namespace Ecommerce.Models
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Bonus = new HashSet<Bonu>();
            Dependentes = new HashSet<Dependente>();
            Historicos = new HashSet<Historico>();
            Pedidos = new HashSet<Pedido>();
            Pontuacaos = new HashSet<Pontuacao>();
        }

        public int CodFunc { get; set; }
        public string NomeFunc { get; set; }
        public DateTime DataCadFunc { get; set; }
        public string SexoFunc { get; set; }
        public decimal SalFunc { get; set; }
        public string EndFunc { get; set; }

        public virtual ICollection<Bonu> Bonus { get; set; }
        public virtual ICollection<Dependente> Dependentes { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
        public virtual ICollection<Pontuacao> Pontuacaos { get; set; }
    }
}
