using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPet : IGeneric<Pet>
    {
        Task<IEnumerable<Pet>> Consulta3A();
        Task<IEnumerable<Pet>> Consulta6A();
    }
}
