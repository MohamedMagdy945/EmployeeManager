

namespace EmployeeManager.Core.Entities.Employee
{
    public class Employee : BaseEntity<int>
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Position { get; set; }
        public string ImageUrl{ get; set; }
    }
}
