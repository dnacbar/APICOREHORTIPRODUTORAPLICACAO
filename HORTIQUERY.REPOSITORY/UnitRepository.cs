using HORTI.CORE.CROSSCUTTING.DBBASEEF;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class UnitRepository : _BaseEFQueryRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public Task<List<Unit>> ListOfUnits(IUnitQuerySignature signature)
        {
            return ListOfEntity(Where: x => (signature.DsUnit == null || signature.DsUnit.Contains(x.DsUnit)),
                Select: p => new Unit
                {
                    IdUnit = p.IdUnit,
                    DsUnit = p.DsUnit,
                    DsAbreviation = p.DsAbreviation
                },
                Page: signature.Page,
                Quantity: signature.Quantity,
                OrderBy: o => o.IdUnit);
        }

        public Task<List<Unit>> FullListOfUnits()
        {
            return FullListOfEntity(Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            },
            OrderBy: p => p.DsUnit);
        }

        public Task<Unit> UnitByIdOrName(IUnitQuerySignature signature)
        {
            return EntityByFilter(Where: x => x.IdUnit == signature.Id || x.DsUnit == signature.DsUnit,
            Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            });
        }
    }
}
