using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTOs.AliasDTOs
{
    public class AliasUpdateRequest
    {
        public int Id { get; set; }
        public string AliasSlug { get; set; }
    }
}
