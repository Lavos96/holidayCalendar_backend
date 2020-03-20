using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Services;

namespace HolidaysCalendar.Services
{
    public class RequestService : IRequestService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RequestService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Request> CreateRequest(Request newRequest)
        {
            await _unitOfWork.Requests.AddAsync(newRequest);
            await _unitOfWork.CommitAsync();
            return newRequest;
        }

        public async Task DeleteRequest(Request request)
        {
            _unitOfWork.Requests.Remove(request);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Request>> GetAllRequests()
        {
            return await _unitOfWork.Requests
                .GetAllRequestsAsync();
        }

        public async Task<Request> GetRequestById(int id)
        {
            return await _unitOfWork.Requests
                .GetRequestByIdAsync(id);
        }

        public async Task<IEnumerable<Request>> GetRequestsByStatusId(int statusId)
        {
            return await _unitOfWork.Requests
                .GetAllRequestsByStatusIdAsync(statusId);
        }

        public async Task<IEnumerable<Request>> GetRequestsByTypeId(int typeId)
        {
            return await _unitOfWork.Requests
                .GetAllRequestsByTypeIdAsync(typeId);
        }

        public async Task UpdateRequest(Request requestToBeUpdated, Request request)
        {
            requestToBeUpdated.StartDate = request.StartDate;
            requestToBeUpdated.EndDate = request.EndDate;
            requestToBeUpdated.Reason = request.Reason;
            requestToBeUpdated.Requested = request.Requested;
            requestToBeUpdated.LastChange = request.LastChange;
            requestToBeUpdated.TypeId = request.TypeId;
            requestToBeUpdated.StatusId = request.StatusId;

            await _unitOfWork.CommitAsync();
        }
    }
}