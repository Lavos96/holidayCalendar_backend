using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Repositories
{
    public interface ITypeRepository : IRepository<Type>
    {
        // Get all types with requests async
        Task<IEnumerable<Type>> GetAllTypesAsync();
        // Get type with requests by id async
        Task<Type> GetTypeByIdAsync(int id);
    }
}