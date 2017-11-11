using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Loja.Mvc.Helpers
{
    public class CultureHelper
    {
        public const string LinguagemPadrao = "pt-BR";

        public string Abreviacao { get; private set; }
        public CultureInfo CultureInfo { get; private set; }
        public string NomeNativo { get; private set; }

        private List<string> LinguagensSuportadas { get; } 
            = new List<string>
            {
                LinguagemPadrao, "es", "en"
            };

        public CultureHelper()
        {
            ObterRegiao();
        }

        private void ObterRegiao()
        {
            var linguagem = LinguagemPadrao;
            var linguagemSelecionada = HttpContext.Current.Request.Cookies[Cookie.LinguagemSelecionada];

            if(linguagemSelecionada != null && LinguagensSuportadas.Contains(linguagemSelecionada.Value))
            {
                linguagem = linguagemSelecionada.Value;
            }

            var specificCulture = CultureInfo.CreateSpecificCulture(linguagem);
            this.CultureInfo = specificCulture;
            var region = new RegionInfo(specificCulture.LCID);

            NomeNativo = region.NativeName;

            Abreviacao = region.TwoLetterISORegionName.ToLower();
        }
    }
}