using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public SistemaContext context;
        public CategoriaRepository(SistemaContext context)
        {
            this.context = context;
        }

        public bool Alterar(Categoria categoria)
        {
            context.Categorias.Update(categoria);
            //SaveChanges retorna a quantidade de registros
            // que foram afetado no banco de dados 
            return context.SaveChanges() == 1;
        }

        public bool Apagar(int id)
        {
            var categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
                return false;
            categoria.RegistroAtivo = false;
            context.Categorias.Update(categoria);
            return context.SaveChanges() == 1;
        }

        public int Inserir(Categoria categoria)
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return categoria.Id;
        }

        public Categoria ObterPeloId(int id)
        {
            return context.Categorias
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Categoria> ObterTodos(int quantidade, int pagina, string busca, string colunaOrdem, string ordem)
        {
            var query = context.Categorias
                .Where(x => x.Nome.Contains(busca))
                .AsQueryable();
            #region Ordenar
            if (ordem == "ASC")
            {
                switch (colunaOrdem)
                {
                    case "id":
                        query = query.OrderBy(x => x.Id);
                        break;
                    case "nome":
                        query = query.OrderBy(x => x.Nome);
                        break;
                }

                switch (colunaOrdem)
                {
                    case "id":
                        query = query.OrderByDescending(x => x.Id);
                        break;
                    case "nome":
                        query = query.OrderByDescending(x => x.Nome);
                        break;
                }
            }
            #endregion Ordenar

            return query
                .Skip(pagina)
                .Take(quantidade)
                .ToList();
        }
    }
}
