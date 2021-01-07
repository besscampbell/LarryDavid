using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LarryDavid.Models
{
  public class LarryDavidContextFactory : IDesignTimeDbContextFactory<LarryDavidContext>
  {

    LarryDavidContext IDesignTimeDbContextFactory<LarryDavidContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<LarryDavidContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new LarryDavidContext(builder.Options);
    }
  }
}