using HORTIQUERY.DOMAIN.INTERFACE.APP;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.RESULT;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.MODEL.EXTENSION;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.APP
{
    public class UnitQueryApp : IUnitQueryApp
    {
        private readonly IUnitRepository _unitRepository;

        public UnitQueryApp(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<IEnumerable<IUnitResult>> GetFullListOfUnits()
        {
            return (await _unitRepository.FullListOfUnits()).GetListOfUnitResult();
        }

        public async Task<IEnumerable<IUnitResult>> GetListOfUnits(IUnitQuerySignature signature)
        {
            return (await _unitRepository.ListOfUnits(signature)).GetListOfUnitResult();
        }

        public async Task<IUnitResult> GetUnitByIdOrName(IUnitQuerySignature signature)
        {
            return (await _unitRepository.UnitByIdOrName(signature)).GetUnitResult();
        }
    }
}
