using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventManagement.DTOs;
using EventManagement.Interfaces;

namespace EventManagement.Controllers.AdminDashboardModule
{
    [Route("api/admin/event-categories")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;
        private readonly IMapper _mapper;
        public EventCategoryController(IEventCategoryRepository eventCategoryRepository, IMapper mapper)
        {
            _eventCategoryRepository = eventCategoryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEventCategory([FromBody] CreateEventCategoryDto eventCategoryDto)
        {
            var eventCategory = _mapper.Map<EventCategory>(eventCategoryDto);
            var createdEventCategory = await _eventCategoryRepository.CreateEventCategory(eventCategory);
            return Ok(createdEventCategory);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllEventCategories()
        {
            var allEventCategories = await _eventCategoryRepository.GetAllEventCategories();
            if (allEventCategories.Count == 0)
            {
                return NotFound("No events found, add your first one");
            }
            var allEventCategoriesDto = _mapper.Map<List<GetAllEventCategoryDto>>(allEventCategories);

            return Ok(allEventCategoriesDto);
        }

        [HttpGet("{eventCategoryId}")]
        public async Task<IActionResult> GetEventCategoryId([FromRoute] int eventCategoryId)
        {
            var eventCategory = await _eventCategoryRepository.GetEventCategoryById(eventCategoryId);
            if(eventCategory == null)
                return NotFound($"Event is not found with id {eventCategoryId}");
            return Ok(_mapper.Map<GetAllEventCategoryDto>(eventCategory));
        }

        [HttpPut("{eventCategoryId}")]
        public async Task<IActionResult> UpdateEventCategory([FromRoute]int eventCategoryId, [FromBody] CreateEventCategoryDto updateEventDto)
        {
            var updatedEventModel = _mapper.Map<EventCategory>(updateEventDto);
            var eventCategory = await _eventCategoryRepository.UpdateEventCategoryById(eventCategoryId, updatedEventModel);
            if (eventCategory == null)
            {
                return NotFound($"Event is not found with id {eventCategoryId}");
            }
            return Ok(_mapper.Map<GetAllEventCategoryDto>(eventCategory));

        }
 
        [HttpDelete("{eventCategoryId}")]
        public async Task<IActionResult> DeleteEventCategory([FromRoute] int eventCategoryId)
        {
            var deletedEventModel = await _eventCategoryRepository.DeleteEventCategoryById(eventCategoryId);
            if (deletedEventModel == null)
                return NotFound($"Event is not found with id {eventCategoryId}");
            return Ok(_mapper.Map<GetAllEventCategoryDto>(deletedEventModel));
        }
    }
}
