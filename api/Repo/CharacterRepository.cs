using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto;
using api.Models;
using api.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace api.Repo
{
  public class CharacterRepository : ICharacterRepository
  {
    private readonly DataContext context;

    public CharacterRepository(DataContext context)
    {
      this.context = context;
    }

    public void add<T>(T entity) where T : class
    {
      context.Add(entity);
    }

    public async Task<Character> AddCharacter(CharacterForCreation field)
    {
      var data = new Character
      {
        Name = field.Name,
        hitPOINTS = field.hitPOINTS,
        Strength = field.Strength,
        Defence = field.Defence,
        Intelligence = field.Intelligence,
        Class = field.Class
      };
      await context.Characters.AddAsync(data);
      await SaveAll();
      return data;

    }

    public void Delete<T>(T entity) where T : class
    {
      context.Remove(entity);
    }

    public async Task<bool> DeleteCharacter(int id)
    {
      var dataFromRepo = await context.Characters.FirstOrDefaultAsync(a => a.Id == id);
      if (dataFromRepo != null)
      {
        context.Characters.Remove(dataFromRepo);
        await SaveAll();
        return true;
      }
      return false;

    }

    public async Task<IEnumerable<Character>> GetCharacters()
    {
      var dataFromRepo = await context.Characters.ToListAsync();
      return dataFromRepo;
    }

    public async Task<IEnumerable<object>> GetCharacterWithId(int id)
    {
      var dataFromRepo = await context.Characters.Where(x => x.Id == id).ToListAsync();
      return dataFromRepo;
    }

    public async Task<bool> SaveAll()
    {
      return await context.SaveChangesAsync() > 0;
    }



    public async Task<Character> UpdateCharacter(CharacterForUpdate model)
    {
      var data = await context.Characters.FirstOrDefaultAsync(i => i.Id == model.Id);
      if (data == null)
      {
        return null;
      };
      data.Name = model.Name;
      data.hitPOINTS = model.hitPOINTS;
      data.Strength = model.Strength;
      data.Defence = model.Defence;
      data.Intelligence = model.Intelligence;
      data.Class = model.Class;
      await SaveAll();

      return data;

    }
  }
}