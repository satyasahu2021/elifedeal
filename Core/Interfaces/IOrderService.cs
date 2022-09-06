using System.Collections.Concurrent;
using Core.Entities.OrderAggregate;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Internal;

namespace Core.Interfaces
{
    public interface IOrderService
    {
         Task<Order>CreateOrderAsync(string buyerEmail,  string phoneNo, int deliveryMethod, string basketId,
          Address ShippingAddress);

          Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);

          Task<Order> GetOrderByIdAsync(int id, string buyerEmail);

          Task <IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();



    }
}