using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

//Big Picture:
//             Action            View
// ============================================= 
//             Index ---------> Index
//                Click [Create]
//      CustomerForm ---------> CustomerForm
//                Click [Save]
//             Index ---------> Index
//              Click on some record
//         Edit/{id} ---------> CustomerForm
//                Click [Save]
//             Index ---------> Index

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var customers = _context.Customers.Include(x => x.MembershipType).ToList();

            return View(customers);
        }

//        public ActionResult Details(int id)
//        {
//            var customers = _context.Customers.Include(x => x.MembershipType).ToList();
//            var customer = customers.SingleOrDefault(x => x.Id == id);
//
//            if(customer == null) return HttpNotFound();
//
//            return View(customer);
//        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var existingCustomer = _context.Customers.Single(x => x.Id == customer.Id);
                existingCustomer.Name = customer.Name;
                existingCustomer.BirthDate = customer.BirthDate;
                existingCustomer.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                existingCustomer.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if(customer == null) return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}