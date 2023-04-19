using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lucid.Services
{
    public class GenericService<T>: IGenericService<T> where T : class, IEntity, new()
    {
        // in every service you need to create an instance of the db context and pass it into your contructor
        private readonly AppDbContext _context;

        public GenericService( AppDbContext appDbContext )
        {
            _context = appDbContext;
        }

        public async Task AddAsync( T customer )
        {
            await _context.Set<T>().AddAsync( customer );
        }

        public void Delete( int id )
        {
            var entity = _context.Set<T>().FirstOrDefault( c => c.Id == id );

            EntityEntry entityEntry = _context.Entry<T>( entity );
            entityEntry.State = EntityState.Deleted;
        }

        public T Get( int id )
        {
            var result = _context.Set<T>().FirstOrDefault( c => c.Id == id );

            return result;
        }

        public List<T> GetAll()
        {
            var result = _context.Set<T>().ToList();

            return result;
        }

        public void Update( int id, T entity )
        {
            EntityEntry entityEntry = _context.Entry<T>( entity );
            entityEntry.State = EntityState.Modified;
        }
    }
}
