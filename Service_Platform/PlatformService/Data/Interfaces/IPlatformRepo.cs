using PlatformService.Models;

namespace PlatformService.Data.Interfaces;

public interface IPlatformRepo
{
   Task<bool> SaveChangesAsync();
   Task<IEnumerable<Platform>> AllPlatformsAsync();
   Task<Platform> PlatformByIdAsync(int id);
   Task CreatePlatformAsync(Platform platform);
}