using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IVet : IGeneric<Vet>
    {
        Task<IEnumerable<Vet>> Consulta1A();
    }
}
