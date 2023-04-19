using System.Collections.Generic;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();

        T Get( int id );

        Task AddAsync( T customer );
        
        void Update( int id, T customer );
        
        void Delete( int id );
    }
}
