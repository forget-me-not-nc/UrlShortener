using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.UrlDTOs
{
    public class UrlCreateRequest
    {
        public string BaseUrl { get; set; }
        public string Description { get; set; }
    }
}
