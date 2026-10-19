using LINQ_Dersleri.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_Dersleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        [HttpGet("{population:long}")]
        public IActionResult GetCitiesPopulations(long population)
        {
            var cities = AppDataContext.Cities;

            var result = cities.Where(p => p.Population >= population);
            var result4 = cities.SingleOrDefault(p => p.Population >= population);
            
            
            var result2 = cities.All(p => p.Population >= population);
            var result3 = cities.Any(p => p.Population >= population);


            return Ok(result);
        }

        [HttpGet("search/{name}")]
        public IActionResult Search(string name)
        {
            // ifadeyle başlayan
            // ifadeyle içeren
            // ifadeyle biten

            var cities = AppDataContext.Cities;

            //var result = cities.Where(p => p.Name.StartsWith(name));
            var result = cities.Where(p => p.Name.Contains(name)).Take(3);
            //var result3 = cities.Where(p => p.Name.EndsWith(name));

            //var result4 = cities.Where(p => p.Name.EndsWith(name)).FirstOrDefault();
            //var result5 = cities.Where(p => p.Name.EndsWith(name)).LastOrDefault();




            return Ok(result);
        }


    }
}
