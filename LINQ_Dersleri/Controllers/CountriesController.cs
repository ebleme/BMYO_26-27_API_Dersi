using LINQ_Dersleri.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LINQ_Dersleri.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        //[HttpGet]
        //public IActionResult GetMostPopulatedCountry()
        //{
        //    var countries = AppDataContext.Countries;

        //    // nüfusu en büyükm olan ülke
        //    long enb = countries.Max(p => p.Population);

        //    var country = countries.SingleOrDefault(p => p.Population == enb);

        //    return Ok(country);
        //}


        [HttpGet("{name}")]
        public IActionResult Search(string name)
        {
            var countries = AppDataContext.Countries;

            var country = countries.SingleOrDefault(p => p.Name == name);
            
            return Ok(country);
        }
    }
}
