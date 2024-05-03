using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TA06.entities;
using TA06.repositories;

namespace TA06.services
{
    class EcosistemaService
    {
        private EcosistemaRepository ecosistemaRepository = new EcosistemaRepository();

        public bool Registrar(Ecosistema ecosistema)
        {
            if(ecosistemaRepository.Existe(ecosistema.Id))
            {
                return false;
            }
            else
            {
                ecosistemaRepository.Registrar(ecosistema);
                return true;
            }
        }

        public List<Ecosistema> ListarTodo()
        {
            return EcosistemaRepository.ListarTodo();
        }
    }
}
