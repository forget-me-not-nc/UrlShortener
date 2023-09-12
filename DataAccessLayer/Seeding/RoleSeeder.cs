using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Seeding
{
    internal class RoleSeeder : ISeeder<Role>
    {
        private readonly List<Role> roles = new()
        {
            new Role 
            {
                Id = 1,
                Name = ROLES.USER
            },

            new Role
            {
                Id = 2,
                Name = ROLES.ADMIN
            },
        };

        public void Seed(EntityTypeBuilder<Role> builder) => builder.HasData(roles);
    }
}
