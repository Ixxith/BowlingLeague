using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models
{
    public class SeedData
    {
        //Ensure populated method to automatically migrate pending migrations
        //and populate database with data if needed
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            BowlingLeagueContext context = application.ApplicationServices.CreateScope()
                .ServiceProvider.GetRequiredService<BowlingLeagueContext>();

           
            

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Bowlers.Any())
            {
                
            }
        }
    }
}
