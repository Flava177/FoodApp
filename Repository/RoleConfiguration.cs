using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole 
                { 
                    Name = "Customer", NormalizedName = "CUSTOMER" },
                new IdentityRole 
                {
                    Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
        }
    }
}
