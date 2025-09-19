using DemoG01.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG01.DataAccess.Data.Configurations
{
    internal class EmployeeConfigurations : BaseEntityConfigurations<Employee> ,IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Name).HasColumnType("nvarchar(50)");
            builder.Property(E => E.Salary).HasColumnType("decimal(10,2)");

            builder.Property(E => E.Gender)
                .HasConversion((gender) => gender.ToString(),
                    (toGender) => (Gender)Enum.Parse(typeof(Gender), toGender));

            builder.Property(E => E.EmployeeType)
               .HasConversion((EmployeeType) => EmployeeType.ToString(),
                   (toEmployeeType) => (EmployeeType)Enum.Parse(typeof(EmployeeType),toEmployeeType));

            base.Configure(builder);    
        }
    }
}
