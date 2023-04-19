using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using lucid.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucid.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomersService _service;

        public CustomersController( ICustomersService service )
        {
            _service = service;
        }
        public IActionResult Index()
        {
            // when we have data manipulation we should use asyc
            var data = _service.GetAll();
            return View(data);
        }

        // Get: customers/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("PhoneNumber,EmailAddress")]Customer customer)
        {
            // this will look at the data annotions on the model and check to see if all the attributes with the "Required" data annotion
            // are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View(customer);
            }

            await _service.AddAsync( customer );
            return RedirectToAction("Index");
        }

        // Get: Customers/Details/1
        public IActionResult Details(int id)
        {
            var customerDetails = _service.Get( id );

            if ( customerDetails == null)
            {
                return View("Empty");
            }

            return View(customerDetails);
        }
    }
}
