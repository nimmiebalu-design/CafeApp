using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Entities
{
    public class EmployeeEntity
    {
        // Primary Key - format 'UIXXXXXXX' handled in code
        public string id { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public string email_address { get; set; } = string.Empty;

        public string phone_number { get; set; } = string.Empty;

        public string gender { get; set; } = string.Empty; // Male/Female

        public DateTime? start_date { get; set; } = null;
        // Navigation Property (One employee works in one cafe)
        public Guid? cafe_id { get; set; } = Guid.Empty; // represents "no cafe"
        public CafeEntity? cafe { get; set; } = null!;
    }
}
