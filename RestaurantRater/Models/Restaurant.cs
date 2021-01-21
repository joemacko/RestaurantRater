using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    // Because the "Restaurant" class is setup in the "RestaurantDbContext" as a model that supports a table
        // ("DbSet<Restaurant"), we need to have a way to define what the restaurant looks like and how we
        // identify different restaurants in the database. Every data table in a database must have a "primary key".
        // The "primary key" is a unique identifier for each row in the table. Every table in a database is basically just
        // a fancy excel sheet. It'll have columns and rows. Each column is defined by properties. We'll have Id, Name,
        // Address, and Ratings columns. Each row will contain an individual "Restaurant".
    public class Restaurant
    {
        // "EntityFramework" should know that the "Id" property is the "primary key" because it's the first property and of
            // type integer. However, we added the "[Key]" attribute to specify it just in case. We had to do "Ctrl+." to 
            // bring in the "using System.ComponentModel.DataAnnotations" using statement.
        [Key]
        public int Id { get; set; }
        
        // We added the "[Required]" attribute to the "Name" and "Address" properties because we want those pieces of information
            // to be given to us every time.
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Address { get; set; }

        public virtual List<Rating> Ratings { get; set; } = new List<Rating>();

        public double Rating 
        {
            get
            {
                double totalAverageRating = 0;

                // add all ratings
                foreach (var rating in Ratings)
                {
                    totalAverageRating += rating.AverageRating;
                }

                // get average from total
                return Ratings.Count > 0
                    ? Math.Round(totalAverageRating / Ratings.Count, 2) // If Ratings.Count > 0
                    : 0; // If Ratings.Count not > 0
            }
        }

        public bool IsRecommended
        {
            get
            {
                return Rating > 8;
            }
        }

        // Average Food Rating

        // Average Cleanliness Rating

        // Average Environment Rating
    }
}