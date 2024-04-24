using BLL.DTOs;
using BLL.Errors;
using BLL.Features;
using BLL.Services.Interfaces;
using DAL.Data;
using DAL.Tools;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CartService : ICartService
    {
        private readonly AppDbContext _ctx;
        private readonly IProductService _productService;

        public CartService(AppDbContext ctx, IProductService productService)
        {
            _ctx = ctx;
            _productService = productService;
        }

        public async Task<ServiceResult<int>> AddToCart(CartItemDto item, int userId)
        {
            var product = await _productService.GetByIdAsync(item.ProductId);
            if (product == null) return new NotFoundError("Продукт не знайдено");
            else if (product.ItemsAvailable < item.ItemsCount) return new ModelError("Немає такої кількості товару в наявності");
            product.ItemsAvailable -= item.ItemsCount;

            var user = new User() { Id = userId };
            _ctx.Users.Attach(user);
            _ctx.Products.Attach(product);
            var newCartItem = new CartProduct { ItemsCount = item.ItemsCount, Product = product, User = user };
            _ctx.CartsProducts.Add(newCartItem);
            _productService.UpdateProduct(product);
            await _ctx.SaveChangesAsync();
            return 0;
        }

        public async Task RemoveFromCart(int userId, int productId)
        {
            var deleteRows = await DeleteFromCart(userId, productId);
            if (deleteRows == null) return;
            var totalProducts = deleteRows.Sum(c => c.ItemsCount);

            var product = await _productService.GetByIdAsync(productId);
            product!.ItemsAvailable += Convert.ToUInt32(totalProducts);
            _productService.UpdateProduct(product);
            await _ctx.SaveChangesAsync();

        }
        public async Task<List<CartProduct>?> DeleteFromCart(int userId, int productId, bool save = false)
        {
            var deleteRows = await _ctx.CartsProducts.Include(c => c.User).Include(c => c.Product).Where(c => c.Product.Id == productId && c.User.Id == userId).ToListAsync();
            _ctx.CartsProducts.RemoveRange(deleteRows);
            if(save) await _ctx.SaveChangesAsync();
            return deleteRows;
        }


        public Task<List<CartListItemDto>> GetCartItems(int userId)
        {
            return _ctx.CartsProducts.Include(c => c.User).Where(c => c.User.Id == userId)
            .Include(u => u.Product)
            .GroupBy(c => new { ProductId = c.Product.Id, ProductTitle = c.Product.Title, ProductPrice = c.Product.Price })
            .Select(c => new CartListItemDto { ProductId = c.Key.ProductId, ProductTitle = c.Key.ProductTitle, ItemsCount = (uint)c.Sum(c1 => c1.ItemsCount), Price = c.Key.ProductPrice }).ToListAsync();

        }

        public async Task ClearCart(int userId)
        {
            var deleteRows = await _ctx.CartsProducts.Include(c => c.User).Where(c => c.User.Id == userId).ToListAsync();
            foreach (var row in deleteRows)
            {

            }
            _ctx.CartsProducts.RemoveRange(deleteRows);
            await _ctx.SaveChangesAsync();

        }


    }
}