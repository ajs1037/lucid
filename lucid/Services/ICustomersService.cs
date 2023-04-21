using System.Collections.Generic;
using System.Threading.Tasks;
using lucid.Models;

namespace lucid.Services
{
    // When an interface class implements another interface class in C#, it is not required to define all the methods of the base
    // interface, but it is recommended to do so. If an interface implements another interface, it means that the implementing
    // interface is agreeing to implement all the members of the base interface. However, in some cases, an implementing
    // interface may not need to implement all the members of the base interface if they are not relevant to its implementation.

    // Here we have an interface class implementing another interface class but we do not need to define all the methods again.
    // Now ICustomersService has access to all the methods in the IGenericService.
    public interface ICustomersService : IService<Customer>
    {
        
    }
}
