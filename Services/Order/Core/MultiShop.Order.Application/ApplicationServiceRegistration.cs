using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.Address;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetail;

namespace MultiShop.Order.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetAddressQueryHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<RemoveAddressCommandHandler>();

        services.AddScoped<GetOrderDetailQueryHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<RemoveOrderDetailCommandHandler>();


        return services;
    }
}