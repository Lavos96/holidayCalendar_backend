using System.Collections.Generic;
using System.Threading.Tasks;
using HolidaysCalendar.Core;
using HolidaysCalendar.Core.Models;
using HolidaysCalendar.Core.Services;

namespace HolidaysCalendar.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TypeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<Type> CreateType(Type newType)
        {
            await _unitOfWork.Types
                .AddAsync(newType);
            
            return newType;
        }

        public async Task DeleteType(Type type)
        {
            _unitOfWork.Types.Remove(type);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Type>> GetAllTypes()
        {
            return await _unitOfWork.Types.GetAllAsync();
        }

        public async Task<Type> GetTypeById(int id)
        {
            return await _unitOfWork.Types.GetByIdAsync(id);
        }

        public async Task UpdateType(Type typeToBeUpdated, Type type)
        {
            typeToBeUpdated.Name = type.Name;

            await _unitOfWork.CommitAsync();
        }
    }
}