using Loja.Dominio;
using Loja.Mvc.Helpers;
using Loja.Repositories.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Controllers
{
    using System.Security.Claims;
    using System.Web.Mvc;

    [Authorize(Roles = "Administrador, Leiloeiro, Comprador")]
    public class LeiloesController : Controller
    {
        private LojaDbContext _db = new LojaDbContext();

        [AllowAnonymous]
        // GET: Vendas/Leiloes
        public ActionResult Index()
        {
            return View(Mapeamento.Mapear(_db.Produtos.Where(x => x.EmLeilao).ToList()));
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var usuario = (ClaimsIdentity)User.Identity;

            var leilao = Modulo.Leilao.ToString();
            var detalhar = Acao.Detalhar.ToString();

            if (!usuario.HasClaim(leilao, detalhar))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }

            Produto produto = _db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapeamento.Mapear(produto));
        }
    }
}