
using EmployeeManager.Core.DTO;
using EmployeeManager.Core.Entities.Employee;
using EmployeeManager.Core.Sharing;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManager.Core.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<bool> AddAsync(EmployeeDTO employeeDTO);
        Task<bool> UpdateAsync(UpdateEmployeeDTO employeeDTO);

        Task deleteAsync(Employee employee);
        Task<EmployeeDTOList> GetAllAsync(EmployeeParams employeeParams);
    }
}
