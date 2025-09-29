using AutoMapper;
using DemoG01.BusinessLogic.DTOs.Employees;
using DemoG01.DataAccess.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoG03.BusinessLogic.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dist => dist.EmpGender, options => options.MapFrom(src => src.Gender))
                .ForMember(dist => dist.EmpType, options => options.MapFrom(src => src.EmployeeType))
                .ForMember(dist => dist.DepartmentName, options => options.MapFrom(src => src.Department == null ? "No Department" : src.Department.Name));

            IMappingExpression<Employee, EmployeeDetailsDto> mappingExpression = CreateMap<Employee, EmployeeDetailsDto>()
                 .ForMember(dist => dist.Gender, options => options.MapFrom(src => src.Gender))
                 .ForMember(dist => dist.EmployeeType, options => options.MapFrom(src => src.EmployeeType))
                 .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate))
                .ForMember(dist => dist.DepartmentName, options => options.MapFrom(src => src.Department == null ? "No Department" : src.Department.Name));
                 .ForMember(dist => dist.Image, options => options.MapFrom(src => src.ImageName));

            CreateMap<CreatedEmployeeDto, Employee>()
                 .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate));

            CreateMap<UpdatedEmployeeDto, Employee>()
                .ForMember(dist => dist.HiringDate, options => options.MapFrom(src => src.HiringDate));
        }

        private void ForMember(Func<object, object> value1, Func<object, object> value2)
        {
            throw new NotImplementedException();
        }
    }
}