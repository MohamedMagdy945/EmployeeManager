
using System.Collections.Generic;
using System.IO;
using AutoMapper;
using EmployeeManager.Core.DTO;
using EmployeeManager.Core.Entities.Employee;
using EmployeeManager.Core.Interfaces;
using EmployeeManager.Core.Services;
using EmployeeManager.Core.Sharing;
using EmployeeManager.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.Infrastructure.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>,IEmployeeRepository 
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;
        private readonly IImageManagementService imageManagementService;
        public EmployeeRepository(AppDbContext context,IMapper mapper,IImageManagementService imageManagementService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageManagementService = imageManagementService;
        }
         
        public async Task<bool> AddAsync(EmployeeDTO employeeDTO)
        {
            if (employeeDTO is null)
                return false;
            var imagePath = await imageManagementService.AddImageAsync(employeeDTO.ImageUrlFile, "EmployeePersonalImage");
            var employee = mapper.Map<Employee>(employeeDTO);
            employee.ImageUrl = imagePath;  
            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task deleteAsync(Employee employee)
        {
            string fileName = Path.GetFileName(employee.ImageUrl);
            if (fileName != "defaultImage.jpg")
            {
                imageManagementService.DeleteImageAsync(employee.ImageUrl);
            }
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
        }

        public async Task<EmployeeDTOList> GetAllAsync(EmployeeParams employeeParams)
        {
            var query = context.Employees.AsNoTracking();
            if (!string.IsNullOrEmpty(employeeParams.Search) && employeeParams.Search !="*")
            {
                var searhcWords = employeeParams.Search.Split(" ");
                query = query.Where(e => searhcWords.All(word => e.FirstName.ToLower().Contains(word.ToLower()) ||
                    e.LastName.ToLower().Contains(word.ToLower()) || e.Email.ToLower().Contains(word.ToLower()) || e.Position.ToLower().Contains(word.ToLower()))
                );
            }
            EmployeeDTOList employeeDTOList = new EmployeeDTOList();
            employeeDTOList.TotalCount = await query.CountAsync();

            var list = await query.Skip((employeeParams.PageNumber - 1) * employeeParams.PageSize).Take(employeeParams.PageSize).ToListAsync();
            employeeDTOList.Employees = mapper.Map<List<ReturnEmployeeDTO>>(list);
            return employeeDTOList;
        }

        public async Task<bool> UpdateAsync(UpdateEmployeeDTO employeeDTO)
        {
            bool flag = false;
            if (employeeDTO is null)
                return false;
            var FindedEmployee = await context.Employees.FirstOrDefaultAsync(e => e.Id == employeeDTO.Id);
            if (FindedEmployee is null)
                return false;
            if (employeeDTO.ImageUrlFile != null)
            {
                imageManagementService.DeleteImageAsync(FindedEmployee.ImageUrl);
                var imagePath = await imageManagementService.AddImageAsync(employeeDTO.ImageUrlFile, "EmployeePersonalImage");
                FindedEmployee.ImageUrl = imagePath;
            }
            else
            {
                flag = true; 
            }

            mapper.Map(employeeDTO, FindedEmployee);

          
            await context.SaveChangesAsync();
            return true;
        }
    }
}
