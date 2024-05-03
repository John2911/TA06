using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TA06.entities
{
    class Ecosistema
    {
        public Ecosistema() { }
        public String Id { get; set; }
        public String Nombre { get; set; }
        public double Area { get; set; }
        public int Aforo { get; set; }
        public List<Animal> Animales { get; set; }
    }
}
