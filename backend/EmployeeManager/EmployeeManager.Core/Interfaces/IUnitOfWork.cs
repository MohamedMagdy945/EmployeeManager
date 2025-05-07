namespace EmployeeManager.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
    }
}
