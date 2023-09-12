namespace DataAccessLayer.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public ROLES Name { get; set; }
        public List<User> Users { get; set; }
    }
}
