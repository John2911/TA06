using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA06.entities;

namespace TA06.repositories
{
    class AnimalRepository
    {
        public bool Existe(String codigo)
        {
            List<Ecosistema> ecosistemas = EcosistemaRepository.ListarTodo();
            return ecosistemas.Exists(e => e.Animales.Exists(a => a.Codigo.Equals(codigo)));
        }

        public void Registrar(String id, Animal animal)
        {
            List<Ecosistema> ecosistemas = EcosistemaRepository.ListarTodo();
            Ecosistema ecosistema = ecosistemas.Find(e => e.Id.Equals(id));
            ecosistema.Animales.Add(animal);
        }

        public List<Animal> ListarTodo(String id)
        {
            List<Ecosistema> ecosistemas = EcosistemaRepository.ListarTodo();
            Ecosistema ecosistema = ecosistemas.Find(e => e.Id.Equals(id));
            return ecosistema.Animales;
        }
    }
}
