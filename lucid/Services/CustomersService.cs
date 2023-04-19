using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task AddAsync( Customer customer )
        {
            await _context.Customers.AddAsync( customer );
            await _context.SaveChangesAsync();
        }

        public void Delete( int id )
        {
            throw new System.NotImplementedException();
        }

        public Customer Get( string id )
        {
            var result = _context.Customers.FirstOrDefault( c => c.Id == id );

            return result;
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
