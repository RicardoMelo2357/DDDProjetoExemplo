using Dominio.Entidades.Base;
using Dominio.Interfaces.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infra.Persistencia.Repositorios.Base
{
    public class RepositorioBase<TEntidade, TId> : IRepositorioBase<TEntidade, TId>
         where TEntidade : EntidadeBase
         where TId : struct
    {
        private readonly DbContext _context;

        public RepositorioBase(DbContext context) => _context = context;
        public TEntidade Adicionar(TEntidade entidade) => _context.Set<TEntidade>().Add(entidade);
        public IEnumerable<TEntidade> AdicionarLista(IEnumerable<TEntidade> entidades) => _context.Set<TEntidade>().AddRange(entidades);
        public void Remover(TEntidade entidade) => _context.Set<TEntidade>().Remove(entidade);
        public TEntidade Editar(TEntidade entidade) { _context.Entry(entidade).State = System.Data.Entity.EntityState.Modified; return entidade; }
        public bool Existe(Func<TEntidade, bool> where) => _context.Set<TEntidade>().Any(where);
        public IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties) => Listar(includeProperties).Where(where);
        public IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties) =>
           ascendente ? ListarPor(where, includeProperties).OrderBy(ordem) : ListarPor(where, includeProperties).OrderByDescending(ordem);
        public IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties)
            => ascendente ? Listar(includeProperties).OrderBy(ordem) : Listar(includeProperties).OrderByDescending(ordem);
        public TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties) => Listar(includeProperties).FirstOrDefault(where);

        public TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            if (includeProperties.Any())
                return Listar(includeProperties).FirstOrDefault(x => x.Id.ToString() == id.ToString());

            return _context.Set<TEntidade>().Find(id);
        }

        public IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            IQueryable<TEntidade> query = _context.Set<TEntidade>();

            if (includeProperties.Any())
            {
                return Include(_context.Set<TEntidade>(), includeProperties);
            }

            return query;
        }

        private IQueryable<TEntidade> Include(IQueryable<TEntidade> query, params Expression<Func<TEntidade, object>>[] includeProperties)
        {
            foreach (var property in includeProperties)
            {
                query = query.Include(property);
            }

            return query;
        }
    }
}
