using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMedication : IGeneric<Medication>
    {
        Task<IEnumerable<Medication>> Consulta5A();
    }
}
