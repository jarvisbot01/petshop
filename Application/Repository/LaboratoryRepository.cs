using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class LaboratoryRepository : GenericRepository<Laboratory>, ILaboratory
    {
        private readonly PetShopContext _context;

        public LaboratoryRepository(PetShopContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Laboratory>> GetAllAsync()
        {
            return await _context.Laboratories.ToListAsync();
        }

        public override async Task<Laboratory> GetByIdAsync(int id)
        {
            return await _context.Laboratories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRecords, IEnumerable<Laboratory> records)> GetAllAsync(
            int pageIndex,
            int pageSize,
            string search
        )
        {
            var query = _context.Laboratories as IQueryable<Laboratory>;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRecords = await query.CountAsync();
            var records = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRecords, records);
        }

        public async Task<IEnumerable<Laboratory>> Consulta2A()
        {
            var laboratories = await (
                from l in _context.Laboratories
                where l.Name.Contains("Mk")
                select new Laboratory
                {
                    Name = l.Name,
                    Address = l.Address,
                    Phone = l.Phone,
                    Medications = l.Medications
                }
            ).ToListAsync();
            return laboratories;
        }
    }
}
