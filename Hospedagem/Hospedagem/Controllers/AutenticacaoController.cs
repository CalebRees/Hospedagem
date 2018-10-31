using Hospedagem.Repositories.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospedagem.Controllers
{
    public class AutenticacaoController : Controller
    {
        public JsonResult AutenticarUsuario(string login, string senha)
        {
            if (GestaoUsuario.VerificarUsuarioBD(login, senha))
            {
                return Json(new { OK = true, Mensagem = "Usuário Encontrado. Redirecionando..." },
                JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false, Mensagem = "Usuário não encontrado." },
                JsonRequestBehavior.AllowGet);
            }
        }
    }
}