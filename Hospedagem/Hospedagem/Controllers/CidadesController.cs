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
    public class CidadesController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.Cidade.ToList());
        }
        public ActionResult Detalhes(int id)
        {
            return View(db.Cidade.ToList().Find(x => x.IDCidade == id));
        }
        public ActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Cidade.Add(cidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }
        public ActionResult Alterar(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }
        [HttpPost]
        public ActionResult Alterar(Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidade);
        }
        public ActionResult Excluir(int id)
        {
            Cidade cidade = db.Cidade.Find(id);
            return View(cidade);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Cidade cidade = db.Cidade.Find(id);
                db.Cidade.Remove(cidade);
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
