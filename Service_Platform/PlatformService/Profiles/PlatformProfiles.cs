using AutoMapper;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Profiles;

public class PlatformProfiles:Profile
{
    public PlatformProfiles()
    {
        //source -> target 
        //In the write case, the user gives us PlatformCreateDto, so this is the source model
        CreateMap<PlatformCreateDto,Platform>();
        CreateMap<Platform, PlatformReadDto>();
    }
}