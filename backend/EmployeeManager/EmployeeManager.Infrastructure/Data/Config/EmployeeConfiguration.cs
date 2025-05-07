

using EmployeeManager.Core.Entities.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManager.Infrastructure.Data.Config
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Id)
                .UseIdentityColumn()
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email).IsRequired();
            builder.Property(e => e.Position)
                .IsRequired();

            builder.HasData(
                new Employee()
                {
                    Id = 1,
                    Email = "test1@gmail.com",
                    FirstName = "Mahmoud",
                    LastName = "Abd Elaziz",
                    Position = "Software Engineer",
                    ImageUrl = "Images/EmployeePersonalImage/test1.jpg"
                },
                new Employee()
                {
                    Id = 2,
                    Email = "test2@gmail.com",
                    FirstName = "Malak",
                    LastName = "Gamal",
                    Position = "Network Engineer",
                    ImageUrl = "Images/EmployeePersonalImage/test2.jpg"
                },
                new Employee()
                {
                    Id = 3,
                    Email = "test3@gmail.com",
                    FirstName = "Yassen",
                    LastName = "Walid",
                    Position = "Sales Manager",
                    ImageUrl = "Images/EmployeePersonalImage/test3.jpg"
                },
                new Employee()
                {
                    Id = 4,
                    Email = "test4@gmail.com",
                    FirstName = "Mahmoud",
                    LastName = "Wael",
                    Position = "Markting",
                    ImageUrl = "Images/EmployeePersonalImage/test4.jpg"
                },
                new Employee()
                {
                    Id = 5,
                    Email = "test5@gmail.com",
                    FirstName = "Mansour",
                    LastName = "Mohamed",
                    Position = "Technical Support",
                    ImageUrl = "Images/EmployeePersonalImage/test5.jpg"
                },
                new Employee()
                {
                    Id = 6,
                    Email = "test6@gmail.com",
                    FirstName = "Ahmed",
                    LastName = "Gmal",
                    Position = "HR Manager",
                    ImageUrl = "Images/EmployeePersonalImage/test6.jpg"
                }
                );

        }
    }
}
