using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class UnitRepository : _BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IEnumerable<Unit>> ListOfUnits(IUnitQuerySignature signature)
        {
            return await ListOfEntities(Where: x => (signature.DsUnit == null || signature.DsUnit.Contains(x.DsUnit)),
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

        public async Task<IEnumerable<Unit>> FullListOfUnits()
        {
            return await FullListOfEntities(Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            },
            OrderBy: p => p.DsUnit);
        }

        public async Task<Unit> UnitById(IUnitQuerySignature signature)
        {
            return await EntityByFilter(Where: x => x.IdUnit == signature.Id,
            Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            });
        }
    }
}
