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
    public class QuartosController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.Quarto.ToList()); 
        }

        public ActionResult Detalhes(int id)
        {
            return View(db.Quarto.ToList().Find(x => x.IDEstab == id));
        }
        public ActionResult Inserir()
        {
            ViewBag.IDEstab = new SelectList(db.Estabelecimento, "IDEstab", "Nome");
            ViewBag.IDTipoQuarto = new SelectList(db.TipoQuarto, "IDTipoQuarto", "Descricao");
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Quarto.Add(quarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEstab = new SelectList(db.Estabelecimento, "IDEstab", "Nome",quarto);
            ViewBag.IDTipoQuarto = new SelectList(db.TipoQuarto, "ID", "IDTipoQuarto", "Descricao",quarto);
            return View(quarto);
        }
        public ActionResult Alterar(int id)
        {
            Quarto quarto = db.Quarto.Find(id);
            return View(quarto);
        }
        [HttpPost]
        public ActionResult Alterar(Quarto quarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quarto);
        }
        public ActionResult Excluir(int id)
        {
            Quarto quarto = db.Quarto.Find(id);
            return View(quarto);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Quarto quarto = db.Quarto.Find(id);
                db.Quarto.Remove(quarto);
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
