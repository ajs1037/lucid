﻿using System.Linq;
using System.Threading.Tasks;
using lucid.Data;
using lucid.Models;
using lucid.Services;
using Microsoft.AspNetCore.Mvc;

namespace lucid.Controllers
{
    public class CustomersController : Controller
    {

        private readonly ICustomerService _service;

        public CustomersController( ICustomerService service )
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
        public async Task<IActionResult> Create(Customer customer)
        {
            // this will look at the data annotions on the model and check to see if all
            // the attributes with the "Required" data annotion are not empty
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
                return View("NotFound");
            }

            return View(customerDetails);
        }

        // Get: customers/edit/1
        public IActionResult Edit(int id)
        {

            var customerDetails = _service.Get( id );

            if ( customerDetails == null )
            {
                return View( "NotFound" );
            }

            return View( customerDetails );
        }

        [HttpPost]
        public IActionResult Edit( int id, Customer customer )
        {
            // this will look at the data annotions on the model and check to see if all the attributes with the "Required" data annotion
            // are not empty
            if ( !ModelState.IsValid )
            {
                // pass the error back to the view
                return View( customer );
            }

            _service.Update( id, customer );
            return RedirectToAction( "Index" );
        }

        [HttpPost] 
        public void Delete( int id )
        {
            var customerDetails = _service.Get( id );

            if ( customerDetails != null )
            {
                _service.Delete( id );
            }
        }

        // to delete something from the view you need to call the delete action which will call the delete post method
        public IActionResult DeleteAction( int id)
        {
            Delete(id);
            return RedirectToAction( "Index" );
        }
    }
}
