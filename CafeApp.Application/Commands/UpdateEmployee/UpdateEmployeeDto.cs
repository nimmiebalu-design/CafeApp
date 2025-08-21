using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateEmployee
{
    public class UpdateEmployeeDto
    {
        public string id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email_address { get; set; } = string.Empty;
        public string phone_number { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public Guid? cafe_id { get; set; } = Guid.Empty;
        public DateTime? start_date { get; set; } = null;

    }
}
