using System.Collections.Generic;

namespace LarryDavid.Models
{
  public class Theme
  {
    public Theme()
    {
      this.Episodes = new HashSet<EpisodeTheme>();
    }

    public int ThemeId { get; set; }
    public string Joke { get; set; }
    public ICollection<EpisodeTheme> Episodes { get; set; }
  }
}