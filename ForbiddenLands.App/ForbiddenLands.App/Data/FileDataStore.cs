using ForbiddenLands.Core.Models;
using ForbiddenLands.Core.Services;
using ForbiddenLands.Data.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ForbiddenLands.App.Data
{
    public class FileDataStore : IDataStore
    {
        private List<CharacterSheet> characters;
        private const string charactersFilename = "characters.json";
        private string charactersPath;

        public FileDataStore()
        {
            charactersPath = Path.Combine(FileSystem.AppDataDirectory, charactersFilename);
        }

        public async Task LoadCharacters()
        {
            try
            {
                using (var stream = File.OpenRead(charactersPath))
                {
                    characters = await JsonSerializer.DeserializeAsync<List<CharacterSheet>>(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (characters == null || characters.Count == 0)
                {
                    characters = new List<CharacterSheet>();
                    characters.Add(new MockCharacterData().MockCharacter());
                    await SaveChanges();
                }
            }
        }

        public async Task<CharacterSheet> GetCharacterSheetAsync(int characterId)
        {
            return await Task.FromResult(characters.FirstOrDefault(c => c.Id == characterId));
        }

        public Task<List<Talent>> GetTalentListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            using (var stream = File.OpenWrite(charactersPath))
            {
                try
                {
                    await JsonSerializer.SerializeAsync(stream, characters);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }
    }
}
