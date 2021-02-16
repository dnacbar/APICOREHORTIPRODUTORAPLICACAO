using HORTIQUERY.DOMAIN.MODEL.SIGNATURE;
using HORTICOMMAND.REPOSITORY;
using DATACOREHORTIQUERY.IQUERIES;
using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DATACOREHORTIQUERY.QUERIES
{
    public sealed class ProducerRepository : _BaseRepository<IProducer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IEnumerable<IProducer>> FullListOfProducers()
        {
            return await FullListOfEntities(Select: x => new IProducer
            {
                IdProducer = x.IdProducer,
                DsProducer = x.DsProducer,
                DsFantasyname = x.DsFantasyname,
                DsEmail = x.DsEmail,
                DsPhone = x.DsPhone,
                DsAddress = x.DsAddress,
                DsZip = x.DsZip,
                DsComplement = x.DsComplement,
                DsNumber = x.DsNumber,
                DsDescription = x.DsDescription,
                DsFederalInscription = x.DsFederalInscription,
                DsStateInscription = x.DsStateInscription,
                DsMunicipalInscription = x.DsMunicipalInscription,
                IdCityNavigation = new ICity
                {
                    IdCity = x.IdCityNavigation.IdCity,
                    DsCity = x.IdCityNavigation.DsCity,
                    Id = new IState
                    {
                        IdState = x.IdCityNavigation.Id.IdState,
                        DsState = x.IdCityNavigation.Id.DsState,
                        DsUf = x.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new IDistrict
                {
                    IdDistrict = x.IdDistrictNavigation.IdDistrict,
                    DsDistrict = x.IdDistrictNavigation.DsDistrict
                }
            },
            OrderBy: p => p.DsProducer);
        }

        public async Task<IEnumerable<IProducer>> ListOfProducers(ConsultProducerSignature signature)
        {
            return await ListOfEntities(Where: x => (signature.IdProducer == null || signature.IdProducer == x.IdProducer)
                                                 && (signature.DsEmail == null || signature.DsEmail.Contains(x.DsEmail)),
                                        Select: p => new IProducer
                                        {
                                            IdProducer = p.IdProducer,
                                            DsProducer = p.DsProducer,
                                            DsFantasyname = p.DsFantasyname,
                                            DsEmail = p.DsEmail,
                                            DsPhone = p.DsPhone,
                                            DsAddress = p.DsAddress,
                                            DsZip = p.DsZip,
                                            DsComplement = p.DsComplement,
                                            DsNumber = p.DsNumber,
                                            DsDescription = p.DsDescription,
                                            DsFederalInscription = p.DsFederalInscription,
                                            DsStateInscription = p.DsStateInscription,
                                            DsMunicipalInscription = p.DsMunicipalInscription,
                                            IdCityNavigation = new ICity
                                            {
                                                IdCity = p.IdCityNavigation.IdCity,
                                                DsCity = p.IdCityNavigation.DsCity,
                                                Id = new IState
                                                {
                                                    IdState = p.IdCityNavigation.Id.IdState,
                                                    DsState = p.IdCityNavigation.Id.DsState,
                                                    DsUf = p.IdCityNavigation.Id.DsUf
                                                }
                                            },
                                            IdDistrictNavigation = new IDistrict
                                            {
                                                IdDistrict = p.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = p.IdDistrictNavigation.DsDistrict
                                            }
                                        },
                                        Page: signature.Page,
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsProducer);
        }

        public async Task<IProducer> ProducerByIdOrEmail(ConsultProducerSignature signature)
        {
            return await EntityByFilter(Where: x => x.IdProducer == signature.IdProducer || x.DsEmail == signature.DsEmail,
            Select: p => new IProducer
            {
                IdProducer = p.IdProducer,
                DsProducer = p.DsProducer,
                DsFantasyname = p.DsFantasyname,
                DsEmail = p.DsEmail,
                DsPhone = p.DsPhone,
                DsAddress = p.DsAddress,
                DsZip = p.DsZip,
                DsComplement = p.DsComplement,
                DsNumber = p.DsNumber,
                DsDescription = p.DsDescription,
                DsFederalInscription = p.DsFederalInscription,
                DsStateInscription = p.DsStateInscription,
                DsMunicipalInscription = p.DsMunicipalInscription,
                IdCityNavigation = new ICity
                {
                    IdCity = p.IdCityNavigation.IdCity,
                    DsCity = p.IdCityNavigation.DsCity,
                    Id = new IState
                    {
                        IdState = p.IdCityNavigation.Id.IdState,
                        DsState = p.IdCityNavigation.Id.DsState,
                        DsUf = p.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new IDistrict
                {
                    IdDistrict = p.IdDistrictNavigation.IdDistrict,
                    DsDistrict = p.IdDistrictNavigation.DsDistrict
                }
            });
        }
    }
}
