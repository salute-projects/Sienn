using System.Collections.Generic;
using SIENN.Domain.Infrastructure;

namespace SIENN.Domain.DTO.Product
{
    public class ProductFilterRequest : PagingReqest
    {
        public bool? Availability { get; set; }
        public List<int> TypeFilter { get; set; } = new List<int>();
        public List<int> CategoryFilter { get; set; } = new List<int>();
        public List<int> UnitFilter { get; set; } = new List<int>();
        public string SearchCriteria { get; set; }
        public bool OrderById { get; set; } = true;
        public bool OrderByCode { get; set; }
        public bool OrderByCreated { get; set; }
        public bool OrderByUpdated { get; set; }
        public bool OrderByDeliveryDate { get; set; }
        public bool OrderByPrice { get; set; }
        public bool Ascending { get; set; }
    }
}
