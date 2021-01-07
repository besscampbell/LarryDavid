namespace LarryDavid.Models
{
  public class EpisodeTheme
  {
    public int EpisodeThemeId { get; set; }
    public int EpisodeId { get; set; }
    public int ThemeId { get; set; }
    public Episode Episode { get; set; }
    public Theme Theme { get; set; }
  }
}