using System.Threading.Tasks;
using HolidaysCalendar.Core;
using HolidaysCalendar.Core.Repositories;
using HolidaysCalendar.DAL.Repositories;

namespace HolidaysCalendar.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HolidaysCalendarDbContext _context;
        private RequestRepository _requestRepository;
        private TypeRepository _typeRepository;
        private StatusRepository _statusRepository;

        public UnitOfWork(HolidaysCalendarDbContext context)
        {
            this._context = context;
        }

        public IRequestRepository Requests => _requestRepository = _requestRepository ?? new RequestRepository(_context);

        public ITypeRepository Types => _typeRepository = _typeRepository ?? new TypeRepository(_context);

        public IStatusRepository Statuses => _statusRepository = _statusRepository ?? new StatusRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}