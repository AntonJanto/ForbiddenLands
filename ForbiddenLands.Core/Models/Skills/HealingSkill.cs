using ForbiddenLands.Core.Models.Options;

namespace ForbiddenLands.Core.Models.Skills
{
    public class HealingSkill : Skill
    {
        public HealingSkill(Attribute attribute) : base(SkillOptions.Healing, attribute)
        {

        }
    }
}