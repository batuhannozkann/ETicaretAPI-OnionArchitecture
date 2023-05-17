using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Address:BaseEntity
    {
        public string FullAddress { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public Customer Customer { get; set; }

    }
}
