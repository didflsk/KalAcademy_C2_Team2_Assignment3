using EventCatalogAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


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

        private static IEnumerable<CatalogDate> GetPreConfigureCatalogDates()
        {
            List<CatalogDate> catalogdate = new List<CatalogDate>();

            DateTime datetime = DateTime.Now;
            for (int i = 0; i <= 10; i++)
            {
                DateTime newdatetime = datetime.AddDays(1);

                catalogdate.Add(new CatalogDate { Date = newdatetime });
            }

            return catalogdate;
        }



        private static IEnumerable<CatalogLocation> GetPreConfigureCatalogLocations()
        {
            return new List<CatalogLocation>()
            {
                new CatalogLocation {Location="Seattle"},
                new CatalogLocation {Location="Bellevue"},
                new CatalogLocation {Location="Tacoma"},
                new CatalogLocation {Location="Lynnwood"},
                new CatalogLocation {Location="Issaquah"},
                new CatalogLocation {Location="Puyallup"}
            };

        }
        private static IEnumerable<CatalogEvent> GetPreConfigureCatalogEvents()
        {
            return new List<CatalogEvent>()
            {
               new CatalogEvent() { CatalogTypeId=1,CatalogDateId=2, CatalogLocationId=3, Description = "For one night, and one night only, step right up and embrace the spooky spirit of FreakNight Festival!", Name = "Freak Night", Fee = 100M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
               new CatalogEvent() { CatalogTypeId=2,CatalogDateId=5, CatalogLocationId=1, Description = "SAM is the center for world-class visual arts in the Pacific Northwest.", Name = "Seattle Artm Museum", Fee = 24.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
               new CatalogEvent() { CatalogTypeId=3,CatalogDateId=11, CatalogLocationId=5, Description = "Increasing Innovation Through the Decision Making Process", Name = "Decision Making Class", Fee = 19.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
               new CatalogEvent() { CatalogTypeId=4,CatalogDateId=10, CatalogLocationId=4, Description = "Get your dance moves and Get in shape today!", Name = "Zumba Class", Fee = 34.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
               new CatalogEvent() { CatalogTypeId=5,CatalogDateId=3, CatalogLocationId=6, Description = "One of the biggest fairs in the world and the largest in the Pacific Northwest!", Name = "Washington Spring Fair", Fee = 14.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
               new CatalogEvent() { CatalogTypeId=5,CatalogDateId=7, CatalogLocationId=2, Description = "Welcome to the first Dealmoon Asian Street Food Night Market in Bellevue! Bring your friends and family to eat some REAL Asian food!", Name = "Seattle Asian Street Food Night Market", Fee = 5.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
               new CatalogEvent() { CatalogTypeId=5,CatalogDateId=9, CatalogLocationId=6, Description = "One of the biggest fairs in the world and the largest in the Pacific Northwest!", Name = "Washington State Fair", Fee = 12.50M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },

            };


        }
    }
}
