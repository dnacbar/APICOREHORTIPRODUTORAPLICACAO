using DomainCoreHortiCommand;
using DataCoreHortiQuery.IQUERIES;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiCoreHortiQuery.Controllers
{
    [Route("producer/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;

        public CityController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: producer/City
        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            try
            {
                return Ok(await _cityRepository.ListOfCities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // GET: producer/City/0/10
        [HttpGet("{idPage:int}/{idSize:int}")]
        public async Task<IActionResult> GetCities(int idPage, int idSize)
        {
            try
            {
                return Ok(await _cityRepository.ListOfCities(idPage, idSize));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // GET: producer/City/5
        [HttpGet("{idCity:int}")]
        public async Task<IActionResult> GetCity(int idCity)
        {
            try
            {
                return Ok(await _cityRepository.GetCityByCode(idCity));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
