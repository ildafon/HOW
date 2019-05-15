using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoustonOnWire.Models;

namespace HoustonOnWire.Models
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            if (context.Database.GetMigrations().Count() > 0
                && context.Database.GetPendingMigrations().Count() == 0
                && context.Customers.Count() == 0)
            {
                
            }
        }
    }
}
