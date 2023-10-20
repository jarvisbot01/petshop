using Persistence;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class PetRepository : GenericRepository<Pet>, IPet
    {
        private readonly PetShopContext _context;

        public PetRepository(PetShopContext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _context.Pets.ToListAsync();
        }

        public override async Task<Pet> GetByIdAsync(int id)
        {
            return await _context.Pets.FirstOrDefaultAsync(p => p.Id == id);
        }

        public override async Task<(int totalRecords, IEnumerable<Pet> records)> GetAllAsync(
            int pageIndex,
            int pageSize,
            string search
        )
        {
            var query = _context.Pets as IQueryable<Pet>;

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(search));
            }

            query = query.OrderBy(p => p.Id);
            var totalRecords = await query.CountAsync();
            var records = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return (totalRecords, records);
        }

        public async Task<IEnumerable<Pet>> Consulta3A()
        {
            var pets = await (
                from m in _context.Pets
                join r in _context.Breeds on m.BreedId equals r.Id
                join p in _context.Owners on m.OwnerId equals p.Id
                join e in _context.Species on r.SpeciesId equals e.Id
                where e.Name.Contains("felina")
                select new Pet
                {
                    Name = m.Name,
                    Owner = p,
                    Birthdate = m.Birthdate,
                    Breed = new Breed { Name = r.Name },
                    Species = new Species { Name = e.Name }
                }
            ).ToListAsync();
            return pets;
        }
    }
}
