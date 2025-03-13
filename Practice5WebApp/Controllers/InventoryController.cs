using Microsoft.AspNetCore.Mvc;
using Practice5Bussiness.Interfaces;
using Practice5Model.DTO;
using Practice5Model.Models;
using Practice5WebApp.Data;

namespace Practice5WebApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IWebApiExecuter _webApiExecuter;

        public InventoryController(IWebApiExecuter webApiExecuter)
        {
            _webApiExecuter = webApiExecuter;
        }

        public async Task<IActionResult> InventoryList()
        {
            return View(await _webApiExecuter.InvokeGet<List<InventoryDTO>>("Inventory"));
        }
    }
}
