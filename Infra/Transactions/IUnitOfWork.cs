namespace Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
