using APPDTOCOREHORTIQUERY.SIGNATURE;
using DATACOREHORTICOMMAND;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class UnitRepository : _BaseRepository<Unit>, IUnitRepository
    {
        public UnitRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IEnumerable<Unit>> ListOfUnits(ConsultUnitSignature signature)
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
                OrderBy: x => x.IdUnit);
        }

        public async Task<IEnumerable<Unit>> FullListOfUnits()
        {
            return await FullListOfEntities(Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            },
            OrderBy: x => x.DsUnit);
        }

        public async Task<Unit> UnitById(ConsultUnitSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdUnit == signature.IdUnit,
            Select: x => new Unit
            {
                IdUnit = x.IdUnit,
                DsUnit = x.DsUnit,
                DsAbreviation = x.DsAbreviation
            });
        }
    }
}
