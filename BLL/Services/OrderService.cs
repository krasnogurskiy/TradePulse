using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Repositories.Interfaces;
using DAL.Tools;

namespace BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartService _cartService;
        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository, ICartService cartService)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _cartService = cartService;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            return orders;
        }

        public async Task<IEnumerable<OrderDto>?> GetUserOrdersAsync(int userId)
        {
            var roles = await _userRepository.GetRolesAsync(userId);
            List<Order> orders;
            if (roles.Contains("Постачальник")) orders = await _orderRepository.GetVendorOrdersAsync(userId);
            else if (roles.Contains("Роздрібний покупець")) orders = await _orderRepository.GetDropshipperOrdersAsync(userId);
            else return null;
            return orders.Select(o => new OrderDto()
            {
                Id = o.Id,
                Address = o.Address,
                CreatedAt = o.CreatedAt,
                DeliveryType = o.DeliveryType,
                DropPrice = o.DropPrice,
                OrderPrice = o.OrderPrice,
                PaymentType = o.PaymentType,
                Receiver = o.Receiver.Email!,
                Vendor = o.Product.Vendor.Email!,
                Status = o.Status,
            });
        }

        public async Task<ServiceResult<int>> CreateOrderAsync(CreateOrderDto orderDto, int userId)
        {
            var product = await _productRepository.GetByIdAsync(orderDto.ProductId);
            if (product == null) return new ModelError("Такий товар не існує");

            var order = new Order()
            {
                CreatedAt = DateTime.Now.ToUniversalTime(),
                ProductsCount = orderDto.ItemsCount,
                DeliveryType = orderDto.DeliveryType,
                DropPrice = orderDto.DropPrice,
                OrderPrice = product.Price * orderDto.ItemsCount,
                PaymentType = orderDto.PaymentType,
                Address = orderDto.Address,
                Status = "Очікується",
                Product = product,
            };
            await _orderRepository.CreateOrderAsync(order, userId);
            await _cartService.DeleteFromCart(userId, orderDto.ProductId, true);

            return 0;
        }

        public async Task<ServiceResult<int>> UpdateOrderAsync(UpdateOrderDto updateOrderDto)
        {
            var order = await _orderRepository.GetByIdAsync(updateOrderDto.Id);
            if (order == null) return new NotFoundError("Замовлення не знайдене");
            else if (order.Status == updateOrderDto.Status) return 0;
            order.Status = updateOrderDto.Status;
            await _orderRepository.UpdateOrderAsync(order);
            return 0;
        }

    }
}
