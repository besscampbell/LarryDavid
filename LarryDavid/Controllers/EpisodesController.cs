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

    public ActionResult Details(int id)
    {
      var thisEpisode = _db.Episodes
        .Include(episode => episode.Themes)
        .ThenInclude(join => join.Theme)
        .FirstOrDefault(episode => episode.EpisodeId == id);
      return View(thisEpisode);
    }

    public ActionResult Edit(int id)
    {
      var thisEpisode = _db.Episodes.FirstOrDefault(episodes => episodes.EpisodeId == id);
      ViewBag.ThemeId = new SelectList(_db.Themes, "ThemeId", "Joke");
      return View(thisEpisode);
    }

    [HttpPost]
    public ActionResult Edit(Episode episode)
    {
      _db.Entry(episode).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTheme(int id)
    {
      var thisEpisode = _db.Episodes.FirstOrDefault(episodes => episodes.EpisodeId == id);
      ViewBag.ThemeId = new SelectList(_db.Themes, "ThemeId", "Joke");
      return View(thisEpisode);
    }

    [HttpPost]
    public ActionResult AddTheme(Episode episode, int ThemeId)
    {
      if(ThemeId != 0)
      {
        var returnedJoin = _db.EpisodeTheme
          .Any(join => join.EpisodeId == episode.EpisodeId && join.ThemeId == ThemeId);
          if(!returnedJoin)
          {
            _db.EpisodeTheme.Add(new EpisodeTheme() { ThemeId = ThemeId, EpisodeId = episode.EpisodeId });
          }
      }
      _db.Entry(episode).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEpisode = _db.Episodes.FirstOrDefault(episodes => episodes.EpisodeId == id);
      return View(thisEpisode);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEpisode = _db.Episodes.FirstOrDefault(episodes => episodes.EpisodeId == id);
      _db.Episodes.Remove(thisEpisode);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}