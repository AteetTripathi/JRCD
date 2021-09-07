using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using JRAPI.Models;
using JRAPI.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JRAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        // GET: api/Location/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDto>> GetAsync(String id )
        {
            Location loc = null;
            LocationDto locationDto = null;
            // check if we have the ip in the request
            if (id == null)      
            {
                return NotFound();
            }
            using (var httpClient = new HttpClient())
            {
                // CAll the service to get the location details from IP
                using (var response = await httpClient.GetAsync("http://ip-api.com/json/"+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    loc= JsonConvert.DeserializeObject<Location>(apiResponse);
                    
                    //Initiate resposneDto
                    if (loc != null)
                    {
                        locationDto = new LocationDto();
                        locationDto.city = loc.city;
                        
                    }
                    else
                        return NotFound();

                }
            }
            return locationDto;
        }
    }
}
