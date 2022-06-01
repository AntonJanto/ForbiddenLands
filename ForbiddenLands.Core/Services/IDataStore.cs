using ForbiddenLands.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ForbiddenLands.Core.Services
{
    public interface IDataStore
    {
        Task<CharacterSheet> GetCharacterSheetAsync(string name);
        Task<List<Talent>> GetTalentListAsync();
    }
}
