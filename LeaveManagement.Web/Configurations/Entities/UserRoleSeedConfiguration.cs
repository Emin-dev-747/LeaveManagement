using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "14b4c776-df2c-427f-9fad-9a5a2666d882",
                    UserId = "e87290f1-52ae-4053-be83-fae6d29875e3"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "65cf1bb6-b57f-4060-a030-3d28691c4ecc",
                    UserId = "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e"
                }
             );   
        }
    }
}