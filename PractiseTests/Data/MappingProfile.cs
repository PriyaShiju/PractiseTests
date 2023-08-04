using AutoMapper;
using PractiseTests.Data.Entities;
using PractiseTests.ViewModels;


namespace PractiseTests.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
              CreateMap<Order,OrderViewModel>()
                .ForMember(o=>o.OrderId, e=> e.MapFrom(o=> o.OrderId))
                .ReverseMap();

            //CreateMap<OrderItem, OrderItemViewModel>()
            //    .ForMember(o => o.OrderId, e => e.MapFrom(o => o.OrderId))
            //    .ReverseMap();
        }
    }
}
