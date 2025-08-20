namespace EventManagement.Interfaces
{
    public interface IEventCategoryRepository
    {
        Task<EventCategory> CreateEventCategory(EventCategory eventCategory); //C
        Task<EventCategory> UpdateEventCategoryById(int eventCategoryId , EventCategory eventCategory); //U
        Task<EventCategory> GetEventCategoryById(int eventCategoryId); //R
        Task<List<EventCategory>> GetAllEventCategories(); //R
        Task<EventCategory> DeleteEventCategoryById(int eventCategoryId); //D
    }
}
