using System.Collections.Generic;

namespace LarryDavid.Models
{
  public class Episode
  {
    public Episode()
    {
      this.Themes = new HashSet<EpisodeTheme>();
    }

    public int EpisodeId { get; set; }
    public string Show { get; set; }
    public string SeasonEpisode { get; set; }
    public virtual ICollection<EpisodeTheme> Themes { get; }
  }
}