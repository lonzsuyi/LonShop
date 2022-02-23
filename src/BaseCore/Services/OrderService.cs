using System;
using System.Linq;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using LonShop.BaseCore.Interfaces;
using LonShop.BaseCore.Entities.BasketAggregate;
using LonShop.BaseCore.Entities.OrderAggregate;
using LonShop.BaseCore.Entities.GoodAggregate;
using LonShop.BaseCore.Specifications;

namespace LonShop.BaseCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Good> _goodRepository;
        private readonly IRepository<Basket> _basketRepository;
        private readonly IAppLogger<OrderService> _logger;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<Basket> basketRepository,
            IRepository<Good> goodRepository,
            IAppLogger<OrderService> logger
        )
        {
            _orderRepository = orderRepository;
            _goodRepository = goodRepository;
            _basketRepository = basketRepository;
            _logger = logger;
        }

        public async Task CreateOrderAsync(int basketId, long currencyId)
        {
            try
            {
                var basketSpec = new BasketWithItemsSpecification(basketId);
                var basket = await _basketRepository.GetBySpecAsync(basketSpec);

                Guard.Against.NullBasket(basketId, basket);
                Guard.Against.EmptyBasketOnCheckout(basket.Items);

                var goodSpecification = new GoodsSpecification(basket.Items.Select(b => b.GoodId).ToArray());
                var goods = await _goodRepository.ListAsync(goodSpecification);

                var items = basket.Items.Select(basketItem =>
                {
                    var good = goods.First(c => c.Id == basketItem.GoodId);
                    var orderItem = new OrderItem(good.Id, basketItem.UnitPrice, basketItem.Quantity);
                    return orderItem;
                }).ToList();

                var order = new Order(basket.BuyerId, currencyId, items);
                await _orderRepository.AddAsync(order);
            }
            catch (Exception ex)
            {
                _logger.LogError("Create order error. \n{0}", ex.Message);
            }
        }
    }
}