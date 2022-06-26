using ForbiddenLands.Core.Models.Ages;
using ForbiddenLands.Core.Models.Attributes;
using ForbiddenLands.Core.Models.Skills;
using System.Collections.Generic;

namespace ForbiddenLands.Core.Models
{
    public class CharacterSheet
    {
        public CharacterSheet()
        {

        }

        public int Id { get; set; }
        public List<Talent> Talents { get; set; }
        public List<Weapon> Weapons { get; set; }
        public string Name { get; set; }
        public Age Age { get; set; }

        #region stats
        public Attribute Strength { get; set; }
        public Attribute Agility { get; set; }
        public Attribute Wits { get; set; }
        public Attribute Empathy { get; set; }
        public Skill Might { get; set; }
        public Skill Endurance { get; set; }
        public Skill Melee { get; set; }
        public Skill Crafting { get; set; }
        public Skill Stealth { get; set; }
        public Skill SleightOfHand { get; set; }
        public Skill Move { get; set; }
        public Skill Marksmanship { get; set; }
        public Skill Scouting { get; set; }
        public Skill Lore { get; set; }
        public Skill Survival { get; set; }
        public Skill Insight { get; set; }
        public Skill Manipulation { get; set; }
        public Skill Performance { get; set; }
        public Skill Healing { get; set; }
        public Skill AnimalHandling { get; set; }
        #endregion

        public static CharacterSheet Create()
        {
            CharacterSheet res = new CharacterSheet();

            res.SetAge();
            res.SetAttributes();
            res.SetSkills(res.Strength, res.Agility, res.Wits, res.Empathy);

            return res;
        }

        public void SetAge()
        {
            Age = new AdultAge();
        }

        public void SetSkills(Attribute strength, Attribute agility, Attribute wits, Attribute empathy)
        {
            Might = new MightSkill(strength);
            Endurance = new EnduranceSkill(strength);
            Melee = new MeleeSkill(strength);
            Crafting = new CraftingSkill(strength);
            Stealth = new StealthSkill(agility);
            SleightOfHand = new SleightOfHandSkill(agility);
            Move = new MoveSkill(agility);
            Marksmanship = new MarksmanshipSkill(agility);
            Scouting = new ScoutingSkill(agility);
            Lore = new LoreSkill(wits);
            Survival = new SurvivalSkill(wits);
            Insight = new InsightSkill(wits);
            Manipulation = new ManipulationSkill(empathy);
            Performance = new PerformanceSkill(empathy);
            Healing = new HealingSkill(empathy);
            AnimalHandling = new AnimalHandlingSkill(empathy);
        }

        public void SetAttributes()
        {
            Strength = new StrengthAttribute();
            Agility = new AgilityAttribute();
            Wits = new WitsAttribute();
            Empathy = new EmpathyAttribute();
        }
    }
}