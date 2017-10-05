using System;
using System.Collections.Generic;

namespace Loteria.Modelo
{
    public class MegaSena
    {
        public int id { get; set; }
        public List<int> valores { get; set; }
        public DateTime DataHora { get; set; }
        public int acerto { get; set; }
    }
}