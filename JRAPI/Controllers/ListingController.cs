using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JRAPI.DTO;
using JRAPI.Models;
using System.Net.Http;
using Newtonsoft.Json;
namespace JRAPI.Controllers
{
    [Route("api/Listings")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        // GET: api/Listing/
        [HttpGet()]
        public async Task<ActionResult<QuoteDto>> GetAsync([FromQuery(Name = "passengers")] int passengers)
        {
            Quote quote = null;
            QuoteDto quoteDto = null;
            // check if we have the number of passenger in the request
            using (var httpClient = new HttpClient())
            {
                // Call the service to get the location details from Jayride API
                using (var response = await httpClient.GetAsync("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    quote = JsonConvert.DeserializeObject<Quote>(apiResponse);

                    //Initiate resposneDto
                    if (quote != null)
                    {
                        List<Listing> filteredList = quote.listings.Where(l => l.vehicleType.maxPassengers >= passengers).ToList();
                        // Create a list of ListingsDTO
                        List<ListingDto> listingDtos = new List<ListingDto>();
                        quoteDto = new QuoteDto();
                        quoteDto.from = quote.from;
                        quoteDto.to = quote.to;
                        quoteDto.listings = new List<ListingDto>();
                        foreach (Listing listing in filteredList)
                        {
                            ListingDto listing1 = new ListingDto();
                            listing1.name = listing.name;
                            listing1.pricePerPassenger = listing.pricePerPassenger;
                            // Caculate the total price
                            listing1.totalPrice = listing1.pricePerPassenger * passengers;
                            listing1.vehicleType = listing.vehicleType;
                            quoteDto.listings.Add(listing1);

                        }
                        // Sort listingDtoList by total proce
                        quoteDto.listings = quoteDto.listings.OrderBy(c => c.totalPrice).ToList();
                        
                    }
                    else
                        return NotFound();

                }
            }
            return quoteDto;
        }
    }
}
