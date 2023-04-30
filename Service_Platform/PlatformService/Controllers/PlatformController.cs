using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data.Interfaces;
using PlatformService.DTOs;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformService.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class PlatformController:ControllerBase
{
    private readonly IPlatformRepo _platformRepo;
    private readonly IMapper _mapper;
    private readonly ICommandDataClient _commandDataClient;
    
    
    public PlatformController(IPlatformRepo platformRepo,IMapper mapper,ICommandDataClient commandDataClient)
    {
        _platformRepo = platformRepo;
        _mapper = mapper;
        _commandDataClient = commandDataClient;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PlatformReadDto>>> PlatformsAsync()
    {
        var platforms = await _platformRepo.AllPlatformsAsync();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
    }


    [HttpGet("{id}",Name = "PlatformById")]
    public async Task<ActionResult<PlatformReadDto>> PlatformAsync(int id)
    {
        var platformItem = await _platformRepo.PlatformByIdAsync(id);
        if(platformItem != null)
            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        return NotFound();
    }


    /// <summary>
    /// Create Platform
    /// </summary>
    /// <param name="platformCreate"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PlatformReadDto>> PlatformAsync(PlatformCreateDto platformCreate)
    {
        Platform platformModel = _mapper.Map<Platform>(platformCreate);

        await _platformRepo.CreatePlatformAsync(platformModel);
        await _platformRepo.SaveChangesAsync();
        PlatformReadDto prdto = _mapper.Map<PlatformReadDto>(platformModel);
        try
        {
            await _commandDataClient.SendPlatformToCommand(prdto);
        }
        catch (Exception e)
        {
            Console.WriteLine($"--> Could not send asynchronously {e.Message}");
        }
        return Created(nameof(PlatformAsync), new {Id = prdto.Id,platformModel});
    }


}