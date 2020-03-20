using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Repositories
{
    public interface IStatusRepository : IRepository<Status>
    {
         // Get all statuses with requests async
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        // Get status with requests by id async
        Task<Status> GetStatusByIdAsync(int id);
    }
}