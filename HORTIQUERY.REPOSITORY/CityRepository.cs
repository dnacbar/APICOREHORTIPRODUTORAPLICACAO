﻿using HORTICOMMAND.DOMAIN.MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;
using HORTICOMMAND.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.REPOSITORY;
using HORTIQUERY.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTI.CORE.CROSSCUTTING.DBBASEEF;

namespace HORTIQUERY.REPOSITORY
{
    public sealed class CityRepository : _BaseEFQueryRepository<City>, ICityRepository
    {
        public CityRepository(DBHORTICONTEXT DBHORTICONTEXT) : base(DBHORTICONTEXT) { }

        public Task<City> CityByIdOrName(ICityQuerySignature signature)
        {
            return EntityByFilter(Where: p => signature.Id == p.IdCity || signature.City == p.DsCity,
                                        Select: x => new City
                                        {
                                            IdCity = x.IdCity,
                                            DsCity = x.DsCity,
                                            IdState = x.IdState
                                        });
        }

        public Task<List<City>> FullListOfCities()
        {
            return FullListOfEntity(Select: x => new City
            {
                IdCity = x.IdCity,
                DsCity = x.DsCity,
                IdState = x.IdState
            },
            OrderBy: p => p.DsCity);
        }

        public Task<List<City>> ListOfCities(ICityQuerySignature signature)
        {
            return ListOfEntity(Where: x => (signature.City == null || x.DsCity.Contains(signature.City))
                                                 && (signature.Id == null || signature.Id == x.IdCity)
                                                 && (signature.IdState == null || signature.IdState == x.IdState),
                                        Select: p => new City
                                        {
                                            IdCity = p.IdCity,
                                            DsCity = p.DsCity,
                                            IdState = p.IdState
                                        },
                                        Page: signature.Page,
                                        Quantity: signature.Quantity,
                                        OrderBy: o => o.DsCity);
        }
    }
}