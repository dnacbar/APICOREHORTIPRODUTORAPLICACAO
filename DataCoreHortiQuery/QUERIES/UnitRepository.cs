using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DOMAINCOREHORTICOMMAND;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class UnitRepository : IUnitRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;
        public UnitRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<IEnumerable<Unit>> ListOfUnits()
        {
            var listOfUnits = new List<Unit>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfUnits = await dBHORTICONTEXT.Unit
                                               .OrderBy(x => x.IdUnit)
                                               .Select(x => new Unit
                                               {
                                                   IdUnit = x.IdUnit,
                                                   DsUnit = x.DsUnit,
                                                   DsAbreviation = x.DsAbreviation
                                               })
                                               .AsNoTracking()
                                               .OrderBy(x => x.DsUnit)
                                               .ToListAsync();
                }
                scope.Complete();
            }
            return listOfUnits;
        }

        public async Task<IEnumerable<Unit>> ListOfUnitsByName(ConsultUnitSignature signature)
        {
            var listOfUnits = new List<Unit>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfUnits = await dBHORTICONTEXT.Unit
                                               .OrderBy(x => x.IdUnit)
                                               .Select(x => new Unit
                                               {
                                                   IdUnit = x.IdUnit,
                                                   DsUnit = x.DsUnit,
                                                   DsAbreviation = x.DsAbreviation
                                               })
                                               .AsNoTracking()
                                               .OrderBy(x => x.DsUnit)
                                               .Where(x => x.DsUnit.Contains(signature.DsUnit))
                                               .Take(signature.Quantity)
                                               .ToListAsync();
                }
                scope.Complete();
            }
            return listOfUnits;
        }

        public async Task<Unit> UnitById(ConsultUnitSignature signature)
        {
            var unit = new Unit();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    unit = await dBHORTICONTEXT.Unit
                                               .OrderBy(x => x.IdUnit)
                                               .Select(x => new Unit
                                               {
                                                   IdUnit = x.IdUnit,
                                                   DsUnit = x.DsUnit,
                                                   DsAbreviation = x.DsAbreviation
                                               })
                                               .AsNoTracking()
                                               .FirstOrDefaultAsync(x => x.IdUnit == signature.IdUnit);
                }
                scope.Complete();
            }
            return unit;
        }
    }
}
