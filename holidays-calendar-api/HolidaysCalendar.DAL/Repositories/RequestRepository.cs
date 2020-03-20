using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Repositories;

namespace HolidaysCalendar.DAL.Repositories
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(HolidaysCalendarDbContext context) : base(context)
        { }
        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await HolidaysCalendarDbContext.Requests
                .Include(request => request.Type)
                .Include(request => request.Status)
                .ToListAsync();;
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByTypeIdAsync(int typeId)
        {
            return await HolidaysCalendarDbContext.Requests
                .Include(request => request.Type)
                .Include(request => request.Status)
                .Where(request => request.TypeId == typeId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequestsByStatusIdAsync(int statusId)
        {
            return await HolidaysCalendarDbContext.Requests
                .Include(request => request.Type)
                .Include(request => request.Status)
                .Where(request => request.StatusId == statusId)
                .ToListAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            return await HolidaysCalendarDbContext.Requests
                .Include(request => request.Type)
                .Include(request => request.Status)
                .SingleOrDefaultAsync(request => request.Id == id);
        }

        private HolidaysCalendarDbContext HolidaysCalendarDbContext
        {
            get { return Context as HolidaysCalendarDbContext; }
        }
    }
}