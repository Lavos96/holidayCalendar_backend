using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Repositories;

namespace HolidaysCalendar.DAL.Repositories
{
    public class TypeRepository : Repository<Type>, ITypeRepository
    {
        public TypeRepository(HolidaysCalendarDbContext context) : base(context)
        { }
        public async Task<IEnumerable<Type>> GetAllTypesAsync()
        {
            return await HolidaysCalendarDbContext.Types
                .Include(type => type.Requests)
                .ToListAsync();
        }

        public async Task<Type> GetTypeByIdAsync(int id)
        {
            return await HolidaysCalendarDbContext.Types
                .Include(type => type.Requests)
                .SingleOrDefaultAsync(type => type.Id == id);
        }
        private HolidaysCalendarDbContext HolidaysCalendarDbContext
        {
            get { return Context as HolidaysCalendarDbContext; }
        }
    }
}