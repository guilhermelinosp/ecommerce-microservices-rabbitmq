using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.API.Entities;

namespace ECommerce.API.Mappings
{
    public static class AutoMapping
    {
        public static MapperConfiguration Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductDto, Product>().ReverseMap();
                cfg.CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
                cfg.CreateMap<CartDetailDto, CartDetail>().ReverseMap();
                cfg.CreateMap<CartDto, Cart>().ReverseMap();
                cfg.CreateMap<CouponDto, Coupon>().ReverseMap();
            });
        }
    }
}
