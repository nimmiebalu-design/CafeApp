using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetCafes
{
    public class GetCafesDto
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public byte logo { get; set; }
       public int employee_count { get; set; } = 0;
        // Additional properties can be added as needed
        // For example, you might want to include a list of employees or other related data
    }
}
