using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Models;
using Ecommerce.Context;

namespace Ecommerce.Application
{
    public class UsuarioAplicacao
    {
        private INFONEWContext _contexto;

        public UsuarioAplicacao(INFONEWContext contexto)
        {
            _contexto = contexto;
        }

        public string InserirUsuario(Login lg)
        {
            try
            {
                if (lg != null)
                {
                    var usuarioExiste = GetUserByLogin(lg.Login1);

                    if (usuarioExiste == null)
                    {
                        _contexto.Add(lg);
                        _contexto.SaveChanges();

                        return "Usuario cadastrado com sucesso!";
                    }
                    else
                    {
                        return "usuario já cadastrado na base de dados.";
                    }
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public string AtualizarUsuario(Login lg)
        {
            try
            {
                if (lg != null)
                {
                    _contexto.Update(lg);
                    _contexto.SaveChanges();

                    return "Usuário alterado com sucesso!";
                }
                else
                {
                    return "Usuário inválido!";
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }

        public Login GetUserByLogin(string login)
        {
            Login loginExistente = new Login();

            try
            {
                if (login.Trim() == "")
                {
                    return null;
                }

                var lg = _contexto.Logins.Where(x => x.Login1 == login).ToList();
                loginExistente = lg.FirstOrDefault();

                if (loginExistente != null)
                {
                    return loginExistente;
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

        public Login GetUserByCodCliente(int codCli)
        {
            Login loginExistente = new Login();

            try
            {
                if (codCli== 0)
                {
                    return null;
                }

                var lg = _contexto.Logins.Where(x => x.CodCli == codCli).ToList();
                loginExistente = lg.FirstOrDefault();

                if (loginExistente != null)
                {
                    return loginExistente;
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

        public List<Login> GetAllUsers()
        {
            List<Login> lstUsers = new List<Login>();
            try
            {

                lstUsers = _contexto.Logins.ToList(); //_contexto.Produtos.Select(x => x).ToList();

                if (lstUsers != null)
                {
                    return lstUsers;
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

        public string DeleteUserByLogin(string login)
        {
            try
            {
                if (login.Trim() == "")
                {
                    return "Usuário inválido! Por favor tente novamente.";
                }
                else
                {
                    var lg = GetUserByLogin(login);

                    if (lg != null)
                    {
                        _contexto.Logins.Remove(lg);
                        _contexto.SaveChanges();

                        return "Usuário " + lg.Login1 + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não cadastrado!";
                    }
                }
            }
            catch (Exception)
            {
                return "Não foi possível se comunicar com a base de dados!";
            }
        }


        public string DeleteUserByCodCli(int CodCli)
        {
            try
            {
                if (CodCli == 0)
                {
                    return "Usuário inválido! Por favor tente novamente.";
                }
                else
                {
                    var lg = GetUserByCodCliente(CodCli);

                    if (lg != null)
                    {
                        _contexto.Logins.Remove(lg);
                        _contexto.SaveChanges();

                        return "Usuário " + lg.Login1 + " deletado com sucesso!";
                    }
                    else
                    {
                        return "Usuário não cadastrado!";
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

