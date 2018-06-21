using CityInfo.API.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{

    //[ApiController]
    [Route("api/cities")]

    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{cityId}/pointsofinterest")]

        public IActionResult GetPointsOfInterest(int cityId)
        {
            try
            {
                throw new Exception("exception sample");
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting for id {cityId}.", ex);
                return StatusCode(500, "problem");
            }
        }

        [HttpGet("{cityId}/pointsofinterest/{id}")]

        public IActionResult GetPointOfInterest(int cityId, int id)
        {

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }
            var pointOfInterest = city.PointsOfInterest.FirstOrDefault(c => c.Id == cityId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);

        }

        [HttpPost("{cityId}/pointsofinterest")]

        public IActionResult CreatePointOfInterest([FromBody] PointOfInterestForCreationDto pointOfInterest, int cityId)
        {
            if (pointOfInterest == null)
            {
                return BadRequest();
            }

            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "kaneis lathos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            //tha allaxtei

            var maxPointOfInterestId = CitiesDataStore.Current.Cities.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointsOfInterest.Add(finalPointOfInterest);

            return Ok(new { cityId, id = finalPointOfInterest.Id }); // CreatedAtRoute("pointsofinterest", new { cityId, id = finalPointOfInterest.Id });
        }

        [HttpPut("{cityId}/pointsofinterest/{id}")]

        public IActionResult UpdatePointOfInterest(int cityId, int id,
            [FromBody] PointOfInterestForUpdateDto pointOfInterest)
        {
            if (pointOfInterest.Description == pointOfInterest.Name)
            {
                ModelState.AddModelError("Description", "kaneis lathos");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p =>
            p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }



        [HttpDelete("{cityId}/pointsofinterest/{id}")]

        public IActionResult DeletePointOfInterest(int cityId, int id)

        {
            var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointsOfInterest.FirstOrDefault(p =>
            p.Id == id);

            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointsOfInterest.Remove(pointOfInterestFromStore);

            return NoContent();

        }
    }
}


