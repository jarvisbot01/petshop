using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class VetRepository : GenericRepository<Vet>, IVet
    {
        private readonly PetShopContext _context;

        public VetRepository(PetShopContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Vet>> GetAllAsync()
        {
            return await _context.Vets.ToListAsync();
        }

        public override async Task<Vet> GetByIdAsync(int id)
        {
            return await _context.Vets.FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRecords, IEnumerable<Vet> records)> GetAllAsync(
            int pageIndex,
            int pageSize,
            string search
        )
        {
            var query = _context.Vets as IQueryable<Vet>;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRecords = await query.CountAsync();
            var records = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRecords, records);
        }

        public async Task<IEnumerable<Vet>> Consulta1A()
        {
            var vets = await (
                from v in _context.Vets
                where v.Specialty.Contains("Cirujano vascular")
                select new Vet
                {
                    Name = v.Name,
                    Email = v.Email,
                    Phone = v.Phone,
                    Specialty = v.Specialty,
                    Appointments = new List<Appointment>()
                }
            ).ToListAsync();
            return vets;
        }
    }
}
