using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IComputadorRepository
    {
        int Inserir(Computador computador);

        bool Alterar(Computador computador);

        List<Computador> ObterTodos();

        Computador ObterPeloId(int id);

        bool Apagar(int id);
    }
}