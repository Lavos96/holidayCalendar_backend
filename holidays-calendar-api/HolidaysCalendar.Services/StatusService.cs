using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Services;

namespace HolidaysCalendar.Services
{
    public class StatusService : IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatusService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Status> CreateStatus(Status newStatus)
        {
            await _unitOfWork.Statuses
                .AddAsync(newStatus);
            
            return newStatus;
        }

        public async Task DeleteStatus(Status status)
        {
            _unitOfWork.Statuses.Remove(status);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Status>> GetAllStatuses()
        {
            return await _unitOfWork.Statuses.GetAllAsync();
        }

        public async Task<Status> GetStatusById(int id)
        {
            return await _unitOfWork.Statuses.GetByIdAsync(id);
        }

        public async Task UpdateStatus(Status statusToBeUpdated, Status status)
        {
            statusToBeUpdated.Name = status.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}