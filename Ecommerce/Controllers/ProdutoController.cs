using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Application;
using Ecommerce.Context;
using Ecommerce.library;
using System.Net;
using System.Net.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ecommerce.Controllers
{
    [Route("fapen/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly INFONEWContext _context;

        public ProdutoController(INFONEWContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Produto> Get()
        {
            ProdutoAplicacao objAplicacao = new ProdutoAplicacao(_context);

            try
            {
                return objAplicacao.GetAllProducts();
            }
            catch (Exception ex)
            {
                var retorno = new List<Produto>();
                var prd = new Produto();
                prd.NomeProd = ex.Message;
                retorno.Add(prd);
                return retorno;
            }

        }

        [HttpGet("{CodProd}")]

        public Produto Get(int CodProd)
        {
            ProdutoAplicacao objAplicacao = new ProdutoAplicacao(_context);
            Produto prd = objAplicacao.GetProdByCode(CodProd);

            return prd;
        }


        // PUT api/<ProdutoController>/5
        [HttpPut()]
        public string Put([FromBody] Produto value)
        {
            ProdutoAplicacao objAppProd = new ProdutoAplicacao(_context);

            if (value != null)
            {

                if (value.CodProd > 0)
                {
                    string retorno = objAppProd.AtualizarProduto(value);
                    return retorno;
                }
                else
                {
                    string retorno = objAppProd.InserirProduto(value);
                    return retorno;
                }
            }
            return "produto invalido!";

        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{CodProd}")]
        public string Delete(int CodProd)
        {
            if (CodProd == 0)
            {
                return "produto inválido para exclusão";
            }
            ProdutoAplicacao objAppProd = new ProdutoAplicacao(_context);
            string retorno = objAppProd.DeletePRodByCodProd(CodProd);

            return retorno;
        }
    }
}
