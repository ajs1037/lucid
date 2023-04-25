using System.Collections.Generic;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;

namespace lucid.Services
{
    public interface IService<T> where T : class, IEntity, new()
    {
        List<T> GetAll();

        T Get( int id );

        Task AddAsync( T model );
        
        void Update( int id, T model );
        
        void Delete( int id );
    }
}
