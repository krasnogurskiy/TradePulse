using BLL.DTOs;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trade_Pulse.Helpers;

namespace Trade_Pulse.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var id = this.GetAuthorizedUserId();
            var orders = await _orderService.GetUserOrdersAsync(id);
            return View(orders);
        }

        [HttpPost("Create")]
        [Authorize(Roles = "Роздрібний покупець")]
        public IActionResult Create(OrderProductDto productDto)
        {
            var createOrderDto = new CreateOrderDto()
            {
                ProductId = productDto.ProductId,
                ItemsCount = productDto.ItemsCount,
            };
            return View(createOrderDto);
        }

        [HttpPost("CreateOrder")]
        [Authorize(Roles = "Роздрібний покупець")]
        public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid) return View("Create", createOrderDto);
            var userId = this.GetAuthorizedUserId();
            createOrderDto.Address = $"{createOrderDto.Region}, {createOrderDto.City}, {createOrderDto.Street}, {createOrderDto.Street}, {createOrderDto.PostalCode}";
            var result = await _orderService.CreateOrderAsync(createOrderDto, userId);
            if (result.IsFailure)
            {
                TempData["Error"] = result.Error!.Message;
                return View("Create", createOrderDto);
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Постачальник")]
        [HttpPost("UpdateOrderStatus")]
        public async Task<IActionResult> UpdateOrderStatus(UpdateOrderDto updateDto)
        {
            var result = await _orderService.UpdateOrderAsync(updateDto);
            if (result.IsFailure) TempData["Error"] = result.Error!;
            return RedirectToAction("Index");
        }

    }
}
