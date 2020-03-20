using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Repositories;

namespace HolidaysCalendar.DAL.Repositories
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(HolidaysCalendarDbContext context) : base(context)
        { }
        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await HolidaysCalendarDbContext.Statuses
                .Include(status => status.Requests)
                .ToListAsync();
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await HolidaysCalendarDbContext.Statuses
                .Include(status => status.Requests)
                .SingleOrDefaultAsync(status => status.Id == id);
        }

        private HolidaysCalendarDbContext HolidaysCalendarDbContext
        {
            get { return Context as HolidaysCalendarDbContext; }
        }
    }
}