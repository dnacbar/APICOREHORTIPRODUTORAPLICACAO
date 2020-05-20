using APPCOREHORTIQUERY.CONVERTER;
using APPCOREHORTIQUERY.IAPP;
using APPDTOCOREHORTIQUERY.RESULT;
using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTIQUERY.IQUERIES;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APPCOREHORTIQUERY.APP
{
    public class UnitQueryApp : IUnitQueryApp
    {
        private readonly IUnitRepository _unitRepository;

        public UnitQueryApp(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public async Task<IEnumerable<UnitResult>> GetFullListOfUnits()
        {
            return (await _unitRepository.FullListOfUnits()).ToHashSetUnitResult();
        }

        public Task<IEnumerable<UnitResult>> GetListOfUnits(ConsultUnitSignature signature)
        {
            throw new NotImplementedException();
        }

        public Task<UnitResult> GetUnitById(ConsultUnitSignature signature)
        {
            throw new NotImplementedException();
        }
    }
}
