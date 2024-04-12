using AutoMapper;
using OnlineStore.Domain.Entities;

namespace OnlineStore.Application.Features.OrderFeatures.CreateOrder
{
    public class CreateOrderMapper : Profile
    {
        public CreateOrderMapper()
        {
            CreateMap<Product, ProductOfOrder>()
            .ForMember(d => d.FinalPrice, o => o.MapFrom(s => s.Price * ((100 - s.Discount) / 100)));

            CreateMap<User, UserOfOrder>();

            CreateMap<Order, CreateOrderResponse>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
                .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.Buyer))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }

    }
}

