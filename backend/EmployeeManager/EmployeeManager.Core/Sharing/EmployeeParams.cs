
namespace EmployeeManager.Core.Sharing
{
    public class EmployeeParams
    {
        private int MaxPageSize { get; set; } = 6;
        private int _pageSize =6 ;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        public string? Search { get; set; }
        public int PageNumber { get; set; } = 1;
    }
}
