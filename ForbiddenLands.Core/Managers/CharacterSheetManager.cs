using ForbiddenLands.Core.Models;
using ForbiddenLands.Core.Services;
using System.Threading.Tasks;

namespace ForbiddenLands.Core.Managers
{
    public class CharacterSheetManager
    {
        private IDataStore dataStore;

        public CharacterSheet Character { get; private set; }


        public CharacterSheetManager(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public async Task Load(int characterId)
        {
            Character = await dataStore.GetCharacterSheetAsync(characterId);
            if (Character == null)
                throw new NotFoundException(Character);
        }

        public async Task Save()
        {
            await dataStore.SaveChanges();
        }

        private void Increment(Attribute attribute)
        {
            if (attribute.CurrentDie < attribute.TotalDie)
            {
                attribute.CurrentDie++;
            }
        }

        public void IncrementStrength()
        {
            Increment(Character.Strength);
        }

        public void IncrementAgility()
        {
            Increment(Character.Agility);
        }

        public void IncrementWits()
        {
            Increment(Character.Wits);
        }

        public void IncrementEmpathy()
        {
            Increment(Character.Empathy);
        }

        public void Decrement(Attribute attribute)
        {
            if (attribute.CurrentDie > 0)
            {
                attribute.CurrentDie--;
            }
        }

        public void DecrementStrength()
        {
            Decrement(Character.Strength);
        }

        public void DecrementAgility()
        {
            Decrement(Character.Agility);
        }

        public void DecrementWits()
        {
            Decrement(Character.Wits);
        }

        public void DecrementEmpathy()
        {
            Decrement(Character.Empathy);
        }
    }
}
