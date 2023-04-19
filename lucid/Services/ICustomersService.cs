using System.Collections.Generic;
using System.Threading.Tasks;
using lucid.Models;

namespace lucid.Services
{
    public interface ICustomersService
    {
        List<Customer> GetAll();

        Customer Get( string id );

        Task AddAsync( Customer customer );
        
        Customer Update( int id, Customer customer );
        
        void Delete( int id );
    }
}
