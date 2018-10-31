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
    public class CategoriasController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.Categoria.ToList());
        }

        public ActionResult Detalhes(int id) { 
            return View(db.Categoria.ToList().Find(x => x.IDCategoria == id ));
        }
        public ActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categoria.Add(categoria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Alterar(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            return View(categoria);
        }
        [HttpPost]
        public ActionResult Alterar(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Excluir(int id)
        {
            Categoria categoria = db.Categoria.Find(id);
            return View(categoria);
        }
        [HttpPost,ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Categoria categoria = db.Categoria.Find(id);
                db.Categoria.Remove(categoria);
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
