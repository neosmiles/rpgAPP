using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;
using AutoMapper;

namespace api.Helper
{
  public class MappingProfile : Profile
  {
    protected MappingProfile()
    {
      // CreateMap<Character, CharacterForCreation>();
      // CreateMap<CharacterForCreation, Character>();

      CreateMap<Character, CharacterForGet>();
      CreateMap<CharacterForGet, Character>();

    }
  }
}