using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestaurantRater.Controllers
{
    public class RatingController : ApiController
    {
        private readonly RestaurantDbContext _context = new RestaurantDbContext();
        // Create new ratings
        [HttpPost]
        public async Task<IHttpActionResult> CreateRating([FromBody] Rating model)
        {
            // Check if model is null
            if (model is null)
                return BadRequest("Your request body cannot be empty");

            // Check if ModelState is Invalid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Find the Restaurant by the model.RestaurantId and see that it exists
            var restaurantEntity = await _context.Restaurants.FindAsync(model.RestaurantId);
            if (restaurantEntity is null)
                return BadRequest($"The target restaurant with the ID of {model.RestaurantId} does not exist");

            // Create the rating
            restaurantEntity.Ratings.Add(model);
            if (await _context.SaveChangesAsync() == 1)
                return Ok($"You rated restaurant {restaurantEntity.Name} successfully!");

            return InternalServerError();
        }

        // EVERYTHING BELOW IS OPTIONAL, BUT RECOMMENDED TO COMPLETE
        // Get a rating by its ID

        // Get ALL ratings

        // Get ALL ratings for a specific restaurant by the Restaurant ID
        
        // Update a rating

        // Delete a rating
    }
}
