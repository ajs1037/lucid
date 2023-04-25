using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using lucid.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucid.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeeService _service;

        public EmployeesController( IEmployeeService service )
        {
            _service = service;
        }
        public IActionResult Index()
        {
            // when we have data manipulation we should use asyc
            var data = _service.GetAll();
            return View( data );
        }

        // Get: Employees/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Employee Employee )
        {
            // this will look at the data annotions on the model and check to see if all
            // the attributes with the "Required" data annotion are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View( Employee );
            }
            await _service.AddAsync( Employee );
            return RedirectToAction( "Index" );
        }

        // Get: Employees/Details/1
        public IActionResult Details( int id )
        {
            var EmployeeDetails = _service.Get( id );

            if ( EmployeeDetails == null )
            {
                return View( "NotFound" );
            }

            return View( EmployeeDetails );
        }

        // Get: Employees/edit/1
        public IActionResult Edit( int id )
        {

            var EmployeeDetails = _service.Get( id );

            if ( EmployeeDetails == null )
            {
                return View( "NotFound" );
            }

            return View( EmployeeDetails );
        }

        [HttpPost]
        public IActionResult Edit( int id, Employee Employee )
        {
            // this will look at the data annotions on the model and check to see if all the attributes with the "Required" data annotion
            // are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View( Employee );
            }

            _service.Update( id, Employee );
            return RedirectToAction( "Index" );
        }

        [HttpPost]
        public void Delete( int id )
        {
            var EmployeeDetails = _service.Get( id );

            if ( EmployeeDetails != null )
            {
                _service.Delete( id );
            }
        }

        // to delete something from the view you need to call the delete action which will call the delete post method
        public IActionResult DeleteAction( int id )
        {
            Delete( id );
            return RedirectToAction( "Index" );
        }
    }
}
