using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService( AppDbContext appDbContext ) : base( appDbContext )
        {

        }
    }
}
