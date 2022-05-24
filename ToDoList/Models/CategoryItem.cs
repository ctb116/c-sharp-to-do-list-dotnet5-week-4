// NEW
// This class holds information about the relationship between:
// Class Category and Class Item 
namespace ToDoList.Models
{
  public class CategoryItem
    {   
        // three Id properties
        public int CategoryItemId { get; set; }
        public int ItemId { get; set; }
        public int CategoryId { get; set; }
        // Category and Item included as objects
        public virtual Category Category { get; set; }
        public virtual Item Item { get; set; }
    }
}