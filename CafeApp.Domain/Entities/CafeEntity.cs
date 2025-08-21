using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Core.Entities
{
    public class CafeEntity
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string name { get; set; } = string.Empty;

        [Required]
        public string description { get; set; } = string.Empty;

        public byte[]? logo { get; set; } // optional (could be file or URL instead)

        [Required]
        [MaxLength(100)]
        public string location { get; set; } = string.Empty;

        // Navigation Property (One-to-many: one cafe has many employees)
        public ICollection<EmployeeEntity> Employees { get; set; } = new List<EmployeeEntity>();
    }
}
