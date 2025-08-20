using AutoMapper;
using EventManagement.Api.Models;
using EventManagement.DTOs;
using EventManagement.DTOs.AuthDtos;
using EventManagement.DTOs.UserDtos;
using EventManagement.Models;
using EventManagement.Models.AdminModel;
using EventManagement.DTOs;
using EventManagement.Models.BookingModel;
using EventManagement.Models.PaymentModel;
namespace EventManagement.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<VendorServiceDto, VendorService>().ReverseMap();
            CreateMap<VendorDto, Vendor>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<User, UserResponseDto>().ReverseMap();
            CreateMap<CreateEventCategoryDto, EventCategory>().ReverseMap();
            CreateMap<EventCategory, GetAllEventCategoryDto>().ReverseMap();
            CreateMap<CreateVendorDto, Vendor>().ReverseMap();
            CreateMap<CreateVendorSeviceDto, VendorService>().ReverseMap();
            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<Vendor, UpdateVendorDto>().ReverseMap();
            CreateMap<VendorService, CreateVendorSeviceDto>().ReverseMap();
            CreateMap<UpdateVendorDto, VendorService>().ReverseMap();
            CreateMap<BookingRequest, CreateBookingDto>().ReverseMap();
            CreateMap<PaymentDto, Payment>().ReverseMap();

        }
    }
}
