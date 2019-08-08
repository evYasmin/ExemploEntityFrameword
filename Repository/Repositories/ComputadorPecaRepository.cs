using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ComputadorPecaRepository : IComputadorPecaRepository
    {
        private SistemaContext context;
        public ComputadorPecaRepository(SistemaContext context)
        {
            this.context = context;
        }
        public bool Apagar(int idComputadorPeca)
        {
            var computadores = context.ComputadoresPecas.FirstOrDefault(x => x.Id == idComputadorPeca);
            computadores.RegistroAtivo = false;
            context.Update(computadores);
            return context.SaveChanges() == 1;
        }

        public ComputadorPeca ObterPeloId(int id)
        {
            return context.ComputadoresPecas.FirstOrDefault(x => x.Id == id);
        }

        public List<ComputadorPeca> ObterTodosPeloIdComputador(int idComputador)
        {
            return context.ComputadoresPecas.Where(x => x.idComputador == idComputador).ToList();
        }

        public int Relacionar(ComputadorPeca computadorPeca)
        {
            context.ComputadoresPecas.Add(computadorPeca);
            context.SaveChanges();
            return computadorPeca.Id;
        }
    }
}
