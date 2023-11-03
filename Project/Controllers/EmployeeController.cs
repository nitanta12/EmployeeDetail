using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;


namespace Project.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceLayer _iemployee;
        private readonly EmployeeDetailsDbContext _context;

        public EmployeeController(IEmployeeServiceLayer employeeService, EmployeeDetailsDbContext context)
        {
            _iemployee = employeeService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await _iemployee.GetEmployeeDetailAsync().ConfigureAwait(false);
            return View(data.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var data = await _iemployee.DetailByIdAsync(id).ConfigureAwait(false);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new EmployeeDetail());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,Enrollment,DateOfBirth,DId,FileUrl")] EmployeeDetail edt, IFormFile file)
        {
            await _iemployee.AddEmployeeAsync(edt, file);
            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _iemployee.GetEmployeeByIdAsync(id).ConfigureAwait(false);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeDetail edt)
        {
            if (ModelState.IsValid && edt.DateOfBirth < DateTime.Now)
            {
                await _iemployee.EditEmployeeAsync(edt).ConfigureAwait(false);
                return RedirectToAction(nameof(Index));
            }
            else
                ModelState.AddModelError(nameof(edt.DateOfBirth), "Date of birth cannot be in future.");
            return View(edt);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _iemployee.DeleteEmployeeAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}


