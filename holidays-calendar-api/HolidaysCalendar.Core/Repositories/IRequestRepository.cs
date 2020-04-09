
using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Repositories
{
    public interface IRequestRepository : IRepository<Request>
    {
        // Get all requests with type and status async
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        // Get request with type and status by id Async
        Task<Request> GetRequestByIdAsync(int id);
        // Get all requests for current user Async
        Task<Request> GetAllRequestsByEmailAsync(string email);
        // Get all requests with type and status by type id async
        Task<IEnumerable<Request>> GetAllRequestsByTypeIdAsync(int typeId);
        // Get all requests with type and status by status id async
        Task<IEnumerable<Request>> GetAllRequestsByStatusIdAsync(int statusId);
    }
}