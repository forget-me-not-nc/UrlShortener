using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Alias
    {
        public int Id { get; set; }
        public string AliasSlug { get; set; }
        public List<Url> Urls { get; set; }
    }
}
