using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{

    [Route("api/cities")]

    public class CitiesController : Controller
    {
        private Services.ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        




        [HttpGet()]
    
    
        public JsonResult GetCities()
        {
            return new JsonResult(CitiesDataStore.Current.Cities);
        }

        [HttpGet("{id}")]

        public JsonResult GetCity (int id)
        {
            return new JsonResult(
            CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id)
                );

        }
    }
}
