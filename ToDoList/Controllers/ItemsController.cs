using Microsoft.AspNetCore.Mvc.Rendering;
using ToDoList.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace ToDoList.Controllers
{
  public ActionResult Create()
{
    return View();
}
public ActionResult Details(int id)
{
    Item thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    return View(thisItem);
}
public ActionResult Edit(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    return View(thisItem);
}

[HttpPost]
public ActionResult Edit(Item item)
{
    _db.Entry(item).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
}
public ActionResult Delete(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    return View(thisItem);
}

[HttpPost, ActionName("Delete")]
public ActionResult DeleteConfirmed(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    _db.Items.Remove(thisItem);
    _db.SaveChanges();
    return RedirectToAction("Index");
}

[HttpPost]
public ActionResult Create(Item item)
{
    _db.Items.Add(item);
    _db.SaveChanges();
    return RedirectToAction("Index");
}
  public class ItemsController : Controller
  {

    [HttpGet("/categories/{categoryId}/items/new")]
    public ActionResult New(int categoryId)
    {
       Category category = Category.Find(categoryId);
       return View(category);
    }

    [HttpGet("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Show(int categoryId, int itemId)
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }
    public ActionResult Index()
{
    List<Item> model = _db.Items.Include(item => item.Category).ToList();
    return View(model);
}

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
    public ActionResult Create()
{
    ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    return View();
}

public ActionResult Edit(int id)
{
    var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    return View(thisItem);
}

  }
}