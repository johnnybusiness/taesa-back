using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorGaleria.Domain
{
    public class Galeria
    {
        public int Id { get; set; }
        public string Concessao { get; set; }

        public string Gallery { get; set; }

        public string Descricao { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public string Elaborador { get; set; }

        public int QtdFotos { get; set; }

        public string ImagemURL { get; set; }

    }
}