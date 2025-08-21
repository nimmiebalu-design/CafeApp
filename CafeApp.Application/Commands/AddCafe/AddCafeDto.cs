using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeApp.Application.Commands.AddCafe
{
    public class AddCafeDto
    {

       
        public string name { get; set; } = "";

        public string description { get; set; } = "";

        public byte[]? logo { get; set; } // optional (could be file or URL instead)

       
        public string location { get; set; } = "";
    }
}
