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
  }
}