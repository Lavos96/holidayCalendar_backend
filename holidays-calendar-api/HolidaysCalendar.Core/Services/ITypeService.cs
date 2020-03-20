using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core.Models;

namespace HolidaysCalendar.Core.Services
{
    public interface ITypeService
    {
        Task<IEnumerable<Type>> GetAllTypes();
        Task<Type> GetTypeById(int id);
        Task<Type> CreateType(Type newType);
        Task UpdateType(Type typeToBeUpdated, Type type);
        Task DeleteType(Type type);
    }
}