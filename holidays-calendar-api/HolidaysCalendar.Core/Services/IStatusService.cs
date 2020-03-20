using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Services
{
    public interface IStatusService
    {
        Task<IEnumerable<Status>> GetAllStatuses();
        Task<Status> GetStatusById(int id);
        Task<Status> CreateStatus(Status newStatus);
        Task UpdateStatus(Status statusToBeUpdated, Status status);
        Task DeleteStatus(Status status);
    }
}