

using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManager.Core.Entities
{
    public class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public T Id { get; set; }
    }
}
