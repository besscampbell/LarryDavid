using Microsoft.AspNetCore.Mvc;
using LarryDavid.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LarryDavid.Controllers
{
  public class EpisodesController : Controller
  {
    private readonly LarryDavidContext _db;

    public EpisodesController(LarryDavidContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Episodes.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.ThemeId = new SelectList(_db.Themes, "ThemeId", "Joke");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Episode episode, int ThemeId)
    {
      _db.Episodes.Add(episode);
      if (ThemeId != 0)
      {
        _db.EpisodeTheme.Add(new EpisodeTheme() { ThemeId = ThemeId, EpisodeId = episode.EpisodeId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}