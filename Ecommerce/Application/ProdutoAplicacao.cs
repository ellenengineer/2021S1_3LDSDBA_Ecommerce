using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Context;

namespace Ecommerce.Application
{
    public class ProdutoAplicacao
    {
        private INFONEWContext _contexto;

        public ProdutoAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        public string InserirProduto(Produto prd)
        {
            try
            {
                if (prd != null)
                {
                    var produtoExiste = GetProdByCode(prd.CodProd);

                    if (produtoExiste == null)
                    {
                        _contexto.Add(prd);
                        _contexto.SaveChanges();

                        return "Produto cadastrado com sucesso!";
                    }
                    else
                    {
                        return "produto já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string AtualizarProduto(Produto prd)
        {
            try
            {
                if (prd != null)
                {
                    _contexto.Update(prd);
                    _contexto.SaveChanges();

                    return "Produto alterado com sucesso!";
                }
                else
                {
                    return "Produto inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Produto GetProdByCode(int codProd)
        {
            Produto produtoExistente = new Produto();

            try
            {
                if (codProd == 0)
                {
                    return null;
                }

                var prd = _contexto.Produtos.Where(x => x.CodProd == codProd).ToList();
                produtoExistente = prd.FirstOrDefault();

                if (produtoExistente != null)
                {
                    return produtoExistente;                        ;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Produto> GetAllProducts()
        {
            List<Produto> lstPrd = new List<Produto>();
            try
            {
                foreach (var item in _contexto.Produtos)
                {

                    lstPrd.Add(item);
                }


                if (lstPrd != null)
                {
                    return lstPrd;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string DeletePRodByCodProd(int codPRod)
        {
            try
            {
                if (codPRod == 0)
                {
                    return "Produto inválido! Por favor tente novamente.";
                }
                else
                {
                    var prd = GetProdByCode(codPRod);

                    if (prd != null)
                    {
                        _contexto.Produtos.Remove(prd);
                        _contexto.SaveChanges();

                        return "Produto " + prd.NomeProd + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Produto não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }
    }
}
