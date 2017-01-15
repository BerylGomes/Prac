using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CurrysToGo.Models
{
    public class CurrysToGoDb :DbContext
    {
        /// <summary>
        /// base constructor with default connection retrieved from web.config
        /// </summary>
        public CurrysToGoDb(): base("name=DefaultConnection")
        {

        }
       public DbSet<Restaurant> Restaurants { get; set; }
       


    }
}