using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Queries.GetEmployees
{
    public class GetEmployeesDto
    {
        public string id { get; set; }
        public string name { get; set; }
        [EmailAddress]
        public string email_address { get; set; }
        public string phone_number { get; set; }
        public string gender { get; set; }
        public int days_worked { get;set; } = 0;
        public Guid? cafe_id { get; set; } = Guid.Empty;
        public string? cafe_name { get; set; } = string.Empty;
        public DateTime? start_date { get; set; } = null;

    }
}
