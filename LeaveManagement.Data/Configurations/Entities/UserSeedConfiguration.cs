using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "e87290f1-52ae-4053-be83-fae6d29875e3",
                    Email = "Admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "Admin@localhost.com",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "E!m@i#n$25"),
                    EmailConfirmed = true
                },
                  new Employee
                  {
                      Id = "0d1872cf-5ecb-4ad7-b30e-4585cdc9841e",
                      Email = "Emin1@test.com",
                      NormalizedEmail = "EMIN1@TEST.COM",
                      NormalizedUserName = "EMIN1@TEST.COM",
                      UserName = "Emin1@test.com",
                      FirstName = "Me",
                      LastName = "Myself",
                      PasswordHash = hasher.HashPassword(null, "E!e123123"),
                      EmailConfirmed = true
                  }
                
             );   
        }
    }
}