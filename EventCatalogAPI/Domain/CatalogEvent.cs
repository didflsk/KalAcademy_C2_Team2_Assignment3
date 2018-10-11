using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }

        public string PictureUrl { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogDateId { get; set; }
        public int CatalogLocationId { get; set; }

        public virtual CatalogType CatalogType { get; set; }
        public virtual CatalogDate CatalogDate { get; set; }
        public virtual CatalogLocation CatalogLocation { get; set; }
    }
}
