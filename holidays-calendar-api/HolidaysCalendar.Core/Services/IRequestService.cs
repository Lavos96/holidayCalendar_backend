using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Services
{
    public interface IRequestService
    {
        // Get all requests with type and status
        Task<IEnumerable<Request>> GetAllRequests();
        // Get all requests for current user
        Task<IEnumerable<Request>> GetAllRequestsByEmail(string email);
        // Get request by id
        Task<Request> GetRequestById(int id);
        // get all requests by type id
        Task<IEnumerable<Request>> GetRequestsByTypeId(int typeId);
        // get all requests by status id
        Task<IEnumerable<Request>> GetRequestsByStatusId(int statusId);
        Task<Request> CreateRequest(Request newRequest);
        Task UpdateRequest(Request requestToBeUpdated, Request request);
        Task DeleteRequest(Request request);
    }
}