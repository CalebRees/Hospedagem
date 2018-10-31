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
    public class TipoQuartosController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.TipoQuarto.ToList());
        }
        public ActionResult Detalhes(int id)
        {
            return View(db.TipoQuarto.ToList().Find(x => x.IDTipoQuarto == id));
        }
        public ActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(TipoQuarto tipoquarto)
        {
            if (ModelState.IsValid)
            {
                db.TipoQuarto.Add(tipoquarto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoquarto);
        }
        public ActionResult Alterar(int id)
        {
            TipoQuarto tipoquarto = db.TipoQuarto.Find(id);
            return View(tipoquarto);
        }
        [HttpPost]
        public ActionResult Alterar(TipoQuarto tipoquarto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoquarto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoquarto);
        }
        public ActionResult Excluir(int id)
        {
            TipoQuarto tipoquarto = db.TipoQuarto.Find(id);
            return View(tipoquarto);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                TipoQuarto tipoquarto = db.TipoQuarto.Find(id);
                db.TipoQuarto.Remove(tipoquarto);
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
