using AutoMapper;
using DTO.Bill;
using DTO.CreditCard;
using DTO.Message;
using DTO.Payment;
using DTO.Property;
using DTO.Revenue;
using DTO.User;
using DTO.Vehicle;
using Models.Document;
using Models.Entities;

namespace Business.Configuration.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //User Mapping
            CreateMap<UserRegisterRequest, User>();
            CreateMap<UserUpdateRequest, User>();
            CreateMap<User, UserGetResponse>();

            //Bill Mapping
            CreateMap<BillInsertRequest, Bill>();
            CreateMap<BillUpdateRequest, Bill>();
            CreateMap<Bill, BillGetResponse>();

            //Property Mapping
            CreateMap<PropertyInsertRequest, Property>();
            CreateMap<PropertyUpdateRequest, Property>();
            CreateMap<Property, PropertyGetResponse>();
            CreateMap<PropertyGetResponse, PropertyUpdateRequest>();

            //Revenue Mapping
            CreateMap<RevenueInsertRequest, Revenue>();
            CreateMap<RevenueUpdateRequest, Revenue>();
            CreateMap<Revenue, RevenueGetResponse>();
            CreateMap<RevenueGetResponse, RevenueUpdateRequest>();

            //Vehicle Mapping
            CreateMap<VehicleInsertRequest, Vehicle>();
            CreateMap<VehicleUpdateRequest, Vehicle>();
            CreateMap<Vehicle, VehicleGetResponse>();

            //Message Mapping
            CreateMap<MessageSendRequest, Message>();
            CreateMap<Message, MessageGetResponse>();

            //CreditCard Mappig
            CreateMap<CreditCardInsertRequest, CreditCard>();
            CreateMap<CreditCardUpdateRequest, CreditCard>();
            CreateMap<CreditCard, CreditCardGetResponse>();
            CreateMap<CreditCard, PayBillRequest>();
        }

    }
}
