using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorGaleria.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

        public string Senha { get; set; }
    }
}