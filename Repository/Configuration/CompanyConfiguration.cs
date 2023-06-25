using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Entities.Models;

namespace Repository.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(new Address
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Street = "Martey_Tsuru",
                Area = "583 Wall Dr. Gwynn Oak, MD 21207",

                City = "Airport"
            },
                new Address
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Street = "Admin_Solutions Ltd",
                    Area = "312 Forest Avenue, BF 923",
                    City = "USA"
                });
        }
    }
}
