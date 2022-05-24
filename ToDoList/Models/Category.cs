
using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Category
  {
    public Category()
    {
      // REMOVED
      // this.Items = new HashSet<Item>();

      // NEW
      this.JoinEntities = new HashSet<CategoryItem>();
    }

    public int CategoryId { get; set; }
    public string Name { get; set; }
    // REMOVED
    // public virtual ICollection<Item> Items { get; set; }

    // NEW - a collection navigation property for JoinEntities
    // a property in one class that includes a reference to a related class
    // ex: this property in Class Category has reference to Class Items
    public virtual ICollection<CategoryItem> JoinEntities { get; set; }
  }
}