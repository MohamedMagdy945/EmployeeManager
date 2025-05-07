using AutoMapper;
using EmployeeManager.Core.DTO;
using EmployeeManager.Core.Entities.Employee;

namespace EmployeeManager.API.Mapping
{
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping() {

            CreateMap<Employee, EmployeeDTO>()
              .ReverseMap();


            CreateMap<Employee, ReturnEmployeeDTO>()
              .ReverseMap();

            CreateMap<UpdateEmployeeDTO, Employee>().ReverseMap()
                    .ReverseMap();
        }
    }
}
