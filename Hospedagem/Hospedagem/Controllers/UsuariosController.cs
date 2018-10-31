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
    public class UsuariosController : Controller
    {
        private HospedagemBDEntities db = new HospedagemBDEntities();

        public ActionResult Index()
        {
            return View(db.Usuario.ToList());
        }
        public ActionResult Detalhes(int id)
        {
            return View(db.Usuario.ToList().Find(x => x.IDUsuario == id));
        }
        public ActionResult Inserir()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Inserir(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        public ActionResult Alterar(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Alterar(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        public ActionResult Excluir(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            return View(usuario);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult EfetuarExclusao(int id)
        {
            try
            {
                Usuario usuario = db.Usuario.Find(id);
                db.Usuario.Remove(usuario);
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
