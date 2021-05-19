using System.Collections.Generic;

namespace ToDoList.Models
{
  public class Item
  {
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public int ItemId { get; set; }
    public string Description { get; set; }
  }
}
