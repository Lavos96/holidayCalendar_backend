using System;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Repositories;

namespace HolidaysCalendar.Core
{
    // we use repositories pattern in the project 
    // https://codewithshadman.com/repository-pattern-csharp/#unit-of-work-pattern-csharp
    // therefore, we need to use the unit of work class to coordinate updates on individual units as a whole
    public interface IUnitOfWork : IDisposable
    {
        IRequestRepository Requests { get; }
        ITypeRepository Types { get; }
        IStatusRepository Statuses { get; }
        Task<int> CommitAsync();
    }
}