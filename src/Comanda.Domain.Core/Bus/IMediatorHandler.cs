using System.Threading.Tasks;
using Comanda.Domain.Core.Commands;
using Comanda.Domain.Core.Events;


namespace Comanda.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
