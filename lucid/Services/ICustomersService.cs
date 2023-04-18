using System.Collections.Generic;
using lucid.Models;

namespace lucid.Services
{
    public interface ICustomersService
    {
        List<Customer> GetAll();

        Customer Get( int id );

        void Add( Customer customer );
        
        Customer Update( int id, Customer customer );
        
        void Delete( int id );
    }
}
