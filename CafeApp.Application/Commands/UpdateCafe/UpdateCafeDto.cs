using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.UpdateCafe
{
    public class UpdateCafeDto
    {
        public Guid id { get; set; }
        public string name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string location { get; set; } = string.Empty;
        public byte[]? logo { get; set; } // optional (could be file or URL instead)
        public List<string> employees { get; set; } = new List<string>(); // List of employee IDs


    }
}
