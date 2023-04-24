using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        public EmployeeService( AppDbContext appDbContext ) : base( appDbContext )
        {

        }
    }
}
