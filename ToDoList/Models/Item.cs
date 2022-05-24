// REMOVED
// namespace ToDoList.Models
// {
//   public class Item
//   {
//     public int ItemId { get; set; }
//     public string Description { get; set; }
//     public int CategoryId { get; set; }
//     public virtual Category Category { get; set; }
//   }
// }

// NEW
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Item
    {
        // new constructor
        public Item()
        {
            this.JoinEntities = new HashSet<CategoryItem>();
        }

        // auto-implemented properties for ItemId and Description
        public int ItemId { get; set; }
        public string Description { get; set; }

        // a collection navigation property for JoinEntities
        // will hold the list of relationships this instance of Item is a part of
        // ex: Item "wash the dog" belongs to both "Monday Chores" and "Pet Care" Categories
        // this property only has { get; } because we will only { set; } from the Cagetgory side
        public virtual ICollection<CategoryItem> JoinEntities { get;}
    }
}