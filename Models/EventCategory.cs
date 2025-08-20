
using EventManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

public class EventCategory
{
    public int EventCategoryId { get; set; }

    [Required]
    public string Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; }

    public bool IsDeleted { get; set; } = false;
    public ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();

}