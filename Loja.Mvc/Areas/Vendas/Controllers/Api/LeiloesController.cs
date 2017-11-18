using Loja.Mvc.Helpers;
using Loja.Repositories.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Mvc;

namespace Loja.Mvc.Areas.Vendas.Controllers.Api
{
    public class LeiloesController : ApiController
    {
        private LojaDbContext _db = new LojaDbContext();

        public IHttpActionResult Get()
        {
            return Ok(
                Mapeamento.Mapear(_db.Produtos.Where(x => x.EmLeilao).ToList())
                );
        }

        public IHttpActionResult Post(FormDataCollection form)
        {
            //TODO: providenciar classe leilao e tabela.
            return CreatedAtRoute("Vendas_DefaultApi", 
                new { id = form["lote"]}, form);
        }
    }
}
