using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LarryDavid.Models
{
  public class Episode
  {
    public Episode()
    {
      this.Themes = new HashSet<EpisodeTheme>();
    }

    public int EpisodeId { get; set; }
    [Display(Name= "Name of Show")]
    public string Show { get; set; }
    [Display(Name="Season/Episode use format: S01E12")]
    public string SeasonEpisode { get; set; }
    public virtual ICollection<EpisodeTheme> Themes { get; }
  }
}