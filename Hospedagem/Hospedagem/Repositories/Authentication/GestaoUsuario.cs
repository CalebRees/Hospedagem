using Hospedagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hospedagem.Repositories.Authentication
{
    public class GestaoUsuario
    {
        public static bool VerificarUsuarioBD(string login, string senha)
        {
            try
            {
                HospedagemBDEntities db = new HospedagemBDEntities();
                var usuario =
                db.Usuario.Where(x => x.Login == login && x.Senha == senha).SingleOrDefault();
                if (usuario == null)
                {
                    return false;
                }
                else
                {
                    GestaoCookie.CriarCookie(usuario.IDUsuario);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }            
        }
    }
}