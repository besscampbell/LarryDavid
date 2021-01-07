using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LarryDavid.Models;
using System.Linq;

namespace LarryDavid.Controllers
{
  public class ThemesController : Controller
  {
    private readonly LarryDavidContext _db;
    public ThemesController(LarryDavidContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Themes.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Theme theme)
    {
      _db.Themes.Add(theme);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisTheme = _db.Themes
        .Include(theme => theme.Episodes)
        .ThenInclude(join => join.Episode)
        .FirstOrDefault(theme => theme.ThemeId == id);
      return View(thisTheme);  
    }

    public ActionResult Edit(int id)
    {
      var thisTheme = _db.Themes.FirstOrDefault(theme => theme.ThemeId == id);
      return View(thisTheme);
    }

    [HttpPost]
    public ActionResult Edit (Theme theme)
    {
      _db.Entry(theme).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTheme = _db.Themes.FirstOrDefault(themes => themes.ThemeId == id);
      return View(thisTheme);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTheme = _db.Themes.FirstOrDefault(themes => themes.ThemeId == id);
      _db.Themes.Remove(thisTheme);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}