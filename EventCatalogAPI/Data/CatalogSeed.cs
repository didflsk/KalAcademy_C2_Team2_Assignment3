using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Data
{
    
    public class CatalogSeed
    {
        public static async Task SeedAsync(CatalogContext context)
        {
            context.Database.Migrate();
            if (!context.CatalogTypes.Any())
            {
                context.CatalogTypes.AddRange
                    (GetPreConfigureCatalogTypes());
                context.SaveChanges();
            }
            if (!context.CatalogDates.Any())
            {
                context.CatalogDates.AddRange
                    (GetPreConfigureCatalogDates());
                context.SaveChanges();
            }
            if (!context.CatalogLocations.Any())
            {
                context.CatalogLocations.AddRange
                    (GetPreConfigureCatalogLocations());
                context.SaveChanges();
            }
            if (!context.CatalogEvents.Any())
            {
                context.CatalogEvents.AddRange
                    (GetPreConfigureCatalogEvents());
                context.SaveChanges();
            }

        }
        private static IEnumerable<CatalogType> GetPreConfigureCatalogTypes()
        {
            return new List<CatalogType>()
            {
                new CatalogType {Type="Music"},
                new CatalogType {Type="Arts"},
                new CatalogType {Type="Business"},
                new CatalogType {Type="Sports"},
                new CatalogType {Type="Food"}
            };
        }
        //private static IEnumerable<CatalogDate> GetPreConfigureCatalogDates()
        //{

        //    for (var dt = start; dt <= end; dt = dt.AddDays(1))
        //    {
        //        dates.Add(dt);
        //    }
        //}
        
        
            
            
        
        private static IEnumerable<CatalogLocation> GetPreConfigureCatalogLocations()
        {
            return new List<CatalogLocation>()
            {
                new CatalogLocation {Location="Seattle"},
                new CatalogLocation {Location="Bellevue"},
                new CatalogLocation {Location="Tacoma"},
                new CatalogLocation {Location="Lynnwood"}
            };

        }
        private static IEnumerable<CatalogEvent> GetPreConfigureCatalogEvents()
        {
            return new List<CatalogEvent>()
            {
                 new CatalogEvent() { CatalogTypeId=5,CatalogDateId=3, CatalogLocationId=1, Description = "Welcome to the first Dealmoon Asian Street Food Night Market in Seattle! Bring your friends and family to eat some REAL Asian food!", Name = "Seattle Asian Street Food Night Market", Fee = 0M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                 new CatalogEvent() { CatalogTypeId=1,CatalogDateId=2, CatalogLocationId=1, Description = "For one night, and one night only, step right up and embrace the spooky spirit of FreakNight Festival!", Name = "Freak Night", Fee = 100M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                 new CatalogEvent() { CatalogTypeId=3,CatalogDateId=11, CatalogLocationId=2, Description = "Increasing Innovation Through the Decision Making Process", Name = "Decision Making Class", Fee = 19.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
            };


        }
    }
}
