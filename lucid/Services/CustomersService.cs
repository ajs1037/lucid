using System.Collections.Generic;
using System.Linq;
using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public class CustomersService : ICustomersService
    {
        // in every service you need to create an instance of the db context and pass it into your contructor
        private readonly AppDbContext _context;

        public CustomersService( AppDbContext appDbContext )
        {
            _context = appDbContext;
        }

        public void Add( Customer customer )
        {
            _context.Customers.Add( customer );
            _context.SaveChanges();
        }

        public void Delete( int id )
        {
            throw new System.NotImplementedException();
        }

        public Customer Get( int id )
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAll()
        {
            var result = _context.Customers.ToList();

            return result;
        }

        public Customer Update( int id, Customer customer )
        {
            throw new System.NotImplementedException();
        }
    }
}
