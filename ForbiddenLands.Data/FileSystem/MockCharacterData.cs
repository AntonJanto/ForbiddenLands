using ForbiddenLands.Core.Models;
using ForbiddenLands.Core.Models.Ages;
using ForbiddenLands.Core.Models.Attributes;
using ForbiddenLands.Core.Models.Options;
using ForbiddenLands.Core.Models.Skills;
using ForbiddenLands.Core.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForbiddenLands.Data.FileSystem
{
    public class MockCharacterData : IDataStore
    {

        public MockCharacterData()
        {

        }

        public async Task<CharacterSheet> GetCharacterSheetAsync(int characterId)
        {
            return await Task.FromResult(MockCharacter());
        }

        public async Task<List<Talent>> GetTalentListAsync()
        {
            return await Task.FromResult(MockTalents());
        }

        public CharacterSheet MockCharacter()
        {
            CharacterSheet character = new CharacterSheet();

            character.Id = 1;
            character.Name = "Tondo";

            character.Age = new AdultAge() { AgeInYears = 32 };

            character.Strength = new StrengthAttribute() { CurrentDie = 4, TotalDie = 4 };
            character.Agility = new AgilityAttribute() { CurrentDie = 2, TotalDie = 2 };
            character.Wits = new WitsAttribute() { CurrentDie = 3, TotalDie = 3 };
            character.Empathy = new EmpathyAttribute() { CurrentDie = 2, TotalDie = 5 };

            character.Might = new MightSkill(character.Strength) { Level = 1 };
            character.Endurance = new EnduranceSkill(character.Strength);
            character.Melee = new MeleeSkill(character.Strength) { Level = 1 };
            character.Crafting = new CraftingSkill(character.Strength) { Level = 2 };
            character.Stealth = new StealthSkill(character.Agility);
            character.SleightOfHand = new SleightOfHandSkill(character.Agility) { Level = 1 };
            character.Move = new MoveSkill(character.Agility);
            character.Marksmanship = new MarksmanshipSkill(character.Agility);
            character.Scouting = new ScoutingSkill(character.Agility) { Level = 1 };
            character.Lore = new LoreSkill(character.Wits);
            character.Survival = new SurvivalSkill(character.Wits);
            character.Insight = new InsightSkill(character.Wits) { Level = 1 };
            character.Manipulation = new ManipulationSkill(character.Empathy) { Level = 3 };
            character.Performance = new PerformanceSkill(character.Empathy);
            character.Healing = new HealingSkill(character.Empathy);
            character.AnimalHandling = new AnimalHandlingSkill(character.Empathy);

            character.Talents = MockTalents();
            character.Weapons = MockWeapons(); 
            return character;
        }

        private List<Weapon> MockWeapons()
        {
            return new List<Weapon>()
            {
                new Weapon() { Name = "Nôž", Bonus = 1, Damage = 1, Range = RangeOptions.Shoulder },
                new Weapon() { Name = "Ozbrojená paže", Bonus = 1, Damage = 1, Range = RangeOptions.Shoulder }
            };
        }

        private List<Talent> MockTalents()
        {
            return new List<Talent>()
            {
                new Talent()
                {
                    Name = "Adaptive",
                    Level = 1
                },
                new Talent()
                {
                    Name = "The way of many things",
                    Level = 1
                },
                new Talent()
                {
                    Name = "Smith",
                    Level = 2
                },
                new Talent()
                {
                    Name = "Builder",
                    Level = 1
                },
            };
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
