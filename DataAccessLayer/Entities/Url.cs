using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Url
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string BaseUrl { get; set; }
        public string Slug { get; set; }
        public int AliasId { get; set; }
        public Alias Alias { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public string Description { get; set; }
    }
}
