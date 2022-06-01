using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Skills
{
    public class CraftingSkill : Skill
    {
        public CraftingSkill(Attribute attribute) : base(SkillOptions.Crafting, attribute)
        {

        }
    }
}