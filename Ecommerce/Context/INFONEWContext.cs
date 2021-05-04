using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ecommerce.Models;

#nullable disable

namespace Ecommerce.Context
{
    public partial class INFONEWContext : DbContext
    {
        public INFONEWContext()
        {
        }

        public INFONEWContext(DbContextOptions<INFONEWContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bonu> Bonus { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Conjuge> Conjuges { get; set; }
        public virtual DbSet<Credito> Creditos { get; set; }
        public virtual DbSet<Dependente> Dependentes { get; set; }
        public virtual DbSet<Email> Emails { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Fone> Fones { get; set; }
        public virtual DbSet<Funcionario> Funcionarios { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        public virtual DbSet<Iten> Itens { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Pai> Pais { get; set; }
        public virtual DbSet<Parcela> Parcelas { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Pontuacao> Pontuacaos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<StatusPedido> StatusPedidos { get; set; }
        public virtual DbSet<TipoCli> TipoClis { get; set; }
        public virtual DbSet<TipoEnd> TipoEnds { get; set; }
        public virtual DbSet<TipoProd> TipoProds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=DESKTOP-8HAU83C\\SQLEXPRESS;database=INFONEW;integrated security=yes;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Bonu>(entity =>
            {
                entity.HasKey(e => e.NumLanc);

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataBonus)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Bonus")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValBonus)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Val_Bonus");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Bonus)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bonus");
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.CodCid)
                    .HasName("PK_Cid");

                entity.ToTable("Cidade");

                entity.Property(e => e.CodCid)
                    .ValueGeneratedNever()
                    .HasColumnName("Cod_Cid");

                entity.Property(e => e.CodEst).HasColumnName("Cod_est");

                entity.Property(e => e.NomeCid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Cid");

                entity.HasOne(d => d.CodEstNavigation)
                    .WithMany(p => p.Cidades)
                    .HasForeignKey(d => d.CodEst)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cid");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PK_Cli");

                entity.ToTable("Cliente");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodTipoCli).HasColumnName("Cod_TipoCli");

                entity.Property(e => e.DataCadCli)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_CadCli")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NomeCli)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Cli");

                entity.Property(e => e.RendaCli)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Renda_Cli");

                entity.Property(e => e.SexoCli)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sexo_Cli")
                    .HasDefaultValueSql("('F')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodTipoCliNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.CodTipoCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cli");
            });

            modelBuilder.Entity<Conjuge>(entity =>
            {
                entity.HasKey(e => e.CodCli)
                    .HasName("PK_Conj");

                entity.ToTable("Conjuge");

                entity.Property(e => e.CodCli)
                    .ValueGeneratedNever()
                    .HasColumnName("Cod_Cli");

                entity.Property(e => e.NomeConj)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Conj")
                    .IsFixedLength(true);

                entity.Property(e => e.RendaConj)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Renda_Conj");

                entity.Property(e => e.SexoConj)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sexo_Conj")
                    .HasDefaultValueSql("('M')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodCliNavigation)
                    .WithOne(p => p.Conjuge)
                    .HasForeignKey<Conjuge>(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Conj");
            });

            modelBuilder.Entity<Credito>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Cred");

                entity.ToTable("Credito");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CredCli)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Cred_Cli");

                entity.Property(e => e.DataCredCli)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_CredCli");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Creditos)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cred");
            });

            modelBuilder.Entity<Dependente>(entity =>
            {
                entity.HasKey(e => e.CodDep)
                    .HasName("PK_Dep");

                entity.ToTable("Dependente");

                entity.Property(e => e.CodDep).HasColumnName("Cod_Dep");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataNascDep)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_NascDep");

                entity.Property(e => e.NomeDep)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Dep");

                entity.Property(e => e.SexoDep)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sexo_Dep")
                    .HasDefaultValueSql("('F')")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Dependentes)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Dep");
            });

            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Email");

                entity.ToTable("EMail");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.EmailCli)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMail_Cli");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Emails)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Emails");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.CodEnd)
                    .HasName("PK_End");

                entity.ToTable("Endereco");

                entity.Property(e => e.CodEnd).HasColumnName("Cod_End");

                entity.Property(e => e.CodCid).HasColumnName("Cod_Cid");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodTipoEnd).HasColumnName("Cod_TipoEnd");

                entity.Property(e => e.ComplEnd)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Compl_End");

                entity.Property(e => e.NomeBairro)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Bairro");

                entity.Property(e => e.NomeRua)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Rua");

                entity.HasOne(d => d.CodC)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodCid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End2");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End3");

                entity.HasOne(d => d.CodTipoEndNavigation)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.CodTipoEnd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_End1");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.CodEst)
                    .HasName("PK_Est");

                entity.ToTable("Estado");

                entity.Property(e => e.CodEst).HasColumnName("Cod_Est");

                entity.Property(e => e.CodPais).HasColumnName("Cod_Pais");

                entity.Property(e => e.NomeEst)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Est");

                entity.Property(e => e.SiglaEst)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("sigla_est")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodPaisNavigation)
                    .WithMany(p => p.Estados)
                    .HasForeignKey(d => d.CodPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Est1");
            });

            modelBuilder.Entity<Fone>(entity =>
            {
                entity.HasKey(e => e.NumLanc);

                entity.ToTable("Fone");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.NumDdd)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Num_DDD")
                    .HasDefaultValueSql("('011')")
                    .IsFixedLength(true);

                entity.Property(e => e.NumFone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Num_Fone")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Fones)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Fone");
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.CodFunc)
                    .HasName("PK_Func");

                entity.ToTable("Funcionario");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataCadFunc)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_CadFunc")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndFunc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("End_Func");

                entity.Property(e => e.NomeFunc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Func");

                entity.Property(e => e.SalFunc)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Sal_Func")
                    .HasDefaultValueSql("((200))");

                entity.Property(e => e.SexoFunc)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Sexo_Func")
                    .HasDefaultValueSql("('F')")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Hist");

                entity.ToTable("Historico");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataHist)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Hist")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SalAnt)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Sal_Ant");

                entity.Property(e => e.SalAtual)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Sal_Atual");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Hist");
            });

            modelBuilder.Entity<Iten>(entity =>
            {
                entity.HasKey(e => new { e.NumPed, e.CodProd });

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.CodProd).HasColumnName("Cod_Prod");

                entity.Property(e => e.QtdVend).HasColumnName("Qtd_Vend");

                entity.Property(e => e.ValVend)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Val_Vend");

                entity.HasOne(d => d.CodProdNavigation)
                    .WithMany(p => p.Itens)
                    .HasForeignKey(d => d.CodProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itens2");

                entity.HasOne(d => d.NumPedNavigation)
                    .WithMany(p => p.Itens)
                    .HasForeignKey(d => d.NumPed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itens1");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login");

                //entity.HasIndex(e => e.CodCli, "IX_Login");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.Login1)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("login")
                    .IsFixedLength(true);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("senha")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Login_Cliente");
            });

            modelBuilder.Entity<Pai>(entity =>
            {
                entity.HasKey(e => e.CodPais)
                    .HasName("PK_pais");

                entity.Property(e => e.CodPais)
                    .ValueGeneratedNever()
                    .HasColumnName("Cod_pais");

                entity.Property(e => e.NomePais)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_pais");
            });

            modelBuilder.Entity<Parcela>(entity =>
            {
                entity.HasKey(e => new { e.NumPar, e.NumPed });

                entity.ToTable("Parcela");

                entity.Property(e => e.NumPar).HasColumnName("Num_Par");

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.DataPgto)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Pgto");

                entity.Property(e => e.DataVenc)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Venc")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValPgto)
                    .HasColumnType("numeric(13, 3)")
                    .HasColumnName("Val_Pgto")
                   // .HasComputedColumnSql("(case when [Data_Pgto]<[Data_Venc] then [Val_Venc]*(0.9) when [Data_Pgto]=[Data_Venc] then [Val_Venc] when [Data_Pgto]>[Data_Venc] then [Val_Venc]*(1.1)  end)", false)
                    ;

                entity.Property(e => e.ValVenc)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Val_Venc");

                entity.HasOne(d => d.NumPedNavigation)
                    .WithMany(p => p.Parcelas)
                    .HasForeignKey(d => d.NumPed)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parcela");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.NumPed);

                entity.ToTable("Pedido");

                entity.Property(e => e.NumPed).HasColumnName("Num_Ped");

                entity.Property(e => e.CodCli).HasColumnName("Cod_Cli");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.CodSta).HasColumnName("Cod_Sta");

                entity.Property(e => e.DataPed)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Ped")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ValPed)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Val_Ped");

                entity.HasOne(d => d.CodCliNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodCli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido1");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido2");

                entity.HasOne(d => d.CodStaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.CodSta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido3");
            });

            modelBuilder.Entity<Pontuacao>(entity =>
            {
                entity.HasKey(e => e.NumLanc)
                    .HasName("PK_Pto");

                entity.ToTable("Pontuacao");

                entity.Property(e => e.NumLanc).HasColumnName("Num_Lanc");

                entity.Property(e => e.CodFunc).HasColumnName("Cod_Func");

                entity.Property(e => e.DataPto)
                    .HasColumnType("datetime")
                    .HasColumnName("Data_Pto")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PtoFunc)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("Pto_Func");

                entity.HasOne(d => d.CodFuncNavigation)
                    .WithMany(p => p.Pontuacaos)
                    .HasForeignKey(d => d.CodFunc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pto");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.CodProd)
                    .HasName("PK_Prod");

                entity.ToTable("Produto");

                //entity.HasIndex(e => e.NomeProd, "UQ_Prod")
                //    .IsUnique();

                entity.Property(e => e.CodProd).HasColumnName("Cod_Prod");

                entity.Property(e => e.CodTipoProd).HasColumnName("Cod_TipoProd");

                entity.Property(e => e.NomeProd)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_Prod");

                entity.Property(e => e.QtdEstqProd).HasColumnName("Qtd_EstqProd");

                entity.Property(e => e.ValTotal)
                    .HasColumnType("decimal(21, 2)")
                    .HasColumnName("Val_Total")
                    //.HasComputedColumnSql("([Qtd_EstqProd]*[Val_UnitProd])", false)
                    ;

                entity.Property(e => e.ValUnitProd)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Val_UnitProd");

                entity.HasOne(d => d.CodTipoProdNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.CodTipoProd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Prod");
            });

            modelBuilder.Entity<StatusPedido>(entity =>
            {
                entity.HasKey(e => e.CodSta)
                    .HasName("PK_StatusPed");

                entity.ToTable("StatusPedido");

                //entity.HasIndex(e => e.StaPed, "UQ_StatusPed")
                //    .IsUnique();

                entity.Property(e => e.CodSta).HasColumnName("Cod_Sta");

                entity.Property(e => e.StaPed)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Sta_Ped");
            });

            modelBuilder.Entity<TipoCli>(entity =>
            {
                entity.HasKey(e => e.CodTipoCli);

                entity.ToTable("TipoCli");

                //entity.HasIndex(e => e.NomeTipoCli, "UQ_TipoCli")
                //    .IsUnique();

                entity.Property(e => e.CodTipoCli).HasColumnName("Cod_TipoCli");

                entity.Property(e => e.NomeTipoCli)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_TipoCli");
            });

            modelBuilder.Entity<TipoEnd>(entity =>
            {
                entity.HasKey(e => e.CodTipoEnd);

                entity.ToTable("TipoEnd");

                //entity.HasIndex(e => e.NomeTipoEnd, "UQ_TipoEnd")
                //    .IsUnique();

                entity.Property(e => e.CodTipoEnd).HasColumnName("Cod_TipoEnd");

                entity.Property(e => e.NomeTipoEnd)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Nome_TipoEnd");
            });

            modelBuilder.Entity<TipoProd>(entity =>
            {
                entity.HasKey(e => e.CodTipoProd);

                entity.ToTable("TipoProd");

                //entity.HasIndex(e => e.NomeTipoProd, "UQ_TipoProd")
                //    .IsUnique();

                entity.Property(e => e.CodTipoProd).HasColumnName("Cod_TipoProd");

                entity.Property(e => e.NomeTipoProd)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Nome_TipoProd");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
