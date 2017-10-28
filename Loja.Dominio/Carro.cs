using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Carro
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Cor { get; set; }


        void InstanciarCarro()
        {
            var meuCarro = new Carro();
            meuCarro.Cor = "vermelho";
            meuCarro.Marca = "Ford";
            meuCarro.Modelo = "Ka";

            var carroAntonio = new Carro {
                Cor = "Azul",
                Marca = "GM",
                Modelo = "Cobalt"
            };

        }
    }
}
