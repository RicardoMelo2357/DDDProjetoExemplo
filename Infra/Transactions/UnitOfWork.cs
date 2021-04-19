using Infra.Persistencia;

namespace Infra.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Contexto _context;

        public UnitOfWork(Contexto context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
