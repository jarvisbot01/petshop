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

        public async Task<IEnumerable<Pet>> Consulta6A()
        {
            var firstQuarterStart = new DateTime(2023, 1, 1, 0, 0, 0);
            var firstQuarterEnd = new DateTime(2023, 3, 31, 23, 59, 59);

            var pets = await _context.Pets
                .Include(p => p.Appointments)
                .Where(
                    p =>
                        p.Appointments.Any(
                            a =>
                                a.AppointmentDate >= firstQuarterStart
                                && a.AppointmentDate <= firstQuarterEnd
                                && a.Description == "Vacunacion"
                        )
                )
                .ToListAsync();
            return pets;
        }

        public async Task<IEnumerable<Pet>> Consulta1B()
        {
            var pet = await (
                from m in _context.Pets
                join r in _context.Breeds on m.BreedId equals r.Id
                select new Pet
                {
                    Name = m.Name,
                    Birthdate = m.Birthdate,
                    BreedId = m.BreedId,
                    Breed = new Breed
                    {
                        Name = r.Name,
                        SpeciesId = r.SpeciesId,
                        Species = new Species { Name = r.Species.Name }
                    }
                }
            ).ToListAsync();
            return pet;
        }

        public async Task<object> Consulta3B()
        {
            var consulta =
                from e in _context.Appointments
                join v in _context.Vets on e.VetId equals v.Id
                select new
                {
                    vet = v.Name,
                    pets = (
                        from a in _context.Appointments
                        join m in _context.Pets on a.PetId equals m.Id
                        where a.VetId == v.Id
                        select new { Name = m.Name, Birthdate = m.Birthdate, }
                    ).ToList()
                };

            var result = await consulta.ToListAsync();
            return result;
        }

        public async Task<object> Consulta6B()
        {
            var query =
                from r in _context.Breeds
                select new
                {
                    Name = r.Name,
                    Quantity = _context.Pets.Count(m => m.BreedId == r.Id)
                };

            var result = await query.ToListAsync();
            return result;
        }
    }
}
