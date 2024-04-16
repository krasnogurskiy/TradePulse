using BLL.Services.Interfaces;
using DAL.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Trade_Pulse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize(Roles = "Постачальник")]
        public IActionResult Index()
        {
            List<Order> orders = _orderService.GetAllAsync().Result;

            return View(orders);
        }
    }
}
