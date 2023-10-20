using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IOwner : IGeneric<Owner>
    {
        Task<IEnumerable<Owner>> Consulta4A();
        Task<object> Consulta5B();
    }
}
