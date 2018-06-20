using CityInfo.API.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CitiesDataStore
    {

        public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public List<CityDto> Cities { get; set; }

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "new york",
                    Description = "amerika fuck yeah",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "the most gamaoua"
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "Central Perk",
                            Description = "auto apo ta filarakia"
                        },

                    }
                },
                new CityDto()
                {
                Id = 2,
                Name = "new york",
                Description = "amerika fuck yeah"
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "new york",
                    Description = "amerika fuck yeah"
                }

            };
        }
    
     }       
}