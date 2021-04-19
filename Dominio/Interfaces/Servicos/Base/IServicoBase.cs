using prmToolkit.NotificationPattern;

namespace Dominio.Interfaces.Servicos.Base
{
    public interface IServicoBase<in TRequest, out TResponse> : INotifiable { }
}
