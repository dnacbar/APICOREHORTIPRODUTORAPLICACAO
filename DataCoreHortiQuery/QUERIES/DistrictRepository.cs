using APPDTOCOREHORTIQUERY.SIGNATURE;
using DataAccessCoreHortiCommand;
using DATACOREHORTIQUERY.IQUERIES;
using DomainCoreHortiCommand;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace DATACOREHORTIQUERY.QUERIES
{
    public class DistrictRepository : IDiscrictRepository
    {
        private readonly DBHORTICONTEXT dBHORTICONTEXT;

        public DistrictRepository(DBHORTICONTEXT _dBHORTICONTEXT)
        {
            dBHORTICONTEXT = _dBHORTICONTEXT;
        }

        public async Task<IEnumerable<District>> ListOfDistricts()
        {
            var listOfDistricts = new List<District>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {

                    listOfDistricts = await dBHORTICONTEXT.District
                                                          .Select(x => new District
                                                          {
                                                              IdDistrict = x.IdDistrict,
                                                              DsDistrict = x.DsDistrict,
                                                              DtCreation = x.DtCreation,
                                                              DtAtualization = x.DtAtualization,
                                                              BoActive = x.BoActive,
                                                          })
                                                          .AsNoTracking()
                                                          .OrderBy(x => x.DsDistrict).ToListAsync();
                }
                scope.Complete();
            }
            return listOfDistricts;
        }

        public async Task<IEnumerable<District>> ListOfDistrictsByQuantity(ConsultByQuantitySignature signature)
        {
            var listOfDistricts = new List<District>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfDistricts = await dBHORTICONTEXT.District
                                       .Select(x => new District
                                       {
                                           IdDistrict = x.IdDistrict,
                                           DsDistrict = x.DsDistrict,
                                           BoActive = x.BoActive,
                                           DtCreation = x.DtCreation,
                                           DtAtualization = x.DtAtualization
                                       })
                                       .Skip(signature.Page * signature.Quantity)
                                       .Take(signature.Quantity)
                                       .AsNoTracking()
                                       .OrderBy(x => x.DsDistrict).ToListAsync();
                }
                scope.Complete();
            }
            return listOfDistricts;
        }

        public async Task<IEnumerable<District>> ListOfDistrictsByName(ConsultDistrictByIdNameSignature signature)
        {
            var listOfDistricts = new List<District>();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    listOfDistricts = await dBHORTICONTEXT.District
                                       .Select(x => new District
                                       {
                                           IdDistrict = x.IdDistrict,
                                           DsDistrict = x.DsDistrict,
                                           BoActive = x.BoActive,
                                           DtCreation = x.DtCreation,
                                           DtAtualization = x.DtAtualization
                                       })
                                       .AsNoTracking()
                                       .Take(signature.Quantity)
                                       .Where(x => x.DsDistrict.Contains(signature.DsDistrict))
                                       .OrderBy(x => x.DsDistrict).ToListAsync();
                }
                scope.Complete();
            }
            return listOfDistricts;
        }

        public async Task<District> DistrictById(ConsultDistrictByIdNameSignature signature)
        {
            var district = new District();
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted },
                                                    TransactionScopeAsyncFlowOption.Enabled))
            {
                using (dBHORTICONTEXT)
                {
                    district = await dBHORTICONTEXT.District
                                       .Select(x => new District
                                       {
                                           IdDistrict = x.IdDistrict,
                                           DsDistrict = x.DsDistrict,
                                           BoActive = x.BoActive,
                                           DtCreation = x.DtCreation,
                                           DtAtualization = x.DtAtualization
                                       })
                                       .AsNoTracking()
                                       .OrderBy(x => x.DsDistrict)
                                       .FirstOrDefaultAsync(x => x.IdDistrict == signature.IdDistrict);
                }
                scope.Complete();
            }
            return district;
        }
    }
}
