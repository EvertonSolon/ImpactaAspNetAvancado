using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Repositories.SqlServer.EF;
using Loja.Mvc.Helpers;
using Loja.Mvc.Areas.Vendas.Models;
using log4net;

namespace Loja.Mvc.Areas.Vendas.Controllers
{
    public class ProdutosController : Controller
    {
        private LojaDbContext _db = new LojaDbContext();
        //ILog log = log4net.LogManager.GetLogger(typeof(ProdutosController));
        // GET: Produtos
        public ActionResult Index()
        {
            //log.Debug("Debug message");
            //log.Warn("Warn message");
            //log.Error("Error message");
            //log.Fatal("Fatal message");
            //ViewBag.Title = "Home Page";

            //return View(Mapeamento.Mapear(_db.Produtos.ToList()));
            throw new Exception("Teste");

        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapeamento.Mapear(produto));
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View(Mapeamento.Mapear(new Produto(), _db.Categorias.ToList()));
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produtoVM)
        {
            if (ModelState.IsValid)
            {
                _db.Produtos.Add(Mapeamento.Mapear(produtoVM, _db));
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produtoVM);
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapeamento.Mapear(produto, _db.Categorias.ToList()));
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produtoVM)
        {
            Produto produto;
            Categoria categoria;

            if (ModelState.IsValid)
            {
                produto = _db.Produtos.Find(produtoVM.Id);

                Mapeamento.Mapear(produtoVM, produto, _db);

                //_db.Entry(produto).State = EntityState.Modified;
                //_db.Entry(produto).CurrentValues.SetValues(produtoVM);
                //produto.Categoria = _db.Categorias.Find(produtoVM.CategoriaId);

                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produtoVM);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapeamento.Mapear(produto));
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = _db.Produtos.Find(id);
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
