using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using lucid.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucid.Controllers
{
    public class TeamsController : Controller
    {

        private readonly ITeamService _teamService;
        private readonly IEmployeeService _employeeService;

        public TeamsController( ITeamService teamService, IEmployeeService employeeService )
        {
            _teamService = teamService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            // when we have data manipulation we should use asyc
            var data = _teamService.GetAll();
            return View( data );
        }

        // Get: teams/create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( Team team )
        {
            // this will look at the data annotions on the model and check to see if all
            // the attributes with the "Required" data annotion are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View( team );
            }
            await _teamService.AddAsync( team );
            return RedirectToAction( "Index" );
        }

        // Get: Teams/Details/1
        public IActionResult Details( int id )
        {
            var allEmployees = _employeeService.GetAll();
            var teamDetails = _teamService.Get( id );

            if ( teamDetails == null )
            {
                return View( "NotFound" );
            }

            ViewData["TeamModel"] = teamDetails;
            ViewData["Employees"] = allEmployees;

            return View( );
        }

        // Get: teams/edit/1
        public IActionResult Edit( int id )
        {
            var allEmployees = _employeeService.GetAll();
            var teamDetails = _teamService.Get( id );

            if ( teamDetails == null )
            {
                return View( "NotFound" );
            }

            ViewData["TeamModel"] = teamDetails;
            ViewData["Employees"] = allEmployees;

            return View();
        }

        [HttpPost]
        public IActionResult Edit( int id, Team team )
        {
            // this will look at the data annotions on the model and check to see if all the attributes with the "Required" data annotion
            // are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View( team );
            }

            _teamService.Update( id, team );
            return RedirectToAction( "Index" );
        }

        [HttpPost]
        public void Delete( int id )
        {
            var teamDetails = _teamService.Get( id );

            if ( teamDetails != null )
            {
                _teamService.Delete( id );
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
