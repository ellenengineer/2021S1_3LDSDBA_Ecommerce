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
    [Route("fapen/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        private readonly INFONEWContext _context;

        public UsuarioController(INFONEWContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Login> Get()
        {
            UsuarioAplicacao objAplicacao = new UsuarioAplicacao(_context);

            try
            {
                return objAplicacao.GetAllUsers();
            }
            catch (Exception ex)
            {
                var retorno = new List<Login>();
                var lg = new Login();
                lg.Login1 = ex.Message;
                retorno.Add(lg);
                return retorno;
            }

        }

        [HttpGet("{login}")]

        public string Get(string login)
        {
            UsuarioAplicacao objAplicacao = new UsuarioAplicacao(_context);
            Login lg = objAplicacao.GetUserByLogin(login);

            if (lg != null)
            {

                Security objSecurity = new Security();
                string criptografado = objSecurity.EncriptSimetrica(lg.Senha.Trim());
                string descriptografado = objSecurity.DecriptSimetrica();

                return "Usuario existente; senha: " + criptografado;

            }
            return "Usuario inválido";
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public string Post([FromBody] Login usuario)
        {
            UsuarioAplicacao objAplicacao = new UsuarioAplicacao(_context);
            Login lg = objAplicacao.GetUserByLogin(usuario.Login1);

            HttpResponseMessage response = new HttpResponseMessage();

            if (lg != null)
            {
                Security objSecurity = new Security();
                var encrp = objSecurity.EncriptSimetrica(lg.Senha);
                var descript = objSecurity.DecriptSimetrica();

                if (descript == usuario.Senha)
                {
                    return "OK";
                }
            }
            return "NOK";
        }

        // PUT api/<ProdutoController>/5
        [HttpPut("{login}")]
        public string Put([FromBody] Login lg)
        {
            UsuarioAplicacao objAppProd = new UsuarioAplicacao(_context);

            if (lg != null)
            {

                if (string.IsNullOrEmpty(lg.Senha))
                {
                    return "favor, inserir a senha!";
                }
                else
                {
                    Security objSecurity = new Security();
                    lg.Senha = objSecurity.EncriptSimetrica(lg.Senha);
                }


                if (lg.CodCli > 0)
                {
                    string retorno = objAppProd.AtualizarUsuario(lg);
                    return retorno;
                }
                else
                {
                    string retorno = objAppProd.InserirUsuario(lg);
                    return retorno;
                }
            }
            return "usuario invalido!";

        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{login}")]
        public string Delete(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                return "login inválido para exclusão";
            }
            UsuarioAplicacao objAppProd = new UsuarioAplicacao(_context);
            string retorno = objAppProd.DeleteUserByLogin(login);

            return retorno;
        }
    }
}
