using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class District:BaseEntity
    {
        public City City { get; set; }
        public string DistrictName { get; set; }
    }
}
