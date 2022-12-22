using efrete.Core.DomainObjects;

namespace efrete.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {

    }
}