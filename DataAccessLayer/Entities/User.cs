namespace DataAccessLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public List<Role> Roles { get; set; }

        public List<Url> Urls { get; set; }
    }
}
