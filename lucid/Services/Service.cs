using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lucid.Services
{
    public class Service<T>: IService<T> where T : class, IEntity, new()
    {
        // create an instance of the db context and pass it into the contructor
        private readonly AppDbContext _context;
        internal DbSet<T> _objectSet;

        public Service( AppDbContext appDbContext )
        {
            _context = appDbContext;

            // I don't know what this does but rock has it
            //_objectSet = _context.Set<T>();
        }

        public async Task AddAsync( T customer )
        {
            await _context.Set<T>().AddAsync( customer );
            await _context.SaveChangesAsync();
        }

        public void Delete( int id )
        {
            var entity = _context.Set<T>().FirstOrDefault( c => c.Id == id );

            EntityEntry entityEntry = _context.Entry<T>( entity );
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
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
            _context.SaveChanges();
        }
    }
}
