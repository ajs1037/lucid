using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using Microsoft.EntityFrameworkCore;

namespace lucid.Services
{
    public class CustomersService : GenericService<Customer>, ICustomersService
    {
        public CustomersService( AppDbContext appDbContext ) : base( appDbContext )
        {

        }
    }
}
