using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.AddEmployee
{
    public class AddEmployeeDto
    {
        public string Name { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender  {  get; set;  }
        public Guid? CafeId { get; set; } = Guid.Empty;
        public DateTime? StartDate { get; set; } = null;
    }
}
