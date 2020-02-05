using DomainCoreHortiCommand;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataCoreHortiQuery.IQUERIES
{
    public interface IDiscrictRepository
    {
        Task<IEnumerable<District>> GetDistricts();
        Task<IEnumerable<District>> GetDistricts(int idPage, int idSize);
        Task<District> GetDistrict(Guid idDistrict);
        void Dispose();
    }
}
