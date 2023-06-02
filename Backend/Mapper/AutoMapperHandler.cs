using AutoMapper;
using Shared.Entity;
using Shared.ModelDTO;

namespace Backend.Mapper
{
    public class AutoMapperHandler : Profile
    {
        public AutoMapperHandler()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Purchaser, PurchaserDTO>().ReverseMap();
            CreateMap<Supplier, SupplierDTO>().ReverseMap();           
        }
    }
}
