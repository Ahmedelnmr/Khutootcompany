using Khutootcompany.Application.Services;
using Khutootcompany.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Khutootcompany.presention.Controllers
{
    [Authorize]
    public class CashTransactionsController : Controller
    {
        private readonly ICashTransactionService _cashService;
        private readonly IEmployeeService _employeeService;
        private readonly ITruckService _truckService;

        public CashTransactionsController(
            ICashTransactionService cashService,
            IEmployeeService employeeService,
            ITruckService truckService)
        {
            _cashService = cashService;
            _employeeService = employeeService;
            _truckService = truckService;
        }

        public async Task<IActionResult> Index(DateTime? startDate, DateTime? endDate, TransactionType? type)
        {
            IEnumerable<CashTransactionDto> transactions;

            if (startDate.HasValue && endDate.HasValue)
            {
                transactions = await _cashService.GetTransactionsByDateRangeAsync(startDate.Value, endDate.Value);
                ViewBag.FilterTitle = $"من {startDate:dd/MM/yyyy} إلى {endDate:dd/MM/yyyy}";
            }
            else if (type.HasValue)
            {
                transactions = await _cashService.GetTransactionsByTypeAsync(type.Value);
                ViewBag.FilterTitle = type.Value.ToString().Replace("_", " ");
            }
            else
            {
                transactions = await _cashService.GetAllTransactionsAsync();
                ViewBag.FilterTitle = "جميع الحركات";
            }

            ViewBag.CurrentBalance = await _cashService.GetCurrentBalanceAsync();
            return View(transactions);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CashTransactionDto transaction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var username = User.Identity?.Name ?? "Unknown";
                    await _cashService.CreateTransactionAsync(transaction, username);
                    TempData["Success"] = "تم تسجيل الحركة بنجاح";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"حدث خطأ: {ex.Message}");
                }
            }

            await PopulateDropdowns();
            return View(transaction);
        }

        private async Task PopulateDropdowns()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            var trucks = await _truckService.GetAllTrucksAsync();

            ViewBag.Employees = employees.Select(e => new { Value = e.EmployeeId, Text = e.FullName });
            ViewBag.Trucks = trucks.Select(t => new { Value = t.TruckId, Text = t.PlateNumber });
            ViewBag.TransactionTypes = new SelectList(Enum.GetValues(typeof(TransactionType))
                .Cast<TransactionType>()
                .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
                "Value", "Text");
        }
    }
}
