using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hospedagem.Models;

namespace Hospedagem.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.Estabelecimento.ToList());
        }

        public ActionResult Detalhes(int id)
        {
            return View(db.Estabelecimento.ToList().Find(x => x.IDEstab == id));
        }
        public ActionResult Inserir()
        {
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome");
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Descricao"); 
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Estabelecimento.Add(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome",estabelecimento);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Descricao",estabelecimento);
            return View(estabelecimento);
        }
        public ActionResult Alterar(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome",estabelecimento);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Descricao",estabelecimento);
            return View(estabelecimento);
        }
        [HttpPost]
        public ActionResult Alterar(Estabelecimento estabelecimento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estabelecimento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome",estabelecimento);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Descricao",estabelecimento);
            return View(estabelecimento);
        }
        public ActionResult Excluir(int id)
        {
            Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
            ViewBag.IDCidade = new SelectList(db.Cidade, "IDCidade", "Nome",estabelecimento);
            ViewBag.IDCategoria = new SelectList(db.Categoria, "IDCategoria", "Descricao",estabelecimento);
            return View(estabelecimento);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Estabelecimento estabelecimento = db.Estabelecimento.Find(id);
                db.Estabelecimento.Remove(estabelecimento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("ErroExcluir");
            }
        }
        public ActionResult ErroExcluir()
        {
            return View();
        }
    }
}
