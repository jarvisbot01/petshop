using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ILaboratory : IGeneric<Laboratory>
    {
        Task<IEnumerable<Laboratory>> Consulta2A();
    }
}
