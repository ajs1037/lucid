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

        private readonly ITeamService _service;

        public TeamsController( ITeamService service )
        {
            _service = service;
        }
        public IActionResult Index()
        {
            // when we have data manipulation we should use asyc
            var data = _service.GetAll();
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
            await _service.AddAsync( team );
            return RedirectToAction( "Index" );
        }

        // Get: Teams/Details/1
        public IActionResult Details( int id )
        {
            var teamDetails = _service.Get( id );

            if ( teamDetails == null )
            {
                return View( "NotFound" );
            }

            return View( teamDetails );
        }

        // Get: teams/edit/1
        public IActionResult Edit( int id )
        {

            var teamDetails = _service.Get( id );

            if ( teamDetails == null )
            {
                return View( "NotFound" );
            }

            return View( teamDetails );
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

            _service.Update( id, team );
            return RedirectToAction( "Index" );
        }

        [HttpPost]
        public void Delete( int id )
        {
            var teamDetails = _service.Get( id );

            if ( teamDetails != null )
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
