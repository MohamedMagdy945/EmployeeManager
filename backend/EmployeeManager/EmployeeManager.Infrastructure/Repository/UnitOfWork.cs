using AutoMapper;
using EmployeeManager.Core.Interfaces;
using EmployeeManager.Core.Services;
using EmployeeManager.Infrastructure.Data;

namespace EmployeeManager.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageManagementService _imageManagementService; 
        public IEmployeeRepository EmployeeRepository { get; }
        public UnitOfWork(AppDbContext context, IMapper mapper , IImageManagementService imageManagementService)
        {
            _context = context;
            _mapper = mapper;
            _imageManagementService = imageManagementService;
            EmployeeRepository = new EmployeeRepository(_context , _mapper , _imageManagementService); 
        }
    }
}
