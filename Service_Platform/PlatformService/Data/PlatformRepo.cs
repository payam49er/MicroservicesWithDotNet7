using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Interfaces;
using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo:IPlatformRepo
{
    private readonly AppDbContext _appDbContext;
    public PlatformRepo(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<bool> SaveChangesAsync()
    {
        return await _appDbContext.SaveChangesAsync() >= 0;
    }

    public async Task<IEnumerable<Platform?>> AllPlatformsAsync()
    {
        return await _appDbContext.Platforms.ToArrayAsync();
    }

    public async Task<Platform?> PlatformByIdAsync(int id)
    {
        return await _appDbContext.Platforms.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task CreatePlatformAsync(Platform platform)
    {
        if (platform != null)
        {
            await _appDbContext.Platforms.AddAsync(platform);
        }
        else
        {
            throw new ArgumentNullException(nameof(platform));
        }
    }
}