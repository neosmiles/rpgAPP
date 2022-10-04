using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto;
using api.Models;

namespace api.Repo.Interface
{
    public interface ICharacterRepository
    {
        void add<T>(T entity) where T : class;
         void Delete<T>(T entity) where T : class;
         Task<bool> SaveAll();

      Task<Character> AddCharacter(CharacterForCreation field);
      Task<IEnumerable<Character>> GetCharacters();
      Task<IEnumerable<object>> GetCharacterWithId(int Id);
      //Task<IEnumerable<object>> GetAuthorWithName(string Name);
      Task<Character> UpdateCharacter(CharacterForUpdate model);
      Task <bool> DeleteCharacter(int id);
    }
}