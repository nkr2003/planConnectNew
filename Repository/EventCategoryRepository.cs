using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using EventManagement.Interfaces;
using EventManagement.Data;

namespace EventManagement.Repository
{
    public class EventCategoryRepository : IEventCategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public EventCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EventCategory> CreateEventCategory(EventCategory eventCategory)
        {
            _context.EventCategories.Add(eventCategory);
            await _context.SaveChangesAsync();
            return eventCategory;
        }

        public async Task<EventCategory> DeleteEventCategoryById(int eventCategoryId)
        {
            var eventCategory = await _context.EventCategories
                                 .FirstOrDefaultAsync(e=>e.EventCategoryId == eventCategoryId);
            if(eventCategory == null)
            {
                return null;
            }
             _context.EventCategories.Remove(eventCategory);
            await _context.SaveChangesAsync();
            return eventCategory;
        }

   

        public async  Task<List<EventCategory>> GetAllEventCategories()
        {
            var allEventCategories = await _context.EventCategories.Include(e=>e.Vendors)
                                            .Where(e=>e.IsDeleted==false).ToListAsync();
            return allEventCategories;
        }

        public async Task<EventCategory> GetEventCategoryById(int eventCategiryId)
        {
            var userEventCategories =  await _context.EventCategories
                                        .FirstOrDefaultAsync(e => e.EventCategoryId == eventCategiryId && e.IsDeleted == false);
            if (userEventCategories == null)
                return null;
            return userEventCategories;
                                       
        }

        public async Task<EventCategory> UpdateEventCategoryById(int eventCategoryId, EventCategory eventCategory)
        {
            var eventCategoryModel = await _context.EventCategories
                                        .FirstOrDefaultAsync(e => e.EventCategoryId == eventCategoryId && e.IsDeleted == false);
            if (eventCategoryModel == null)
                return null;
            eventCategoryModel.Name = eventCategory.Name;
            eventCategoryModel.UpdatedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return eventCategoryModel;
        }

    }
}
