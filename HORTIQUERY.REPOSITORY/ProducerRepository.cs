using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class ProducerRepository : _BaseRepository<Producer>, IProducerRepository
    {
        public ProducerRepository(DBHORTICONTEXT dBHORTICONTEXT) : base(dBHORTICONTEXT) { }

        public async Task<IEnumerable<Producer>> FullListOfProducers()
        {
            return await FullListOfEntities(Select: x => new Producer
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
                IdCityNavigation = new City
                {
                    IdCity = x.IdCityNavigation.IdCity,
                    DsCity = x.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = x.IdCityNavigation.Id.IdState,
                        DsState = x.IdCityNavigation.Id.DsState,
                        DsUf = x.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = x.IdDistrictNavigation.IdDistrict,
                    DsDistrict = x.IdDistrictNavigation.DsDistrict
                }
            },
            OrderBy: p => p.DsProducer);
        }

        public async Task<IEnumerable<Producer>> ListOfProducers(IProducerQuerySignature signature)
        {
            return await ListOfEntities(Where: x => (signature.Id == null || signature.Id == x.IdProducer)
                                                 && (signature.Email == null || signature.Email.Contains(x.DsEmail)),
                                        Select: p => new Producer
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
                                            IdCityNavigation = new City
                                            {
                                                IdCity = p.IdCityNavigation.IdCity,
                                                DsCity = p.IdCityNavigation.DsCity,
                                                Id = new State
                                                {
                                                    IdState = p.IdCityNavigation.Id.IdState,
                                                    DsState = p.IdCityNavigation.Id.DsState,
                                                    DsUf = p.IdCityNavigation.Id.DsUf
                                                }
                                            },
                                            IdDistrictNavigation = new District
                                            {
                                                IdDistrict = p.IdDistrictNavigation.IdDistrict,
                                                DsDistrict = p.IdDistrictNavigation.DsDistrict
                                            }
                                        },
                                        Page: signature.Page,
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsProducer);
        }

        public async Task<Producer> ProducerByIdOrEmail(IProducerQuerySignature signature)
        {
            return await EntityByFilter(Where: x => x.IdProducer == signature.Id || x.DsEmail == signature.Email,
            Select: p => new Producer
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
                IdCityNavigation = new City
                {
                    IdCity = p.IdCityNavigation.IdCity,
                    DsCity = p.IdCityNavigation.DsCity,
                    Id = new State
                    {
                        IdState = p.IdCityNavigation.Id.IdState,
                        DsState = p.IdCityNavigation.Id.DsState,
                        DsUf = p.IdCityNavigation.Id.DsUf
                    }
                },
                IdDistrictNavigation = new District
                {
                    IdDistrict = p.IdDistrictNavigation.IdDistrict,
                    DsDistrict = p.IdDistrictNavigation.DsDistrict
                }
            });
        }
    }
}
