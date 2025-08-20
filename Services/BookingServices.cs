using AutoMapper;
using EventManagement.DTOs;
using EventManagement.Interface.Repository;
using EventManagement.Interface.services;
using EventManagement.Models;
using EventManagement.Models.BookingModel;

namespace EventManagement.services
{
    public class BookingServices : IBookingServicesInterface
    {
        private readonly IMapper _mapper;
        private readonly IBookingRequest _repository;

        public BookingServices(IMapper mapper, IBookingRequest booking)
        {
            _mapper = mapper;
            _repository = booking;
        }

        public async Task<CreateBookingDto> CreateBookingRequest(CreateBookingDto CreateBookingDto)
        {
            var model = _mapper.Map<BookingRequest>(CreateBookingDto);
            var modelretured = await _repository.CreateBookingRequest(model);
            var model1 = _mapper.Map<CreateBookingDto>(model);
            return model1;
        }

        public async Task<CreateBookingDto> Delete(int id)
        {
            var model = await _repository.DeleteBookingRequestById(id);
            var dto = _mapper.Map<CreateBookingDto>(model);

            return dto;
        }

        public async Task<List<CreateBookingDto>> GetAllBookings()
        {
            var model = await _repository.GetAllBookingRequests();
            var dto = _mapper.Map<List<CreateBookingDto>>(model);
            return dto;
        }

        public async Task<CreateBookingDto> GetBookingRequestById(int id)
        {
            var model = await _repository.GetBookingRequest(id);

            var dto = _mapper.Map<CreateBookingDto>(model);

            return dto;
        }

        public async Task<List<CreateBookingDto>> GetByDate(int month, int year)
        {
            var model = await _repository.FilterByDate(month, year);

            var dto = _mapper.Map<List<CreateBookingDto>>(model);

            return dto;
        }

        public async Task<List<CreateBookingDto>> GetByFilter(string status)
        {
            var model = await _repository.ByFilter_status(status);

            var dtolist = _mapper.Map<List<CreateBookingDto>>(model);

            return dtolist;
        }

        public async Task<UpdateBookingDto> UpdateBookingRequest(UpdateBookingDto Dto)
        {
            var model = _mapper.Map<BookingRequest>(Dto);
            var modelreturned = await _repository.UpdateBookingRequest(model);
            var model1 = _mapper.Map<UpdateBookingDto>(model);
            return model1;
        }

       
    }
}
