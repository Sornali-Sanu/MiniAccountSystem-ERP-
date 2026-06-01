using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MiniAccountSystem.Application.Interfaces;
using MiniAccountSystem.Domain.Entities;
using MiniAccountSystem.Web.ViewModels;

namespace MiniAccountSystem.Web.Controllers
{
    public class AccountsController : Controller
    {
        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountService _service;
        public AccountsController(ILogger<AccountsController> logger ,IAccountService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task <IActionResult> Index()
        {
            var accounts = await _service.GetAllAccountsAsync();
            return View(accounts);
        }
        public async Task<IActionResult> Create()
        {
            var account = new AccountVM();
            account.ParentAccounts = (await _service.GetParentAccountsAsync()).Select(
                x => new SelectListItem {
                Value=x.Id.ToString(),
                Text=x.AccountName
                }).ToList();
            return View(account);
        }
        [HttpPost]
        public async Task<IActionResult> Create(AccountVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var account = new Account
            {
                AccountCode = vm.AccountCode,
                AccountName = vm.AccountName,
                AccountTypeId = vm.AccountTypeId,
                ParentAccountId = vm.ParentAccountId,
                IsActive = vm.IsActive
            };

            await _service.CreateAccountAsync(account);

            return RedirectToAction(nameof(Index));
        }

    }
}
