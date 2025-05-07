using Microsoft.AspNetCore.Http;

namespace EmployeeManager.Core.DTO
{
    public record EmployeeDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Position { get; set; }
        public IFormFile? ImageUrlFile{ get; set; }
    }
    public record ReturnEmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
    }
    public record EmployeeDTOList
    {
        public List<ReturnEmployeeDTO> Employees { get; set; }
        public int TotalCount { get; set; }
    }
    public record UpdateEmployeeDTO : EmployeeDTO
    {
        public int Id { get; set; }
    }
}
