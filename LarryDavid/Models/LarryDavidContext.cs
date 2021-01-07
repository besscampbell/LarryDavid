using Microsoft.EntityFrameworkCore;

namespace LarryDavid.Models
{
  public class LarryDavidContext : DbContext
  {
    public virtual DbSet<Theme> Themes { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<EpisodeTheme> EpisodeTheme { get; set; }
    public LarryDavidContext(DbContextOptions options) : base(options) { }
  }
}