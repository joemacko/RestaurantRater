using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RestaurantRater.Models
{
    // When inheriting from "DbContext" we need to use "Ctrl+." to bring in the "using System.Data.Entity;" using statement
    // The "DbContext" class acts a way to communicate with the store (in the database). 
        // This means that we're able to query to the database through this class and make changes.
    // You can think about the "DbContext" as a snapshot of the database when you first interact with it. 
        // Whatever changes you make have to be saved to apply to the database.
    public class RestaurantDbContext: DbContext
    {
        // Setting up a constructor (remember that "ctor" "tab" "tab" will scaffold this out for you).
        // Inheriting from the base constructor class ("DbContext") using the "base" keyword
            // and using one of the overloads that takes in a "string" and a "nameOrConnectionString".
            // "DefaultConnection" will be the name of our connection string.
        // We added the "DefaultConnection" "connectionStrings" to the "Web.config" file after this.
            // The "Data Source" (server) is "MSSQLLocalDB"
            // The "Initial Catalog" (database name we chose) is "RestaurantRaterAPI"
        public RestaurantDbContext() : base("DefaultConnection")
        {

        }

        // Property that uses "DbSet" return type that holds a class entity. Now "Restaurant" will have a collection,
            // or table, within the database.
        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<Rating> Ratings { get; set; }
    }
}