using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA06.entities;

namespace TA06.repositories
{
    class EcosistemaRepository
    {
        private static List<Ecosistema> ecosistemas = new List<Ecosistema>();

        public bool Existe(String id)
        {
            return ecosistemas.Exists(ecosistemas => ecosistemas.Id.Equals(id));
        }

        public void Registrar(Ecosistema ecosistema)
        {
            ecosistemas.Add(ecosistema);
        }

        public static List<Ecosistema> ListarTodo()
        {
            return ecosistemas;
        }
    }
}
