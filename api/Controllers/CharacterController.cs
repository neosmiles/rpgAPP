using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Repo.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CharacterController : ControllerBase
  {
    private readonly ICharacterRepository characterRepository;
    private readonly IMapper mapper;

    public CharacterController(ICharacterRepository characterRepository, IMapper mapper)
    {
      this.characterRepository = characterRepository;
      this.mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddCharacter([FromBody] CharacterForCreation field)
    {
       var dataFromRepo = await characterRepository.AddCharacter(field);
       if (dataFromRepo == null)
      {
        return BadRequest
        (new
        {
          message = "Error",
          StatusCode = 401,
          isSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        Data = dataFromRepo
      }); 
    }

    [HttpGet]
    public async Task<ActionResult<CharacterForGet>> getCharacter()
    {
      var dataFromRepo = await characterRepository.GetCharacters();
      if (dataFromRepo == null)
      {
        return BadRequest
        (new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        Data = mapper.Map<ICollection<CharacterForGet>>(dataFromRepo)
      });
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> getCharacterWithId(int id)
    {
      var dataFromRepo = await characterRepository.GetCharacterWithId(id);
      if (dataFromRepo == null)
      {
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 200,
        IsSuccessful = true,
        AuthorId = id,
        data = dataFromRepo
      });
    }

    [HttpPut("Update")]
    public async Task<IActionResult> UpdateCharacter(CharacterForUpdate model)
    {
      var dataFromRepo = await characterRepository.UpdateCharacter(model);
      if (dataFromRepo == null)
      {
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });
      }

      return Ok(new
      {
        Message = "Success",
        StatusCode = 201,
        IsSuccessful = true,
        data = dataFromRepo
      });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> deleteCharacter(int id)
    {
      var dataFromRepo = await characterRepository.DeleteCharacter(id);
      if (!ModelState.IsValid)
        return BadRequest(new
        {
          Message = "Error",
          StatusCode = 401,
          IsSuccessful = false
        });

      return Ok(new
      {
        Message = "Character deleted",
        StatusCode = 201,
        IsSuccessful = true,
        PostId = id,
        dataFromRepo
      });
    }

  }
}