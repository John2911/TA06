using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA06.entities;
using TA06.repositories;

namespace TA06.services
{
    class AnimalService
    {
        private AnimalRepository animalRepository = new AnimalRepository();

        public bool Registrar(String id, Animal animal)
        {
            if(animalRepository.Existe(animal.Codigo))
            {
                return false;
            }
            else
            {
                animalRepository.Registrar(id, animal);
                return true;
            }
        }

        public List<Animal> ListarTodo(String id)
        {
            return animalRepository.ListarTodo(id);
        }
    }
}
