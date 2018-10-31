using Hospedagem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospedagem.Controllers
{
    public class HomeController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();
        public ActionResult Login()
        {
            ViewBag.Title = "Autenticação";
            return View();
        }
        public ActionResult Index()
        {
            ViewBag.Cidade = new SelectList(db.Cidade, "IDCidade", "Nome");
            ViewBag.Categoria = new SelectList(db.Categoria, "IDCategoria", "Descricao");
            return View();
        }
        public ActionResult Pesquisar(Pesquisa pesquisa)
        {
            var estabelecimentos = from r in db.Estabelecimento
                                   where r.IDCategoria == pesquisa.IDCategoria && r.IDCidade == pesquisa.IDCidade
                                   select new ResultadoPesquisa
                                   {
                                       Nome = r.Nome,
                                       Endereco = r.Endereco,
                                       Telefone = r.Telefone,
                                       Site = r.Site
                                   };
            return Json(estabelecimentos, JsonRequestBehavior.AllowGet);
        }
    }
}